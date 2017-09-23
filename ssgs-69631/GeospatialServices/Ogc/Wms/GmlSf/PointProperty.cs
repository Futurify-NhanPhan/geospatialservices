using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlType(TypeName = "PointProperty", Namespace = Declarations.GmlNameSpace), Serializable]
    [DataContract]
    public partial class PointProperty
    {
        public PointProperty()
        {
        }

        public PointProperty(Point item)
        {
            _Item = item; 
        }

        private Point _Item;

        [XmlElement(ElementName = "Point", Type = typeof(Point), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        public Point Point
        {
            get
            {
                if (_Item == null)
                {
                    _Item = new Point(); 
                }
                return _Item; 
            }
            set { _Item = value; }
        }
    }

}
