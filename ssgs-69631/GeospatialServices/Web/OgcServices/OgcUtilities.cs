using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;
using System.Configuration;
using System.IO;
using GeospatialServices.Ogc.Wmc;
using Microsoft.SqlServer.Types;
using System.Data;
using System.Xml.Linq;

/// <summary>
/// Summary description for OgcUtilities
/// </summary>
public class OgcUtilities
{

    /// <summary>
    ///  Populates a String Dictionary from the HttpRequest parameters
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static StringDictionary GetRequestParameters(HttpContext context)
    {
        StringDictionary dictionary = new StringDictionary();

        if (context.Request.RequestType == "GET")
        {
            for (int i = 0; i < context.Request.QueryString.Count; i++)
            {
                string key = context.Request.QueryString.Keys[i];

                if (IncludeKey(key, context))
                    dictionary.Add(key, context.Request.QueryString[i]);
            }
        }
        else if (context.Request.RequestType == "POST")
        {
            for (int i = 0; i < context.Request.Params.Count; i++)
            {
                string key = context.Request.Params.Keys[i];

                if(IncludeKey(key, context))
                    dictionary.Add(key, context.Request.Params[i]);
            }
        }

        return dictionary;
    }

    /// <summary>
    /// Filter non WMS/WMF parameters from the list
    /// </summary>
    private static bool IncludeKey(string key, HttpContext context)
    {
        bool include = true;

        if (context.Request.ServerVariables.AllKeys.Contains(key))
            include = false;
        else if (key.StartsWith("_"))
            include = false;
        else if (key.StartsWith("."))
            include = false;

        return include;

    }

    public static ViewContext GetViewContext()
    {
        // ensure viewcontext is in session
        if (System.Web.HttpContext.Current.Application["mapcontext"] == null)
        {
            string mapContextFile = ConfigurationSettings.AppSettings["MapContextFile"];
            XmlSerializer serializer = new XmlSerializer(typeof(ViewContext));
            FileStream readCtxStream = new FileStream(Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), mapContextFile), FileMode.Open, FileAccess.Read);
            ViewContext mapContext = (ViewContext)serializer.Deserialize(readCtxStream);
            readCtxStream.Close();

            EnsureConfigurationParameters(mapContext);
            System.Web.HttpContext.Current.Application["mapcontext"] = mapContext;
        }

        // get view context from session
        ViewContext webMapContext;
        if (System.Web.HttpContext.Current.Application["mapcontext"] != null)
            webMapContext = (ViewContext)System.Web.HttpContext.Current.Application["mapcontext"];
        else
        {
            throw new ArgumentException("The map context not available from asp.net application");
        }
        return webMapContext;
    }

    public static void EnsureConfigurationParameters(ViewContext context)
    {
        XDocument wfsConfig = XDocument.Load(Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), "WFSConfiguration.xml"));
        
        foreach (var featureType in wfsConfig.Descendants("FeatureTypeList"))
        {
            string name = "";
            string tableName = "";
            string geometryColumn = "";
            string featureIdColumn = "";
            string connection = "";

            foreach (XElement setting in featureType.Elements().Elements())
            {
                switch (setting.Name.LocalName)
                {
                    case "Name":
                        name = setting.Value;
                        break;
                    case "TableName":
                        tableName = setting.Value;
                        break;
                    case "GeometryColumn":
                        geometryColumn = setting.Value;
                        break;
                    case "FeatureIdColumn":
                        featureIdColumn = setting.Value;
                        break;
                    case "ConnectionString":
                        connection = setting.Value;
                        break;
                    default:
                        break;
                }
            }

            Layer target = context.Layers.Find(delegateLayer => delegateLayer.Name == name);
            if (target != null)
            {
                target.Table = tableName;
                target.GeometryColumn = geometryColumn;
                target.FeatureIdColumn = featureIdColumn;
                target.ConnectionString = connection;
            }
        }
    }
  

    /// <summary>
    /// Gets the GML SF Geometry Property Type 
    /// </summary>
    /// <param name="geometry"></param>
    /// <returns></returns>
    public static string GetGmlSfGeometricPropertyType(SqlGeometry geometry)
    {
        string sfType = string.Empty;
        string geomType = (string)geometry.STGeometryType();
        switch (geomType)
        {
            case "Point":
                {
                    sfType = "PointPropertyType";
                }
                break;
            case "Curve":
            case "LineString":
                {
                    sfType = "CurvePropertyType";
                }
                break;
            case "Surface":
            case "Polygon":
            case "LinearRing":
                {
                    sfType = "SurfacePropertyType";
                }
                break;
            case "Geometry":
                {
                    sfType = "GeometryPropertyType";
                }
                break;
            case "MultiCurve":
                {
                    sfType = "MultiCurvePropertyType";
                }
                break;
            case "MultiPoint":
                {
                    sfType = "MultiPointPropertyType";
                }
                break;
            case "MultiLineString":
            case "MultiPolygon":
            case "Point3D":
            case "MultiSurface":
                {
                    sfType = "MultiSurfacePropertyType";
                }
                break;
            case "GeometryCollection":
                {
                    sfType = "MultiGeometryPropertyType";
                }
                break;
            default:
                {
                    sfType = "Unknown";
                }
                break;
        }
        return sfType;
    }

    /// <summary>
    /// Get GML SF Basic Type Name
    /// </summary>
    /// <param name="dataColumn"></param>
    /// <returns></returns>
    public static string GetGmlSfType(DataColumn dataColumn)
    {
        string sfType = "";
        switch (dataColumn.DataType.ToString())
        {
            case "System.Int32":
                {
                    sfType = "integer";
                }
                break;
            case "System.Int64":
                {
                    sfType = "decimal";
                }
                break;
            case "System.Long":
                {
                    sfType = "long";
                }
                break;
            case "System.String":
                {
                    sfType = "string";
                }
                break;
            default:
                {
                    sfType = "unknown";
                }
                break;
        }
        return sfType;
    }


    /// <summary>
    /// returns a sql server srid integer from a OGC Crs value.
    /// </summary>
    /// <param name="crs"></param>
    /// <returns></returns>
    public static int GetSridFromCrs(string crs)
    {
        int srid = 0;

        if (crs == null)
            return srid;

        if (crs.ToLower() == "epsg:4326")
            return 4326;

        throw new ArgumentOutOfRangeException("Crs", crs, "Unsupported CRS value");
    }
}
