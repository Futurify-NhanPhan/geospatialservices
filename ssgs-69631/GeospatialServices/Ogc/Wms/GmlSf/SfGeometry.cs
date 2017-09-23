using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlType(TypeName = "SfGeometry", Namespace = Declarations.DefaultNameSpace), Serializable]
    [DataContract]
    public partial class SfGeometry : AbstractGML 
    {
        public SfGeometry()
        {
        }
        public SfGeometry(AbstractGML item)
        {
            _Item = item;
        }

        private AbstractGML _Item;

        [XmlElement("AbstractFeatureBase", typeof(AbstractFeatureBase),Namespace=Declarations.GmlNameSpace,Form =XmlSchemaForm.Qualified)]
        [XmlElement("AbstractFeature", typeof(AbstractFeature), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("AbstractGeometry", typeof(AbstractGeometry), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("LinearRing", typeof(LinearRing), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("AbstractGeometricPrimitive", typeof(AbstractGeometricPrimitive), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("AbstractCurve", typeof(AbstractCurve), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("AbstractSurface", typeof(AbstractSurface), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("LineString", typeof(LineString), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("Curve", typeof(Curve), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("Point", typeof(Point), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("Polygon", typeof(Polygon), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("Surface", typeof(Surface), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("AbstractGeometricAggregate", typeof(AbstractGeometricAggregate), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("MultiSurface", typeof(MultiSurface), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("MultiCurve", typeof(MultiCurve),Namespace=Declarations.GmlNameSpace,Form =XmlSchemaForm.Qualified)]
        [XmlElement("MultiPoint", typeof(MultiPoint), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("MultiGeometry", typeof(MultiGeometry), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        public AbstractGML Item
        {
            get { return _Item; }
            set { _Item = value; }
        }
    }

}
