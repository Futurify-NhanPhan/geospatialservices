using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlInclude(typeof(LinearRing))]
    [XmlInclude(typeof(AbstractGeometricPrimitive))]
    [XmlInclude(typeof(AbstractCurve))]
    [XmlInclude(typeof(LineString))]
    [XmlInclude(typeof(Curve))]
    [XmlInclude(typeof(Point))]
    [XmlInclude(typeof(AbstractSurface))]
    [XmlInclude(typeof(Polygon))]
    [XmlInclude(typeof(Surface))]
    [XmlInclude(typeof(AbstractGeometricAggregate))]
    [XmlInclude(typeof(MultiSurface))]
    [XmlInclude(typeof(MultiCurve))]
    [XmlInclude(typeof(MultiPoint))]
    [XmlInclude(typeof(MultiGeometry))]
    [XmlType(TypeName = "AbstractGeometry", Namespace = Declarations.GmlNameSpace ), Serializable]
    [DataContract]
    public abstract partial class AbstractGeometry : AbstractGML 
    {

        private string _srsName;

        [XmlAttribute(AttributeName = "srsName", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string srsName
        {
            get { return _srsName; }
            set { _srsName = value; }
        }

    }

}
