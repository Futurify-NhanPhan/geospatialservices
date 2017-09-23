using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlType(TypeName = "MultiGeometryProperty", Namespace = Declarations.GmlNameSpace), Serializable]
    [DataContract]
    public partial class MultiGeometryProperty
    {
        public MultiGeometryProperty()
        {
        }

        public MultiGeometryProperty(AbstractGeometricAggregate item)
        {
            _Item = item;
        }

        private AbstractGeometricAggregate _Item;

        [XmlElement("MultiPoint", typeof(MultiPoint),Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("MultiCurve", typeof(MultiCurve), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("MultiSurface", typeof(MultiSurface), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        [XmlElement("MultiGeometry", typeof(MultiGeometry), Namespace = Declarations.GmlNameSpace, Form = XmlSchemaForm.Qualified)]
        public AbstractGeometricAggregate Item
        {
            get {return _Item;   }
            set { _Item = value; }
        }
    }

}
