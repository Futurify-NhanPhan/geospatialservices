using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [DataContract]
    [XmlType(TypeName = "Point", Namespace = Declarations.GmlNameSpace ), Serializable]
    public partial class Point : AbstractGeometricPrimitive
    {

        private DirectPosition _Pos;

        [XmlElement(ElementName = "pos", Type = typeof(DirectPosition), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember]
        public DirectPosition Pos
        {
            get
            {
                if (_Pos == null)
                {
                    _Pos = new DirectPosition();
                }
                return _Pos;
            }
            set { _Pos = value; }
        }
    }
}
