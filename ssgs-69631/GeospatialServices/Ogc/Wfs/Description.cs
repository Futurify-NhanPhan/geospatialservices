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
    [XmlType(TypeName = "Description", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class Description
    {
        public Description()
        {

        }

        private string _Title;

        [XmlElement(ElementName = "Title", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Abstract;

        [XmlElement(ElementName = "Abstract", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string Abstract
        {
            get { return _Abstract; }
            set { _Abstract = value; }
        }

        [XmlIgnore]
        [DataMember]
        public bool KeywordsSpecified;

        private Keywords _Keywords;

        [XmlElement(ElementName = "Keywords", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(Keywords))]
        [DataMember]
        public Keywords Keywords
        {
            get
            {
                if (_Keywords == null)
                {
                    _Keywords = new Keywords();
                    KeywordsSpecified = true;
                }
                return _Keywords;
            }
            set { _Keywords = value; KeywordsSpecified = true; }
        }
    }
}
