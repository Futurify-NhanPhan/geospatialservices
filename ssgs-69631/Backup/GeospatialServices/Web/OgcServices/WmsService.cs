using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Collections.Specialized;
using System.Xml;
using System.IO;
using GeospatialServices.Ogc.Common;
using GeospatialServices.Ogc.Wms;
using GeospatialServices.Ogc.Wmc;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace GeospatialServices.Web.OgcServices
{
    /// <summary>
    /// Summary description for WmsService
    /// </summary>
    public class WmsService : IHttpHandler
    {

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            StringDictionary parameters = OgcUtilities.GetRequestParameters(context);
            string request = GetOgcRequest(context.Response, parameters);

            if (request != null)
            {
                try
                {
                    switch (request.ToLower())
                    {
                        case "getcapabilities":     //GetCapabilities
                            ProcessGetCapabilities(context.Response, parameters);
                            break;

                        case "getmap":              //GetMap
                            ProcessGetMap(context.Response, parameters);
                            break;

                        case "getlegendgraphic":    //GetLegendGraphic
                            ProcessGetLegendGraphic(context.Response, parameters);
                            break;

                        case "getmetadata":         //GetMetadata
                            ProcessGetMetadata(context.Response, parameters);
                            break;

                        case "getfeatureinfo":      //GetFeatureInfo
                            ProcessGetFeatureInfo(context, parameters);
                            break;

                        default:
                            SetResponseToServiceException(context.Response, "Invalid REQUEST specified for WMS");
                            break;
                    }
                }
                catch (WmsFault ex)
                {
                    SetResponseToServiceException(context.Response, ex.WmsExceptionCode, ex.Message);
                }
            }
        }

        /// <summary>
        /// Verify required OGC parameters have been supplied return the request parameter
        /// </summary>
        private string GetOgcRequest(HttpResponse response, StringDictionary parameters)
        {
            //Request parameter is mandatory
            string request = parameters[OgcParameters.Request];

            if (String.IsNullOrEmpty(request))
            {
                SetResponseToServiceException(response, (OgcErrorMessages.RequiredParameter(OgcParameters.Request)));
                return null;
            }

            if (!String.IsNullOrEmpty(parameters[OgcParameters.Version]))
            {
                if (String.Compare(parameters[OgcParameters.Version], "1.3.0", true) != 0)
                {
                    SetResponseToServiceException(response, "Only version 1.3.0 supported");
                    return null;
                }
            }
            else //Version is mandatory if REQUEST!=GetCapabilities. Check if this is a capabilities request, since VERSION is null
            {
                if ((String.Compare(request, "GetCapabilities", true) != 0)
                    && (String.Compare(request, "GetMetadata", true) != 0)
                    && (String.Compare(request, "GetLegendImage", true) != 0))
                {
                    SetResponseToServiceException(response, OgcErrorMessages.RequiredParameter(OgcParameters.Version));
                    return null;
                }
            }

            return request;
        }

        #endregion

        #region OGC WMS Operations

        /// <summary>
        /// OGC WMS GetCapabilities
        /// </summary>
        /// <param name="context"></param>
        private void ProcessGetCapabilities(HttpResponse response, StringDictionary parameters)
        {
            //Service parameter is mandatory for GetCapabilities request
            if (String.IsNullOrEmpty(parameters[OgcParameters.Service]))
            {
                SetResponseToServiceException(response, OgcErrorMessages.RequiredParameter(OgcParameters.Service));
                return;
            }

            if (String.Compare(parameters[OgcParameters.Service], ServiceNames.WMS.ToString()) != 0)
            {
                SetResponseToServiceException(response, "Invalid service for GetCapabilities Request. Service parameter must be 'WMS'");
                return;
            }

            // deserialise template GetCapabilities document
            XmlSerializer deSerializer = new XmlSerializer(typeof(WMS_Capabilities), Declarations.WmsNameSpace);
            FileStream readStream = new FileStream(Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), "WMSCapabilities.xml"), FileMode.Open, FileAccess.Read);
            WMS_Capabilities wmsCapabilities = (WMS_Capabilities)deSerializer.Deserialize(readStream);
            readStream.Close();

            // get the map service view context
            ViewContext webMapContext = OgcUtilities.GetViewContext();

            // add layers
            List<GeospatialServices.Ogc.Wms.Layer> wmsLayers = new List<GeospatialServices.Ogc.Wms.Layer>();
            foreach (var layer in webMapContext.Layers)
            {
                GeospatialServices.Ogc.Wms.Layer ogcLayer = new GeospatialServices.Ogc.Wms.Layer( );
                ogcLayer.Queryable = 1;
                ogcLayer.Name = layer.Name;
                ogcLayer.Title = layer.Title;
                ogcLayer.CRSList.Add(layer.SRS);
                wmsLayers.Add(ogcLayer);
            }
            wmsCapabilities.Capability.Layer.LayerList = wmsLayers;

            // Namespaces
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(Declarations.WmsPrefix, Declarations.WmsNameSpace);
            namespaces.Add(Declarations.OgcPrefix, Declarations.OgcNameSpace);
            namespaces.Add(Declarations.XlinkPrefix, Declarations.XlinkNameSpace);

            // Serialize
            XmlSerializer capSerializer = new XmlSerializer(typeof(WMS_Capabilities), Declarations.WmsNameSpace);
            MemoryStream memoryStream = new MemoryStream();
            capSerializer.Serialize(memoryStream, wmsCapabilities, namespaces);

            byte[] buffer = memoryStream.ToArray();
            response.Clear();
            response.ContentType = "text/xml";
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// OGC WMS GetMap
        /// </summary>
        /// <param name="context"></param>
        private void ProcessGetMap(HttpResponse response, StringDictionary parameters)
        {
            System.Drawing.Image mapImage;
            CheckIsValidGetMapRequest(parameters);

            try
            {
                ViewContext viewContext = new ViewContext(parameters);
                mapImage = viewContext.Render(parameters);                
            }
            catch (System.Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw;
            }

            //Render map
            response.Clear();
            string mimeType = parameters[WmsParameters.Format];
            response.ContentType = mimeType;
            byte[] mapImageResponse = ImageToByteArray(mapImage, mimeType);
            response.OutputStream.Write(mapImageResponse, 0, mapImageResponse.Length);
        }


        /// <summary>
        /// Convert Image to ByteArray
        /// </summary>
        public static byte[] ImageToByteArray(System.Drawing.Image image, string mimeType)
        {
            if (image == null) return null;

            ImageCodecInfo encoder = GetImageEncoder(mimeType);
            using (MemoryStream ms = new MemoryStream())
            {
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);

                image.Save(ms, encoder, encoderParameters);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Used for setting up output format of image file
        /// </summary>
        public static ImageCodecInfo GetImageEncoder(String mimeType)
        {
            foreach (ImageCodecInfo encoder in ImageCodecInfo.GetImageEncoders())
            {
                if (encoder.MimeType == mimeType)
                    return encoder;
            }

            return null;
        }


        /// <summary>
        ///  Gets the Metadata associated with the Requested Layer
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private void ProcessGetMetadata(HttpResponse response, StringDictionary parameters)
        {
            ////Check for required parameters
            //string layer = parameters[WmsParameters.Layer];

            //if (String.IsNullOrEmpty(layer))
            //{
            //    SetResponseToServiceException(response, OgcErrorMessages.RequiredParameter(WmsParameters.Layer));
            //    return;
            //}

            //MD_Metadata layerMetadata = new MD_Metadata();
            ////TODO: Populate metadata

            //// Namespaces
            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            //namespaces.Add(GeospatialServices.Iso.Common.SchemaDeclarations.GmdPrefix, GeospatialServices.Iso.Common.SchemaDeclarations.GmdNameSpace);
            //namespaces.Add(GeospatialServices.Iso.Common.SchemaDeclarations.GcoPrefix, GeospatialServices.Iso.Common.SchemaDeclarations.GcoNameSpace);
            //namespaces.Add(GeospatialServices.Iso.Common.SchemaDeclarations.XlinkPrefix, GeospatialServices.Iso.Common.SchemaDeclarations.XlinkNameSpace);
            //namespaces.Add(GeospatialServices.Iso.Common.SchemaDeclarations.XsiPrefix, GeospatialServices.Iso.Common.SchemaDeclarations.XsiNameSpace);
            //namespaces.Add(GeospatialServices.Iso.Common.SchemaDeclarations.GmlPrefix, GeospatialServices.Iso.Common.SchemaDeclarations.GmlNameSpace);

            //// Serialize
            //XmlSerializer serializer = new XmlSerializer(typeof(MD_Metadata));
            //MemoryStream memoryStream = new MemoryStream();
            //serializer.Serialize(memoryStream, layerMetadata, namespaces);

            //byte[] buffer = memoryStream.ToArray();
            //response.Clear();
            //response.ContentType = "text/xml";
            //response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// OGC WMS GetLegendGraphic
        /// </summary>
        /// <param name="context"></param>
        private void ProcessGetLegendGraphic(HttpResponse response, StringDictionary parameters)
        {
            //byte[] mapImage = spatialServiceClient.GetLegendGraphic(parameters);
            //TODO: 
            response.Clear();

            //if (mapImage != null)
            //{
            //    string mimeType = parameters[WmsParameters.Format];
            //    response.ContentType = mimeType;
            //    response.OutputStream.Write(mapImage, 0, mapImage.Length);
            //}
        }


        /// <summary>
        /// OGC WMS GetFeatureInfo
        /// </summary>
        /// <param name="context"></param>
        private void ProcessGetFeatureInfo(HttpContext context, StringDictionary parameters)
        {
            string infoFormat = parameters[WmsParameters.InfoFormat];

            if (String.IsNullOrEmpty(infoFormat))
            {
                SetResponseToServiceException(context.Response, OgcErrorMessages.RequiredParameter(WmsParameters.InfoFormat));
                return;
            }

            // Store the Aggregate Schema for clients that validate the schema
            if (!File.Exists(context.Server.MapPath(Declarations.DefaultSchemaName)))
            {
                //byte[] featureTypesSchema = spatialServiceClient.GetAllFeatureTypes();
                //TODO:

                // Schema
                //    MemoryStream schemaMemoryStream = new MemoryStream(featureTypesSchema);
                //    XmlDocument schemaDocument = new XmlDocument();
                //    schemaDocument.Load(schemaMemoryStream);
                //    schemaDocument.Save(context.Server.MapPath(Declarations.FishSchemaName));
            }

            //// Features
            //FeatureCollection featureCollection = spatialServiceClient.GetFeatureInfo(parameters);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(Declarations.WmsPrefix, Declarations.WmsNameSpace);
            namespaces.Add(Declarations.DefaultPrefix, Declarations.DefaultNameSpace);
            namespaces.Add(Declarations.WmsPrefix, Declarations.WmsNameSpace);
            namespaces.Add(Declarations.OgcPrefix, Declarations.OgcNameSpace);
            namespaces.Add(Declarations.GmlPrefix, Declarations.GmlNameSpace);
            namespaces.Add(Declarations.GmlSfPrefix, Declarations.GmlSfNameSpace);
            namespaces.Add(Declarations.XlinkPrefix, Declarations.XlinkNameSpace);

            context.Response.Clear();
            context.Response.ContentType = infoFormat;
            XmlWriter xmlWriter = XmlWriter.Create(context.Response.OutputStream);

            //XmlSerializer serializer = new XmlSerializer(typeof(FeatureCollection), Declarations.FishNameSpace);
            //MemoryStream xmlMemoryStream = new MemoryStream();
            //serializer.Serialize(xmlMemoryStream, featureCollection, namespaces);

            //xmlMemoryStream.Position = 0;
            //XmlDocument xmlDocument = new XmlDocument();
            //xmlDocument.Load(xmlMemoryStream);

            //if (infoFormat.ToLower() == "text/html")
            //{
            //    XmlProcessingInstruction processingInstruction = xmlDocument.CreateProcessingInstruction("xml-stylesheet", String.Format("type='text/xsl' href='{0}'", Declarations.DefaultStyleSheet));
            //    xmlDocument.InsertAfter(processingInstruction, xmlDocument.FirstChild);
            //}

            //xmlDocument.WriteTo(xmlWriter);
            //xmlWriter.Flush();
        }

        #endregion

        #region Exception Handling
        /// <summary>
        /// Populate the HttpResponse with a ServiceExceptionReport
        /// </summary>
        /// <param name="response"></param>
        /// <param name="message"></param>
        private void SetResponseToServiceException(HttpResponse response, string message)
        {
            SetResponseToServiceException(response, WmsExceptionCode.NotApplicable, message);
        }

        /// <summary>
        /// Populate the HttpResponse with a ServiceExceptionReport
        /// </summary>
        /// <param name="response"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        private void SetResponseToServiceException(HttpResponse response, WmsExceptionCode code, string message)
        {
            ServiceExceptionReport serviceExceptionReport = new ServiceExceptionReport();
            serviceExceptionReport.ServiceExceptionList.Add(new ServiceException(code, message));
            response.Clear();
            response.ContentType = "text/xml";

            // Namespaces
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(Declarations.WmsPrefix, Declarations.WmsNameSpace);
            namespaces.Add(Declarations.OgcPrefix, Declarations.OgcNameSpace);
            namespaces.Add(Declarations.XlinkPrefix, Declarations.XlinkNameSpace);

            // Serialize
            XmlSerializer serializer = new XmlSerializer(typeof(ServiceExceptionReport));
            serializer.Serialize(response.OutputStream, serviceExceptionReport, namespaces);
        }

        #endregion


        private void CheckIsValidGetMapRequest(StringDictionary dictionary)
        {
            if (String.IsNullOrEmpty(dictionary[WmsParameters.SldBody]))
            {
                // Check for required parameters
                if (String.IsNullOrEmpty(dictionary[WmsParameters.Layers]))
                    throw new WmsFault(WmsExceptionCode.LayerNotDefined, "Either SLD_BODY or LAYERS must be specified");

                if (dictionary[WmsParameters.Styles] == null)
                    throw new WmsFault(WmsExceptionCode.StyleNotDefined, "Either SLD_BODY or STYLES must be specified");
            }
            if (String.IsNullOrEmpty(dictionary[WmsParameters.Crs]))
                throw new WmsFault(WmsExceptionCode.InvalidCRS, OgcErrorMessages.RequiredParameter(WmsParameters.Crs));

            if (String.IsNullOrEmpty(dictionary[WmsParameters.Bbox]))
                throw new WmsFault(WmsExceptionCode.InvalidDimensionValue, OgcErrorMessages.RequiredParameter(WmsParameters.Bbox));

            if (String.IsNullOrEmpty(dictionary[WmsParameters.Width]))
                throw new WmsFault(WmsExceptionCode.InvalidDimensionValue, OgcErrorMessages.RequiredParameter(WmsParameters.Width));

            if (String.IsNullOrEmpty(dictionary[WmsParameters.Height]))
                throw new WmsFault(WmsExceptionCode.InvalidDimensionValue, OgcErrorMessages.RequiredParameter(WmsParameters.Height));

            string mimeType = dictionary[WmsParameters.Format];

            if (String.IsNullOrEmpty(mimeType))
                throw new WmsFault(WmsExceptionCode.InvalidFormat, OgcErrorMessages.RequiredParameter(WmsParameters.Format));

            // Get the image format requested
            //System.Drawing.Imaging.ImageCodecInfo imageEncoder = GraphicsHelper.GetImageEncoder(mimeType);
            //if (imageEncoder == null)
            //    throw new FaultException<WmsFault>(new WmsFault(WmsExceptionCode.InvalidFormat), "Invalid MimeType specified in FORMAT parameter");

            int height, width = 0;

            if (!int.TryParse(dictionary[WmsParameters.Width], out width))
                throw new WmsFault(WmsExceptionCode.InvalidDimensionValue, "Invalid parameter WIDTH");

            if (MapLimits.MaxMapWidth > 0 && width > MapLimits.MaxMapWidth)
                throw new WmsFault(WmsExceptionCode.OperationNotSupported, "Parameter WIDTH too large");

            if (!int.TryParse(dictionary[WmsParameters.Height], out height))
                throw new WmsFault(WmsExceptionCode.InvalidDimensionValue, "Invalid parameter HEIGHT");

            if (MapLimits.MaxMapHeight > 0 && height > MapLimits.MaxMapHeight)
                throw new WmsFault(WmsExceptionCode.OperationNotSupported, "Parameter HEIGHT too large");

            //if (!Utils.IsValidBBox(dictionary[WmsParameters.Bbox]))
            //    throw new FaultException<WmsFault>(new WmsFault(WmsExceptionCode.NotApplicable), "Invalid parameter BBOX");

            // Set layers on/off
            if (!String.IsNullOrEmpty(dictionary[WmsParameters.Layers]))
            {
                string[] requestedLayers = dictionary[WmsParameters.Layers].Split(new char[] { ',' });
                string styles = dictionary[WmsParameters.Styles];
                string[] requestedStyles = styles.Split(new char[] { ',' });

                if (styles != string.Empty && requestedStyles.Length > 0 && requestedLayers.Length != requestedStyles.Length)
                    throw new WmsFault(WmsExceptionCode.NotApplicable, "The number of STYLES should match the number of LAYERS");

                if (MapLimits.MaxMapLayers > 0)
                {
                    if (requestedLayers.Length > MapLimits.MaxMapLayers)
                        throw new WmsFault(WmsExceptionCode.OperationNotSupported, "Too many layers requested");
                }
            }
        }

    }
}