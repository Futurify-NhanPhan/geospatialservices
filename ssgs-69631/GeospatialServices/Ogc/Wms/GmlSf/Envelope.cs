using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlType(TypeName = "Envelope", Namespace = Declarations.GmlNameSpace  ), Serializable]
    [DataContract]
    public partial class Envelope
    {

        private string _srsName;

        [XmlAttribute(AttributeName = "srsName", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string srsName
        {
            get {return _srsName;}
            set { _srsName = value;}
        }


        private DirectPosition _LowerCorner;

        [XmlElement(ElementName = "lowerCorner", Type = typeof(DirectPosition), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember]
        public DirectPosition LowerCorner
        {
            get
            {
                if (_LowerCorner == null)
                {
                    _LowerCorner = new DirectPosition(); 
                }
                return _LowerCorner;
            }
            set{_LowerCorner = value; }
        }

        private DirectPosition _UpperCorner;

        [XmlElement(ElementName = "upperCorner", Type = typeof(DirectPosition), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember]
        public DirectPosition UpperCorner
        {
            get
            {
                if (_UpperCorner == null)
                {
                    _UpperCorner = new DirectPosition();
                }
                return _UpperCorner;
            }
            set { _UpperCorner = value; }
        }



    }
}
