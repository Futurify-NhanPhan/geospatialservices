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
    [XmlType(TypeName = "Keywords", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class Keywords
    {
        public Keywords()
        {

        }
        
        private List<string> _KeywordList;

        [XmlElement(ElementName = "Keyword", Form = XmlSchemaForm.Qualified,Namespace =Declarations.OwsNameSpace,Type = typeof(string))]
        [DataMember] public List<string> KeywordList
        {
            get 
            {
                if (_KeywordList == null)
                {
                    _KeywordList = new List<string>();
                } 
                return _KeywordList;
            }
            set { _KeywordList = value; }
        }

        [XmlIgnore]
        [DataMember] 
        public bool TypeSpecified;

        private Code _Type;

        [XmlElement(ElementName = "Type", Type = typeof(Code), Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        [DataMember]
        public Code Type
        {
            get
            {
                if (_Type == null)
                {
                    _Type = new Code();
                    TypeSpecified = true;
                }
                return _Type; 
            }
            set { _Type = value; TypeSpecified = true; }
        }
    }
}
