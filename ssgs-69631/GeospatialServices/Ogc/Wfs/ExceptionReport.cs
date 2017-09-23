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
    [XmlType(TypeName = "ExceptionReport", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class ExceptionReport
    {

        public ExceptionReport()
        {
            _Version = "1.1.0";
        }


        private string _Version;
        [XmlAttribute(AttributeName = "version")]
        [DataMember]
        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }


        private string _Lang;

        [XmlAttribute(AttributeName = "lang", DataType = "string")]
        [DataMember]
        public string Lang
        {
            get { return _Lang; }
            set { _Lang = value; }
        }

        private List<Wfs.Exception> _ExceptionList;

        [XmlElement(ElementName = "Exception", Form = XmlSchemaForm.Unqualified,Type = typeof(Wfs.Exception))]
        [DataMember]
        public List<Wfs.Exception> ExceptionList
        {
            get
            {
                if (_ExceptionList == null)
                {
                    _ExceptionList = new List<Exception>();
                }
                return _ExceptionList;
            }
            set { _ExceptionList = value;}
        }


    }
}