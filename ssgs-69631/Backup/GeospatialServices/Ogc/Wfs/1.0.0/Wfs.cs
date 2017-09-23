using System;
using System.Xml.Serialization;
namespace GeospatialServices.Ogc.Wfs_1_0_0
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
    public enum ArithmeticOperatorTypes
    {
        [XmlEnum(Name = "Simple_Arithmetic")]
        Simple_Arithmetic,
        [XmlEnum(Name = "Functions")]
        Functions
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
