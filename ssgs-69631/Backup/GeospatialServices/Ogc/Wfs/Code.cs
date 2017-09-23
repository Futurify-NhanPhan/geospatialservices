using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{

    [DataContract]
    [XmlType(TypeName = "Code", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class Code
    {
        public Code()
        {
            
        }

        public Code(string value)
        {
            this.Value  = value;
        }


        private string _CodeSpace;

        [DataMember]
        [XmlAttribute(AttributeName = "codeSpace", DataType = "anyURI", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        public string CodeSpace
        {
            get { return _CodeSpace; }
            set { _CodeSpace = value; }
        }


        private string _Value;

        [XmlText(DataType = "string")]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
        
}
