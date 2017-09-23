using System;
using System.Xml.Serialization;

namespace GeospatialServices.Ogc.Wms
{
    
    public struct GMLDeclarations
    {
        public const string Version = "1.0.0";
        public const string GeometryFeatureElementName = "SfGeometry"; 
    }

    public struct MapLimits
    {
        public const int MaxMapHeight = 0;
        public const int MaxMapWidth  = 0;
        public const int MaxMapLayers = 0;
    }

    public struct BBoxLimits
    {
        public const int MinX = -768;
        public const int MinY = -1024;
        public const int MaxX = 768;
        public const int MaxY = 1024;
    }
    
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
    public enum WmsExceptionCode
    {
        [XmlEnum(Name = "InvalidFormat")]
        InvalidFormat,

        [XmlEnum(Name = "InvalidCRS")]
        InvalidCRS,

        [XmlEnum(Name = "LayerNotDefined")]
        LayerNotDefined,

        [XmlEnum(Name = "StyleNotDefined")]
        StyleNotDefined,

        [XmlEnum(Name = "LayerNotQueryable")]
        LayerNotQueryable,

        [XmlEnum(Name = "InvalidPoint")]
        InvalidPoint,

        [XmlEnum(Name = "CurrentUpdateSequence")]
        CurrentUpdateSequence,

        [XmlEnum(Name = "InvalidUpdateSequence")]
        InvalidUpdateSequence,

        [XmlEnum(Name = "MissingDimensionValue")]
        MissingDimensionValue,

        [XmlEnum(Name = "InvalidDimensionValue")]
        InvalidDimensionValue,

        [XmlEnum(Name = "OperationNotSupported")]
        OperationNotSupported,

        [XmlEnum(Name = "NotApplicable")]
        NotApplicable
        
    }
}
