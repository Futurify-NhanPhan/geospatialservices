using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using System.Xml.Serialization;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Specialized;
using System.Xml;
using GeospatialServices.Ogc.Common;
using GeospatialServices.Ogc.Wfs;
using GeospatialServices.Ogc.Wms.GmlSf;
using GeospatialServices.Ogc.Wmc;
using System.Diagnostics;
using System.Xml.Schema;
using GeospatialServices.Runtime;

namespace GeospatialServices.Web.OgcServices
{

    /// <summary>
    /// OGC Web Feature Server
    /// </summary>
    public class WfsService : IHttpHandler, IRequiresSessionState
    {
        #region IHttpHandler Interface Members
        public bool IsReusable
        {
            get
            {
                return (true);
            }
        }  // IsReusable	

        /// <summary>
        /// Handles WFS Requests
        /// </summary>
        /// <param name="context"></param>
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
                        case "getcapabilities":
                            ProcessGetCapabilities(context.Response, parameters);
                            break;
                        case "describefeaturetype":
                            ProcessDescribeFeatureType(context.Response, parameters);
                            break;
                        case "getfeature":
                            ProcessGetFeature(context.Response, parameters);
                            break;
                        default:
                            SetResponseToServiceException(context.Response, "Invalid REQUEST specified for WFS");
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    throw (ex);
                }
            }
        }

        /// <summary>
        /// Verify required OGC parameters have been supplied return the request parameter
        /// </summary>
        private string GetOgcRequest(HttpResponse response, StringDictionary parameters)
        {
            if (String.IsNullOrEmpty(parameters[OgcParameters.Service]))
            {
                SetResponseToServiceException(response, OgcErrorMessages.RequiredParameter(OgcParameters.Service));
                return null;
            }

            if (String.Compare(parameters[OgcParameters.Service], ServiceNames.WFS.ToString()) != 0)
            {
                SetResponseToServiceException(response, "Invalid service. Service parameter must be 'WFS'");
                return null;
            }

            string request = parameters[OgcParameters.Request];

            if (String.IsNullOrEmpty(request))
            {
                SetResponseToServiceException(response, OgcErrorMessages.RequiredParameter(OgcParameters.Request));
                return null;
            }

            if (String.IsNullOrEmpty(parameters[OgcParameters.Version]))
            {
                SetResponseToServiceException(response, OgcErrorMessages.RequiredParameter(OgcParameters.Version));
                return null;
            }

            if (String.Compare(request, "GetCapabilities") != 0 && String.Compare(parameters[OgcParameters.Version], "1.1.0") != 0)
            {
                SetResponseToServiceException(response, "Invalid VERSION for Request. Only 1.1.0 and 1.0.0 (GetCapabilities) supported");
                return null;
            }

            return request;
        }

        #endregion

        #region OGC WFS Operations

        /// <summary>
        /// OGC WFS GetCapabilities (1.0.0 and 1.1.0)
        /// </summary>
        /// <param name="context"></param>
        private void ProcessGetCapabilities(HttpResponse response, StringDictionary parameters)
        {
            switch (parameters[OgcParameters.Version])
            {
                case "1.0.0":
                    ProcessGetCapabilities_1_0_0(response, parameters);
                    break;
                case "1.1.0":
                    ProcessGetCapabilities_1_1_0(response, parameters);
                    break;
                default:
                    SetResponseToServiceException(response, "Invalid VERSION for Request. Only 1.1.0 and 1.0.0 (GetCapabilities) supported");
                    break;
            }
        }

        /// <summary>
        /// OGC WFS GetCapabilities 1.0.0
        /// </summary>
        /// <param name="context"></param>
        private void ProcessGetCapabilities_1_0_0(HttpResponse response, StringDictionary parameters)
        {
            // Get the WFS capabilities
            XmlSerializer deSerializer = new XmlSerializer(typeof(GeospatialServices.Ogc.Wfs_1_0_0.WFS_Capabilities), string.Empty);
            FileStream readStream = new FileStream(Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), "WFSCapabilities.xml"), FileMode.Open, FileAccess.Read);
            GeospatialServices.Ogc.Wfs_1_0_0.WFS_Capabilities wfsCapabilities = (GeospatialServices.Ogc.Wfs_1_0_0.WFS_Capabilities)deSerializer.Deserialize(readStream);
            readStream.Close();

            // Namespaces
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(Declarations.Wfs100DefaultPrefix, Declarations.Wfs100DefaultNameSpace);
            namespaces.Add(Declarations.Wfs100Prefix, Declarations.Wfs100NameSpace);
            namespaces.Add(Declarations.OgcPrefix, Declarations.OgcNameSpace);
            namespaces.Add(Declarations.XlinkPrefix, Declarations.XlinkNameSpace);


            // Serialize
            XmlSerializer serializer = new XmlSerializer(typeof(GeospatialServices.Ogc.Wfs_1_0_0.WFS_Capabilities));
            MemoryStream memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, wfsCapabilities, namespaces);

            byte[] buffer = memoryStream.ToArray();
            response.Clear();
            response.ContentType = "text/xml";
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// OGC WFS GetCapabilities 1.1.0
        /// </summary>
        /// <param name="context"></param>
        private void ProcessGetCapabilities_1_1_0(HttpResponse response, StringDictionary parameters)
        {
            // deserialise GetCapabilities document
            XmlSerializer deSerializer = new XmlSerializer(typeof(WFS_Capabilities), string.Empty);
            FileStream readStream = new FileStream(Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), "WFSCapabilities.xml"), FileMode.Open, FileAccess.Read);
            WFS_Capabilities wfsCapabilities = (WFS_Capabilities)deSerializer.Deserialize(readStream);
            readStream.Close();

            // Namespaces
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(Declarations.Wfs110DefaultPrefix, Declarations.Wfs110DefaultNameSpace);
            namespaces.Add(Declarations.Wfs110Prefix, Declarations.Wfs110NameSpace);
            namespaces.Add(Declarations.OwsPrefix, Declarations.OwsNameSpace);
            namespaces.Add(Declarations.OgcPrefix, Declarations.OgcNameSpace);
            namespaces.Add(Declarations.XlinkPrefix, Declarations.XlinkNameSpace);

            // Serialize
            XmlSerializer serializer = new XmlSerializer(typeof(GeospatialServices.Ogc.Wfs.WFS_Capabilities));
            MemoryStream memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, wfsCapabilities, namespaces);

            byte[] buffer = memoryStream.ToArray();
            response.Clear();
            response.ContentType = "text/xml";
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// OGC WFS DescribeFeatureType
        /// </summary>
        /// <param name="context"></param>
        private void ProcessDescribeFeatureType(HttpResponse response, StringDictionary parameters)
        {
            if (!String.IsNullOrEmpty(parameters[WfsParameters.OutputFormat]) && String.Compare(parameters[WfsParameters.OutputFormat], Declarations.GMLSFFormat) != 0)
            {
                SetResponseToServiceException(response, WfsExceptionCode.InvalidFormat, "Invalid OUTPUTFORMAT for DescribeFeatureType Request. Only " + Declarations.GMLSFFormat + "format is supported");
                return;
            }

            byte[] featureTypeBytes = null;

            // Check if this is a WFS or WMS request and get the appropriate layers parameter
            string layers = parameters[WfsParameters.TypeName];

            if (String.IsNullOrEmpty(layers))
                throw new WfsFault(WfsExceptionCode.LayerNotDefined);

            ViewContext context = new ViewContext(parameters);
            XmlSchema schema = FeatureCollection.GetFeatureSchema(context, false);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                schema.Write(memoryStream);
                featureTypeBytes = memoryStream.ToArray();
            }
            response.Clear();
            response.ContentType = "text/xml";
            response.OutputStream.Write(featureTypeBytes, 0, featureTypeBytes.Length);
        }

        /// <summary>
        ///  OGC WFS GetFeature
        /// </summary>
        /// <param name="context"></param>
        private void ProcessGetFeature(HttpResponse response, StringDictionary parameters)
        {
            if (!String.IsNullOrEmpty(parameters[WfsParameters.OutputFormat]) && String.Compare(parameters[WfsParameters.OutputFormat], Declarations.GMLSFFormat) != 0)
            {
                SetResponseToServiceException(response, WfsExceptionCode.InvalidFormat, "Invalid OUTPUTFORMAT for GetFeature Request. Only " + Declarations.GMLSFFormat + "format is supported");
                return;
            }
            string layers = parameters[WfsParameters.TypeName];
            if (String.IsNullOrEmpty(layers))
                throw new WfsFault(WfsExceptionCode.LayerNotDefined);

            // get layer data into a FeatureCollection
            ViewContext context = new ViewContext(parameters);
            FeatureCollection featureCollection = new FeatureCollection(context, parameters);

            // serialise to XML
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(Declarations.Wfs110DefaultPrefix, Declarations.Wfs110DefaultNameSpace);
            namespaces.Add(Declarations.DefaultPrefix, Declarations.DefaultNameSpace);
            namespaces.Add(Declarations.Wfs110Prefix, Declarations.Wfs110NameSpace);
            namespaces.Add(Declarations.OgcPrefix, Declarations.OgcNameSpace);
            namespaces.Add(Declarations.GmlPrefix, Declarations.GmlNameSpace);
            namespaces.Add(Declarations.GmlSfPrefix, Declarations.GmlSfNameSpace);
            namespaces.Add(Declarations.XlinkPrefix, Declarations.XlinkNameSpace);
            response.Clear();
            response.ContentType = "text/xml";
            XmlWriter xmlWriter = XmlWriter.Create(response.OutputStream);
            XmlSerializer serializer = new XmlSerializer(typeof(FeatureCollection));
            MemoryStream xmlMemoryStream = new MemoryStream();
            serializer.Serialize(xmlMemoryStream, featureCollection, namespaces);
            xmlMemoryStream.Position = 0;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlMemoryStream);
            xmlDocument.WriteTo(xmlWriter);
            xmlWriter.Flush();
        }

        #endregion


        /// <summary>
        /// WMS Request to get the GML associated with the requested features
        /// </summary>
        //public FeatureCollection GetFeatureInfo(StringDictionary parameters)
        //{
        //    try
        //    {
        //        if (String.IsNullOrEmpty(parameters[WmsParameters.I])) // This should be I (MapInfo is issuing X)
        //            throw new FaultException<WmsFault>(new WmsFault(WmsExceptionCode.NotApplicable), OgcErrorMessages.RequiredParameter(WmsParameters.I));

        //        if (String.IsNullOrEmpty(parameters[WmsParameters.J])) // This should be J (MapInfo is issuing Y)
        //            throw new FaultException<WmsFault>(new WmsFault(WmsExceptionCode.NotApplicable), OgcErrorMessages.RequiredParameter(WmsParameters.J));

        //        CheckIsValidGetMapRequest(parameters);

        //        string layers = parameters[WmsParameters.QueryLayers];

        //        // WMS without Query Layers
        //        if (String.IsNullOrEmpty(layers))
        //            throw new FaultException<WmsFault>(new WmsFault(WmsExceptionCode.LayerNotDefined), OgcErrorMessages.RequiredParameter(WmsParameters.QueryLayers));

        //        List<Sdi.Ogc.Wms.Layer> sdiLayers = GetRequestedSdiLayers(layers.Split(new char[] { ',' }), ServiceTypes.WMS);

        //        return _wfsAdapter.GetFeatureGML(sdiLayers, parameters);
        //    }
        //    catch (FaultException)
        //    {
        //        throw; // unimportant error, do not log
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Trace.TraceError(ex.ToString());
        //        throw;
        //    }
        //}


        #region Exception Handling

        /// <summary>
        /// Populate the HttpResponse with a ServiceExceptionReport
        /// </summary>
        /// <param name="response"></param>
        /// <param name="message"></param>
        private void SetResponseToServiceException(HttpResponse response, string message)
        {
            SetResponseToServiceException(response, GeospatialServices.Ogc.Wfs.WfsExceptionCode.NotApplicable, message);
        }

        /// <summary>
        ///  Populate the HttpResponse with a ServiceExceptionReport
        /// </summary>
        /// <param name="response"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        private void SetResponseToServiceException(HttpResponse response, GeospatialServices.Ogc.Wfs.WfsExceptionCode code, string message)
        {
            GeospatialServices.Ogc.Wfs.ExceptionReport exceptionReport = new GeospatialServices.Ogc.Wfs.ExceptionReport();
            exceptionReport.ExceptionList.Add(new GeospatialServices.Ogc.Wfs.Exception(code, message));
            response.Clear();
            response.ContentType = "text/xml";

            // Namespaces
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(Declarations.Wfs110DefaultPrefix, Declarations.Wfs110DefaultNameSpace);
            namespaces.Add(Declarations.Wfs110Prefix, Declarations.Wfs110NameSpace);
            namespaces.Add(Declarations.OwsPrefix, Declarations.OwsNameSpace);
            namespaces.Add(Declarations.OgcPrefix, Declarations.OgcNameSpace);
            namespaces.Add(Declarations.XlinkPrefix, Declarations.XlinkNameSpace);

            // Serialize
            XmlSerializer serializer = new XmlSerializer(typeof(GeospatialServices.Ogc.Wfs.ExceptionReport));
            serializer.Serialize(response.OutputStream, exceptionReport, namespaces);
        }
        #endregion
    }
}