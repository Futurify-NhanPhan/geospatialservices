using System;
using System.Xml.Serialization;
namespace GeospatialServices.Ogc.Wfs
{

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
    public enum OperationType
    {
        [XmlEnum(Name = "Insert")]
        Insert,
        [XmlEnum(Name = "Update")]
        Update,
        [XmlEnum(Name = "Delete")]
        Delete,
        [XmlEnum(Name = "Query")]
        Query,
        [XmlEnum(Name = "Lock")]
        Lock,
        [XmlEnum(Name = "GetGmlObject")]
        GetGmlObject,
    }

    [Serializable]
    public enum SRSTypes
    {
        [XmlEnum(Name = "DefaultSRS")]
        DefaultSRS,
        [XmlEnum(Name = "NoSRS")]
        NoSRS,
        [XmlEnum(Name = "OtherSRS")]
        OtherSRS
    }

    [Serializable]
    public enum IdTypes
    {
        [XmlEnum(Name = "EID")]
        EID,
        [XmlEnum(Name = "FID")]
        FID
    }


    [Serializable]
    public enum ComparisonOperatorTypes
    {

        [XmlEnum(Name = "LessThan")]
        LessThan,
        [XmlEnum(Name = "GreaterThan")]
        GreaterThan,
        [XmlEnum(Name = "LessThanEqualTo")]
        LessThanEqualTo,
        [XmlEnum(Name = "GreaterThanEqualTo")]
        GreaterThanEqualTo,
        [XmlEnum(Name = "EqualTo")]
        EqualTo,
        [XmlEnum(Name = "NotEqualTo")]
        NotEqualTo,
        [XmlEnum(Name = "Like")]
        Like,
        [XmlEnum(Name = "Between")]
        Between,
        [XmlEnum(Name = "NullCheck")]
        NullCheck,
    }

    [Serializable]
    public enum WfsExceptionCode
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

        [XmlEnum(Name = "InvalidFormat")]
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
