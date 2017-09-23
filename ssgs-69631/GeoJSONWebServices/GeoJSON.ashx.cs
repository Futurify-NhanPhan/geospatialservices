using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Globalization;
using System.IO.Compression;
using System.Configuration;
using Microsoft.SqlServer.Types;
using GeospatialServices.GeoJSON;

namespace GeoJSONWebServices
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GeoJSON : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // parse and decode http request
            System.IO.Stream body = context.Request.InputStream;
            System.Text.Encoding encoding = context.Request.ContentEncoding;
            System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            string s = reader.ReadToEnd();
            s = HttpUtility.UrlDecode(s);
            body.Close();
            reader.Close();

            //if (!System.Text.RegularExpressions.Regex.IsMatch(
            //        context.Request.QueryString["Name"], @"^[a-zA-Z'.\s]{1,40}$"))
            //    throw new ArgumentException("Invalid request parameter");

            //get geoprocessing method
            string geoMethod = context.Request["method"];
            string geoDataset = context.Request["dataset"];

            string json = null;

            if (geoMethod == "spatialquery")
            {
                string connection = global::System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                string provider = global::System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ProviderName;
                string sql = ConfigurationSettings.AppSettings[geoDataset];
                json = GeoJSONService.DatabaseRequest(s, connection, provider, sql);
            }

            if (geoMethod == "buffer")
            {
                json = GeoJSONService.GeoprocessingRequest(geoMethod, s);
            }

            // create response

            //Ajax Web Service request always starts with application/json to help prevent XSS attacks see Scott Gutheries blog on this
            if (context.Request.ContentType.ToLower(CultureInfo.InvariantCulture).StartsWith("application/json"))
            {
                //User may be using an older version of IE which does not support compression, so skip those
                if (!((context.Request.Browser.IsBrowser("IE")) && (context.Request.Browser.MajorVersion <= 6)))
                {
                    string acceptEncoding = context.Request.Headers["Accept-Encoding"];

                    if (!string.IsNullOrEmpty(acceptEncoding))
                    {
                        acceptEncoding = acceptEncoding.ToLower(CultureInfo.InvariantCulture);

                        if (acceptEncoding.Contains("gzip"))
                        {
                            context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
                            context.Response.AddHeader("Content-encoding", "gzip");
                        }
                        else if (acceptEncoding.Contains("deflate"))
                        {
                            context.Response.Filter = new DeflateStream(context.Response.Filter, CompressionMode.Compress);
                            context.Response.AddHeader("Content-encoding", "deflate");
                        }
                    }
                }
                context.Response.Write(json);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
