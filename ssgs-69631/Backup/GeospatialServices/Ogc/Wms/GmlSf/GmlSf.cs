using System;
using System.Xml.Serialization;
namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [Serializable]
    public enum SurfaceInterpolationType
    {
        [XmlEnum(Name = "planar")]
        planar
    }

    [Serializable]
    public enum CurveInterpolationType
    {
        [XmlEnum(Name = "linear")]
        linear
    }


    

}
