using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Web;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{
    [DataContract]
    [XmlType(TypeName = "Exception", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class Exception
    {

        public Exception()
        {
        }

        public Exception(WfsExceptionCode code, string exceptionText)
        {
            _Code = code;
            ExceptionTextList.Add(exceptionText);
        }

        private WfsExceptionCode _Code;
        [XmlAttribute(AttributeName = "code")]
        [DataMember]
        public WfsExceptionCode Code
        {
            get { return _Code; }
            set { _Code = value; }
        }


        private string _Locator;

        [XmlAttribute(AttributeName = "locator", DataType = "string")]
        [DataMember]
        public string Locator
        {
            get { return _Locator; }
            set { _Locator = value; }
        }


        [XmlIgnore]
        [DataMember]
        public bool ExceptionTextListSpecified;

        private List<string> _ExceptionTextList;

        [XmlElement(ElementName = "ExceptionText", Form = XmlSchemaForm.Unqualified,Type = typeof(string))]
        [DataMember]
        public List<string> ExceptionTextList
        {
            get
            {
                if (_ExceptionTextList == null)
                {
                    _ExceptionTextList = new List<string>();
                    ExceptionTextListSpecified = true;
                }
                return _ExceptionTextList;
            }
            set { _ExceptionTextList = value; ExceptionTextListSpecified = true; }
        }


    }
}