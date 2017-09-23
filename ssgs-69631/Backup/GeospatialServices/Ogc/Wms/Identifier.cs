using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms
{
    [DataContract]
    [XmlType(TypeName = "Identifier", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class Identifier
    {
        public Identifier()
        {
        }

        public Identifier(string authority, string value)
        {
            _Authority = authority;
            _Value = value; 
        }
        
        private string _Authority;

        [XmlAttribute(AttributeName = "authority", DataType = "string")]
        [DataMember] 
        public string Authority
        {
            get { return _Authority; }
            set { _Authority = value;}
        }

        private string _Value;

        [XmlText(DataType = "string")]
        [DataMember]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }
}
