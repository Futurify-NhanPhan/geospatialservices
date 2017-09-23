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
    [XmlType(TypeName = "BoundingShape", Namespace = Declarations.GmlNameSpace  ), Serializable]
    public partial class BoundingShape
    {
        private Envelope _Envelope;

        [XmlElement(ElementName = "Envelope", Type = typeof(Envelope), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember] 
        public Envelope Envelope
        {
            get
            {
                if (_Envelope == null)
                {
                    _Envelope = new Envelope(); 
                }
                return _Envelope;
            }
            set
            {
                _Envelope = value;
            }
        }
    }
}