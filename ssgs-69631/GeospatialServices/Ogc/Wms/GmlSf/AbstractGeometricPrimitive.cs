using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    
    [XmlInclude(typeof(AbstractCurve))]
    [XmlInclude(typeof(LineString))]
    [XmlInclude(typeof(Curve))]
    [XmlInclude(typeof(Point))]
    [XmlInclude(typeof(AbstractSurface))]
    [XmlInclude(typeof(Polygon))]
    [XmlInclude(typeof(Surface))]
    [XmlType(TypeName = "AbstractGeometricPrimitive", Namespace = Declarations.GmlNameSpace ), Serializable]
    [DataContract]
    public abstract partial class AbstractGeometricPrimitive : AbstractGeometry 
    {

    }

}
