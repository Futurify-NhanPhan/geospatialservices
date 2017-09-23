using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.ComponentModel;

namespace GeospatialServices.Ogc.Common
{

    public struct Declarations
    {
        public const string DefaultNameSpace = "http://tempuri.org/mapcontext";
        public const string DefaultPrefix = "";
        public const string DefaultSchemaName = "default.xsd";
        public const string SldNameSpace = "http://www.opengis.net/sld";
        public const string SldPrefix = "sld";
        public const string SeNameSpace = "http://www.opengis.net/se";
        public const string SePrefix = "se";
        public const string OgcNameSpace = "http://www.opengis.net/ogc";
        public const string OgcPrefix = "ogc";
        public const string XlinkNameSpace = "http://www.w3.org/1999/xlink";
        public const string XlinkPrefix = "xlink";
        public const string WmsNameSpace = "http://www.opengis.net/wms";
        public const string WmsPrefix = "";
        public const string GmlNameSpace = "http://www.opengis.net/gml";
        public const string GmlPrefix = "gml";
        public const string GmlSchemaLocation = "http://schemas.opengis.net/gml/3.1.1/base/gml.xsd";
        public const string GmlSfNameSpace = "http://www.opengis.net/gmlsf";
        public const string GmlSfPrefix = "gmlsf";
        public const string XsPrefix = "xs";
        public const string XsNameSpace = "http://www.w3.org/2001/XMLSchema";
        public const string GmlSfLevelsSchemaLocation = "http://schemas.opengis.net/gml/3.1.1/profiles/gmlsfProfile/1.0.0/gmlsfLevels.xsd";
        public const string GmlSfSchemaLocation = "http://schemas.opengis.net/gml/3.1.1/profiles/gmlsfProfile/1.0.0/gmlsf.xsd";
        public const string GmlSfProfileSchemaLocation = "http://schemas.opengis.net/gml/3.1.1/profiles/gmlsfProfile/1.0.0/gmlsf.xsd";
        public const string OwsNameSpace = @"http://www.opengis.net/ows";
        public const string OwsPrefix = "ows";
        public const string GMLSFFormat = @"text/xml; subtype=gml/3.1.1";
        public const string Wfs100NameSpace = @"http://www.opengis.net/wfs/1_0_0";
        public const string Wfs100Prefix = "wfs";
        public const string Wfs110NameSpace = "http://www.opengis.net/wfs";
        public const string Wfs110Prefix = "wfs";
        public const string Wfs100DefaultNameSpace = @"http://www.opengis.net/wfs100";
        public const string Wfs100DefaultPrefix = "";
        public const string Wfs110DefaultNameSpace = "http://www.opengis.net/wfs";
        public const string Wfs110DefaultPrefix = "";


    }

    [Serializable]
    public enum ServiceNames
    {
        [XmlEnum(Name = "OGC:WMS")]
        WMS,
        [XmlEnum(Name = "OGC:WFS")]
        WFS
    };

    [Serializable]
    public enum ShowTypes
    {
        [XmlEnum(Name = "new")]
        @new,
        [XmlEnum(Name = "replace")]
        replace,
        [XmlEnum(Name = "embed")]
        embed,
        [XmlEnum(Name = "other")]
        other,
        [XmlEnum(Name = "none")]
        none
    }

    [Serializable]
    public enum ActuateTypes
    {
        [XmlEnum(Name = "onLoad")]
        onLoad,
        [XmlEnum(Name = "onRequest")]
        onRequest,
        [XmlEnum(Name = "other")]
        other,
        [XmlEnum(Name = "none")]
        none
    }

    [Serializable]
    public enum EncodingTypes
    {
        [XmlEnum(Name = "Xml")]
        Xml,
        [XmlEnum(Name = "Base64")]
        Base64
    };

    [Serializable]
    public enum OverlapBehaviourTypes
    {
        [XmlEnum(Name = "LATEST_ON_TOP")]
        LatestOnTop,
        [XmlEnum(Name = "EARLIEST_ON_TOP")]
        EarliestOnTop,
        [XmlEnum(Name = "AVERAGE")]
        Average,
        [XmlEnum(Name = "RANDOM")]
        Random
    }

    [Serializable]
    public enum SymbolizerTypes
    {
        PointSymbolizer,
        LineSymbolizer,
        PolygonSymbolizer,
        RasterSymbolizer,
        TextSymbolizer
    }

    [Serializable]
    public enum FilterTypes
    {
        [XmlEnum(Name = "SpatialOps")]
        SpatialOps,
        [XmlEnum(Name = "PropertyIsBetween")]
        PropertyIsBetween,
        [XmlEnum(Name = "PropertyIsEqualTo")]
        PropertyIsEqualTo,
        [XmlEnum(Name = "PropertyIsGreaterThan")]
        PropertyIsGreaterThan,
        [XmlEnum(Name = "PropertyIsGreaterThanOrEqualTo")]
        PropertyIsGreaterThanOrEqualTo,
        [XmlEnum(Name = "PropertyIsLessThan")]
        PropertyIsLessThan,
        [XmlEnum(Name = "PropertyIsLessThanOrEqualTo")]
        PropertyIsLessThanOrEqualTo,
        [XmlEnum(Name = "PropertyIsLike")]
        PropertyIsLike,
        [XmlEnum(Name = "PropertyIsNotEqualTo")]
        PropertyIsNotEqualTo,
        [XmlEnum(Name = "PropertyIsNull")]
        PropertyIsNull,
        [XmlEnum(Name = "_Id")]
        _Id
    }

    //Ogc Common Parameters
    public struct OgcParameters
    {
        public const string Service = "SERVICE";
        public const string Request = "REQUEST";
        public const string Version = "VERSION";
    }

        // WMS Parameters
    public struct WmsParameters
    {
        public const string Format = "FORMAT";
        public const string Width = "WIDTH";
        public const string Height = "HEIGHT";
        public const string Bbox = "BBOX";
        public const string Layers = "LAYERS";
        public const string Styles = "STYLES";
        public const string BgColor = "BGCOLOR";
        public const string Transparent = "TRANSPARENT";
        public const string Crs = "CRS";
        public const string SldBody = "SLD_BODY";
        public const string QueryLayers = "QUERY_LAYERS";
        public const string I = "I";
        public const string J = "J";
        public const string FeatureCount = "FEATURE_COUNT";
        public const string InfoFormat = "INFO_FORMAT";
        public const string LayerKey = "LAYERKEY";

        //GetLegendGraphic Specific parameters
        public const string Layer = "LAYER";
        public const string Style = "STYLE";
        public const string Scale = "SCALE";
    }

    // WFS Parameters
    public struct WfsParameters
    {
        public const string TypeName = "TYPENAME";
        public const string SrsName = "SRSNAME";
        public const string MaxFeatures = "MAXFEATURES";
        public const string OutputFormat = "OUTPUTFORMAT";
    }

    public class OgcErrorMessages
    {
        public static string RequiredParameter(string parameter)
        {
            return String.Format("Required parameter {0} not specified", parameter);
        }
    }

}
