using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeospatialServices.Ogc.Common;
using GeospatialServices.Ogc.Wmc;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Specialized;
using System.Drawing;
using GeospatialServices.Runtime;
using Microsoft.SqlServer.Types;

namespace GeospatialServices.Ogc.Wmc 
{
    public partial class ViewContext
    {
        public double PixelAspectRatio = 0.0;
        public double Zoom = 0.0;
        public double CenterX = 0.0;
        public double CenterY = 0.0;
        public double PixelWidth  = 0.0;
        public double PixelHeight = 0.0;

        public ViewContext()
        {

        }

        /// <summary>
        /// Renders a map image of the ViewContext
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public System.Drawing.Image Render(StringDictionary parameters)
        {
            // create sized bitmap image
            Bitmap bitmap = new System.Drawing.Bitmap(this.General.Window.Width, this.General.Window.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage((Image)bitmap);

            // Set background color of image
            if (String.Compare(parameters[WmsParameters.Transparent], "true", true) == 0)
            {
                g.Clear(System.Drawing.Color.Transparent);
            }
            else if (parameters[WmsParameters.BgColor] != null)
            {
                g.Clear(System.Drawing.ColorTranslator.FromHtml(parameters[WmsParameters.BgColor]));
            }
            else
            {
                g.Clear(System.Drawing.Color.White);
            }

            BoundingBox bbox = new BoundingBox(parameters[WmsParameters.Bbox], 4326);

            Zoom = bbox.Width;
            CenterX = bbox.CenterX;
            CenterY = bbox.CenterY;
            PixelAspectRatio = ((double)this.General.Window.Width / (double)this.General.Window.Height) / (bbox.Width / bbox.Height);
            PixelWidth = Zoom / (double)this.General.Window.Width;
            PixelHeight = (Zoom / (double)this.General.Window.Width) * PixelAspectRatio;

            foreach (Layer layer in this.Layers)
            {
                GeospatialServices.Runtime.FeatureDataSet featureDataSet = new GeospatialServices.Runtime.FeatureDataSet();
                layer.ExecuteSpatialQuery(bbox.ToSqlGeometry, featureDataSet);
                layer.Render(g, featureDataSet, this);
            }
            return (Image)bitmap;
        }

        /// <summary>
        /// Gets the WMC Context associated with a WMS Request
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public ViewContext(StringDictionary parameters)
        {
            // Parse map size
            int width = 0;
            int height = 0;

            int.TryParse(parameters[WmsParameters.Width], out width);
            int.TryParse(parameters[WmsParameters.Height], out height);

            this.General.Window.Width = width;
            this.General.Window.Height = height;

            // Attach the Bounding Box if passed in, otherwise, it will be set to the 
            // envelope of all layers
            string crs = parameters[WmsParameters.Crs];
            int srid = OgcUtilities.GetSridFromCrs(crs);

            if (parameters[WmsParameters.Bbox] != null)
            {
                this.General.BoundingBox = new GeospatialServices.Ogc.Wmc.BoundingBox(parameters[WmsParameters.Bbox], srid);
                this.General.BoundingBox.SRS = crs;
            }

            SLD sldRead = null;

            // Get the SLD_BODY if specified
            if (!String.IsNullOrEmpty(parameters[WmsParameters.SldBody]))
            {
                // Namespaces
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

                namespaces.Add(Declarations.WmsPrefix, Declarations.WmsNameSpace);
                namespaces.Add(Declarations.SldPrefix, Declarations.SldNameSpace);
                namespaces.Add(Declarations.SePrefix, Declarations.SeNameSpace);
                namespaces.Add(Declarations.OgcPrefix, Declarations.OgcNameSpace);
                namespaces.Add(Declarations.XlinkPrefix, Declarations.XlinkNameSpace);

                using (StringReader stringReader = new StringReader(parameters[WmsParameters.SldBody]))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SLD));
                    sldRead = (SLD)serializer.Deserialize(stringReader);
                }
            }

            // Extract all layers from request
            string layers = "";
            if (parameters[OgcParameters.Service] == GeospatialServices.Ogc.Common.ServiceNames.WFS.ToString())
                layers = parameters[WfsParameters.TypeName];
            else
                layers = parameters[WmsParameters.Layers];

            if (!String.IsNullOrEmpty(layers))
            {
                string[] requestedLayers = layers.Split(new char[] { ',' });
                string[] requestedStyles = null;

                string styles = parameters[WmsParameters.Styles];
                if (string.IsNullOrEmpty(styles))
                {
                    requestedStyles = new string[0];
                }
                else
                {
                    requestedStyles = styles.Split(new char[] { ',' });
                }

                // get all know layers from the confguration view context document
                ViewContext configurationContext = OgcUtilities.GetViewContext();

                // build a custom WMC document from the layers and styles in the request
                for (int i = 0; i < requestedLayers.Count(); i++)
                {
                    // find the requested layers configuration
                    string layerName = requestedLayers[i].Trim();
                    int layerIndex = configurationContext.Layers.FindIndex(delegateLayer => delegateLayer.Name == layerName);

                    if (layerIndex != -1)
                    {
                        // find the style 
                        GeospatialServices.Ogc.Wmc.UserStyle sldStyle = null;

                        string requestedStyle = string.Empty;
                        if (requestedStyles.Count() > i) requestedStyle = requestedStyles[i].Trim();

                        if (sldRead != null)
                        {
                            foreach (var sldlayer in sldRead.StyledLayerDescriptor.UserLayers)
                            {
                                foreach (UserStyle style in sldlayer.UserStyles)
                                {
                                    if (style.Name == requestedStyle)
                                    {
                                        sldStyle = style;
                                        requestedStyle = string.Empty;
                                        break;
                                    }
                                }
                                if (requestedStyle == string.Empty)
                                    break;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(requestedStyle))
                                requestedStyle = "default";
                            Style style = configurationContext.Layers[layerIndex].StyleList.Find(delegateStyle => delegateStyle.Name == requestedStyle);
                            if (style == null)
                                throw new InvalidDataException("Style not found");
                            sldStyle = style.SLD.StyledLayerDescriptor.UserLayers[0].UserStyles[0];
                        }

                        // get the layer and remove configured styles
                        GeospatialServices.Ogc.Wmc.Layer wmcLayer = configurationContext.Layers[layerIndex].Clone();
                        wmcLayer.StyleList.Clear();

                        // now add the style to be rendered
                        if (sldStyle != null)
                        {
                            wmcLayer.StyleList.Add(new GeospatialServices.Ogc.Wmc.Style());
                            wmcLayer.StyleList[0].Current = 1;
                            UserLayer ul = new UserLayer();
                            ul.UserStyles = new List<UserStyle>();
                            wmcLayer.StyleList[0].SLD.StyledLayerDescriptor.UserLayers.Add(ul);
                            wmcLayer.StyleList[0].SLD.StyledLayerDescriptor.UserLayers[0].UserStyles.Add(sldStyle);
                        }

                        if (parameters[WmsParameters.Format] != null)
                            wmcLayer.FormatList.Add(new Format(parameters[WmsParameters.Format], 1));

                        this.Layers.Add(wmcLayer);
                    }
                }

                //TODO: do this properly....
                // compute envelope if required
                if (this.General.BoundingBox.ToSqlGeometry == null)
                {
                    this.General.BoundingBox = new BoundingBox("-180,-85,180,85", 4326);
                }
            }
        }
    }
}
