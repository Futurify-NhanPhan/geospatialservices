using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeospatialServices.Ogc.Wms.GmlSf;
using GeospatialServices.Ogc.Common;
using Microsoft.SqlServer.Types;
using System.Collections.Specialized;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using System.IO;
using GeospatialServices.Runtime;
using System.Xml.Schema;
using GeospatialServices.Ogc.Wmc;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    /// <summary>
    /// Runtime implementation code for integrating with SqlGeometry and the FeatureCollection object
    /// </summary>
    public partial class FeatureCollection
    {
        public FeatureCollection()
        {

        }

        /// <summary>
        ///  Creates a FeatureCollection from a list of OGC layers within a ViewContext
        /// </summary>
        public FeatureCollection(ViewContext context, StringDictionary parameters)
        {
            string srs = string.Empty;
            GeospatialServices.Ogc.Wmc.BoundingBox mapBbox = null;
            double mapScale = 0;
            int featureCount = int.MaxValue;

            if (parameters[OgcParameters.Service] == GeospatialServices.Ogc.Common.ServiceNames.WFS.ToString())
            {
                if (parameters[WfsParameters.SrsName] != null)
                {
                    srs = parameters[WfsParameters.SrsName];
                }

                if (parameters[WmsParameters.Bbox] != null)
                {
                    mapBbox = new GeospatialServices.Ogc.Wmc.BoundingBox(parameters[WmsParameters.Bbox], OgcUtilities.GetSridFromCrs(srs));
                }

                if (parameters[WfsParameters.MaxFeatures] != null)
                {
                    featureCount = int.Parse(parameters[WfsParameters.MaxFeatures]);
                }
            }
            else // WMS
            {
                //if (parameters[WmsParameters.Crs] != null)
                //{
                //    srs = parameters[WmsParameters.Crs];
                //}

                //if (parameters[WmsParameters.I] != null && parameters[WmsParameters.J] != null)
                //{
                //    float x = float.Parse(parameters[WmsParameters.I]);
                //    float y = float.Parse(parameters[WmsParameters.J]);

                //    SharpMapLib.Map map = new SharpMapLib.Map(new System.Drawing.Size(int.Parse(parameters[WmsParameters.Width]), int.Parse(parameters[WmsParameters.Height])));
                //    SharpMapGeometries.BoundingBox tempBbox = SharpMapWeb.Wms.WmsServer.ParseBBOX(parameters[WmsParameters.Bbox]);
                //    map.ZoomToBox(tempBbox);

                //    // Calculate the Map Scale for filtering out layers that are not visible
                //    // in the current map scale
                //    mapScale = map.Zoom * (6378137 * 2 * Math.PI) / (map.Size.Width * 0.00028 * 360);

                //    // Keep a dictionary of queried layer groups and associated bounding boxes
                //    // after adjusting for the layer group buffers passed in
                //    if (parameters[Sdi.Ogc.Common.OgcExtendedParameters.Buffers] != null)
                //    {
                //        int buffer = 0;
                //        layerGroupBboxs = new Dictionary<string, SharpMapGeometries.BoundingBox>();
                //        string[] queryLayerGroups = parameters[WmsParameters.QueryLayers].Split(new char[] { ',' });
                //        string[] buffers = parameters[OgcExtendedParameters.Buffers].Split(new char[] { ',' });

                //        for (int i = 0; i < queryLayerGroups.Length; i++)
                //        {
                //            if (int.TryParse(buffers[i], out buffer))
                //            {
                //                tempBbox = new global::SharpMap.Geometries.BoundingBox(map.ImageToWorld(new System.Drawing.PointF(x - buffer, y + buffer)), map.ImageToWorld(new System.Drawing.PointF(x + buffer, y - buffer)));
                //                layerGroupBboxs.Add(queryLayerGroups[i], tempBbox);
                //            }
                //        }
                //    }
                //}

                if (parameters[WmsParameters.FeatureCount] != null)
                {
                    featureCount = int.Parse(parameters[WmsParameters.FeatureCount]);
                }
            }

            if (mapBbox == null)
            {
                if (context.General.BoundingBox != null)
                {
                    mapBbox = context.General.BoundingBox;
                }
                else
                {
                    throw new WmsFault(WmsExceptionCode.InvalidFormat, "Bounding box not found");
                }
            }

            //bool excludeGmlFeatures = (!String.IsNullOrEmpty(parameters[OgcExtendedParameters.ExcludeGmlFeatures]) &&
            //                            parameters[OgcExtendedParameters.ExcludeGmlFeatures].ToLowerInvariant() == "true") ? true : false;
            bool excludeGmlFeatures = false;

            foreach (GeospatialServices.Ogc.Wmc.Layer wmcLayer in context.Layers)
            {
                if (mapScale != 0)
                {
                    // The layer is not visible at this map scale
                    //      if (wmsLayer.MinScaleDenominatorSpecified && mapScale < wmsLayer.MinScaleDenominator) 
 //                                   continue;
                    //      if (wmsLayer.MaxScaleDenominatorSpecified && mapScale >= wmsLayer.MaxScaleDenominator) 
                    //              continue;
                }

                Feature feature = null;
                XmlDocument document = new XmlDocument();
                XmlElement element = null;
                XmlNode node = null;
                XmlAttribute attribute = null;
                FeatureDataRow featureDataRow = null;

                GeospatialServices.Runtime.FeatureDataSet featureDataSet = new GeospatialServices.Runtime.FeatureDataSet();
                wmcLayer.ExecuteSpatialQuery(mapBbox.ToSqlGeometry, featureDataSet);

                if (featureDataSet != null)
                {
                    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

                    namespaces.Add(Declarations.Wfs110Prefix, Declarations.Wfs110NameSpace);
                    namespaces.Add(Declarations.DefaultPrefix, Declarations.DefaultNameSpace);
                    namespaces.Add(Declarations.WmsPrefix, Declarations.WmsNameSpace);
                    namespaces.Add(Declarations.OgcPrefix, Declarations.OgcNameSpace);
                    namespaces.Add(Declarations.GmlPrefix, Declarations.GmlNameSpace);
                    namespaces.Add(Declarations.GmlSfPrefix, Declarations.GmlSfNameSpace);
                    namespaces.Add(Declarations.XlinkPrefix, Declarations.XlinkNameSpace);

                    XmlSerializer serializer = new XmlSerializer(typeof(SfGeometry), Declarations.GmlSfNameSpace);

                    SfGeometry sfGeometry = null;
                    AbstractGML gml = null;
                    MemoryStream stream = null;
                    XmlDocument featueDocument = null;
                    string featureNameElement = wmcLayer.Name;

                    int totalFeatures = 0;
                    if (featureDataSet.Tables.Count > 0)
                    {
                        totalFeatures = Math.Min(featureDataSet.Tables[0].Count, featureCount);
                    }

                    for (int i = 0; i < totalFeatures; i++)
                    {
                        featureDataRow = featureDataSet.Tables[0][i];

                        feature = new Feature();
                        this.FeatureMemberList.Add(feature);

                        element = document.CreateElement(Declarations.GmlSfPrefix, featureNameElement, Declarations.GmlSfNameSpace);
                        feature.ElementList.Add(element);

                        attribute = document.CreateAttribute(Declarations.GmlPrefix, "id", Declarations.GmlNameSpace);
                        element.Attributes.Append(attribute);

                        attribute.Value = "id" + Guid.NewGuid().ToString();     //TODO: not correct, guids should be 'static'

                        // add the attributes
                        foreach (DataColumn featureDataColumn in featureDataSet.Tables[0].Columns)
                        {
                            node = document.CreateNode(XmlNodeType.Element, Declarations.GmlSfPrefix, featureDataColumn.ColumnName, Declarations.GmlSfNameSpace);
                            element.AppendChild(node);
                            node.InnerText = featureDataRow[featureDataColumn.ColumnName].ToString().Trim();
                        }

                        // add the layer Title
                        node = document.CreateNode(XmlNodeType.Element, Declarations.GmlSfPrefix, "LayerTitle", Declarations.GmlSfNameSpace);
                        element.AppendChild(node);
                        node.InnerText = wmcLayer.Title;

                        // only include the gml features if requested
                        if (!excludeGmlFeatures)
                        {
                            node = document.CreateNode(XmlNodeType.Element, Declarations.GmlSfPrefix, "sfElement", Declarations.GmlSfNameSpace);
                            element.AppendChild(node);
                            gml = AbstractGML.GetFromSqlGeometry(featureDataRow.Geometry);
                            sfGeometry = new SfGeometry(gml);
                            stream = new MemoryStream();
                            serializer.Serialize(stream, sfGeometry, namespaces);
                            stream.Position = 0;
                            featueDocument = new XmlDocument();
                            featueDocument.Load(stream);
                            node.InnerXml = featueDocument.DocumentElement.InnerXml;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the Aggregate Schema associated with the GML objects served by the WMS/WFS Servers
        /// </summary>
        /// <param name="WmsLayer"></param>
        /// <returns></returns>
        public static XmlSchema GetFeatureSchema(ViewContext context, bool includeGMLBaseReference)
        {
            XmlSchema schema = new XmlSchema();

            schema.Version = "1.0.0";
            schema.Namespaces.Add(Declarations.Wfs100DefaultPrefix, Declarations.Wfs100DefaultNameSpace);
            schema.Namespaces.Add(Declarations.DefaultPrefix, Declarations.DefaultNameSpace);
            schema.Namespaces.Add(Declarations.GmlPrefix, Declarations.GmlNameSpace);
            schema.Namespaces.Add(Declarations.GmlSfPrefix, Declarations.GmlSfNameSpace);
            schema.Namespaces.Add(Declarations.XlinkPrefix, Declarations.XlinkNameSpace);
            schema.TargetNamespace = Declarations.DefaultNameSpace;
            schema.ElementFormDefault = XmlSchemaForm.Qualified;

            XmlSchemaImport schemaImport = new XmlSchemaImport();
            schema.Includes.Add(schemaImport);
            schemaImport.Namespace = Declarations.GmlNameSpace;
            schemaImport.SchemaLocation = Declarations.GmlSchemaLocation;

            schemaImport = new XmlSchemaImport();
            schema.Includes.Add(schemaImport);
            schemaImport.Namespace = Declarations.GmlSfNameSpace;
            schemaImport.SchemaLocation = Declarations.GmlSfLevelsSchemaLocation;

            XmlSchemaElement schemaElement = null;
            XmlSchemaComplexType schemaComplexType = null;
            XmlSchemaComplexContent schemaComplexContent = null;
            XmlSchemaComplexContentExtension schemaComplexContentExtension = null;
            XmlSchemaSequence schemaSequence = null;
            XmlDocument document = null;

            if (includeGMLBaseReference)
            {

                XmlSchemaAnnotation schemaAnnotation = new XmlSchemaAnnotation();
                schema.Items.Add(schemaAnnotation);
                XmlSchemaAppInfo appInfo = new XmlSchemaAppInfo();
                schemaAnnotation.Items.Add(appInfo);
                appInfo.Source = Declarations.GmlSfLevelsSchemaLocation;

                XmlNode[] markupNodes = new XmlNode[2];
                appInfo.Markup = markupNodes;

                document = new XmlDocument();
                markupNodes[0] = document.CreateNode(XmlNodeType.Element, "ComplianceLevel", Declarations.DefaultNameSpace);
                markupNodes[0].InnerText = "0";
                markupNodes[1] = document.CreateNode(XmlNodeType.Element, "GMLProfileSchema", Declarations.DefaultNameSpace);
                markupNodes[1].InnerText = Declarations.GmlSfProfileSchemaLocation;

                schemaElement = new XmlSchemaElement();
                schema.Items.Add(schemaElement);
                schemaElement.Name = "FeatureCollection";
                schemaElement.SchemaTypeName = new XmlQualifiedName("FeatureCollectionType", Declarations.DefaultNameSpace);
                schemaElement.SubstitutionGroup = new XmlQualifiedName("_GML", Declarations.GmlNameSpace);

                schemaComplexType = new XmlSchemaComplexType();
                schema.Items.Add(schemaComplexType);
                schemaComplexType.Name = "FeatureCollectionType";

                schemaComplexContent = new XmlSchemaComplexContent();
                schemaComplexType.ContentModel = schemaComplexContent;
                schemaComplexContentExtension = new XmlSchemaComplexContentExtension();
                schemaComplexContent.Content = schemaComplexContentExtension;
                schemaComplexContentExtension.BaseTypeName = new XmlQualifiedName("AbstractFeatureType", Declarations.GmlNameSpace);

                schemaSequence = new XmlSchemaSequence();
                schemaComplexContentExtension.Particle = schemaSequence;
                schemaSequence.MinOccurs = 0;
                schemaSequence.MaxOccursString = "unbounded";

                schemaElement = new XmlSchemaElement();
                schemaSequence.Items.Add(schemaElement);
                schemaElement.Name = "featureMember";

                schemaComplexType = new XmlSchemaComplexType();
                schemaElement.SchemaType = schemaComplexType;
                schemaSequence = new XmlSchemaSequence();
                schemaComplexType.Particle = schemaSequence;

                schemaElement = new XmlSchemaElement();
                schemaSequence.Items.Add(schemaElement);
                schemaElement.RefName = new XmlQualifiedName("_Feature", Declarations.GmlNameSpace);
            }

            string geometryPropertyType = string.Empty;
            string featureTypeName = string.Empty;
            FeatureDataRow thisFeature = null;

            foreach (GeospatialServices.Ogc.Wmc.Layer wmcLayer in context.Layers)
            {
                thisFeature = wmcLayer.GetFeatureDataRow(0);
                if (thisFeature != null)
                {
                    schemaElement = new XmlSchemaElement();
                    schema.Items.Add(schemaElement);
                    schemaElement.Name = wmcLayer.Name;

                    featureTypeName = wmcLayer.Name + "Type"; 

                    schemaElement.SchemaTypeName = new XmlQualifiedName(featureTypeName, Declarations.DefaultNameSpace);
                    schemaElement.SubstitutionGroup = new XmlQualifiedName("_Feature", Declarations.GmlNameSpace);

                    schemaComplexType = new XmlSchemaComplexType();
                    schema.Items.Add(schemaComplexType);
                    schemaComplexType.Name = featureTypeName;

                    schemaComplexContent = new XmlSchemaComplexContent();
                    schemaComplexType.ContentModel = schemaComplexContent;
                    schemaComplexContentExtension = new XmlSchemaComplexContentExtension();
                    schemaComplexContent.Content = schemaComplexContentExtension;
                    schemaComplexContentExtension.BaseTypeName = new XmlQualifiedName("AbstractFeatureType", Declarations.GmlNameSpace);

                    schemaSequence = new XmlSchemaSequence();
                    schemaComplexContentExtension.Particle = schemaSequence;

                    XmlSchemaSimpleType schemaSimpleType = null;
                    XmlSchemaMaxLengthFacet maxLengthFacet = null;

                    foreach (DataColumn thisColumn in thisFeature.Table.Columns)
                    {
                        schemaElement = new XmlSchemaElement();
                        schemaSequence.Items.Add(schemaElement);

                        schemaElement.Name = thisColumn.ColumnName;
                        schemaElement.MinOccurs = thisColumn.AllowDBNull ? 0 : 1;

                        schemaSimpleType = new XmlSchemaSimpleType();
                        schemaElement.SchemaType = schemaSimpleType;

                        XmlSchemaSimpleTypeRestriction schemaSimpleTypeRestriction = new XmlSchemaSimpleTypeRestriction();
                        schemaSimpleType.Content = schemaSimpleTypeRestriction;
                        schemaSimpleTypeRestriction.BaseTypeName = new XmlQualifiedName(OgcUtilities.GetGmlSfType(thisColumn), Declarations.XsNameSpace);

                        if (thisColumn.MaxLength > -1)
                        {
                            maxLengthFacet = new XmlSchemaMaxLengthFacet();
                            maxLengthFacet.Value = thisColumn.MaxLength.ToString();
                            schemaSimpleTypeRestriction.Facets.Add(maxLengthFacet);
                        }
                    }
                    // Geometry
                    schemaElement = new XmlSchemaElement();
                    schemaSequence.Items.Add(schemaElement);
                    schemaElement.Name = GMLDeclarations.GeometryFeatureElementName;
                    geometryPropertyType = OgcUtilities.GetGmlSfGeometricPropertyType(thisFeature.Geometry);
                    schemaElement.SchemaTypeName = new XmlQualifiedName(geometryPropertyType, Declarations.GmlNameSpace);
                    schemaElement.MinOccurs = 0;
                }
            }
            return schema;
        }
    }
}
