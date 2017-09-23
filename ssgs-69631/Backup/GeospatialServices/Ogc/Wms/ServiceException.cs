using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Web;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common; 

namespace GeospatialServices.Ogc.Wms
{
    [DataContract]
    [XmlType(TypeName = "ServiceException", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class ServiceException
    {

        public ServiceException()
        {
        }

        public ServiceException(WmsExceptionCode code, string message)
        {
            _Code = code;
            _Message = message;
        }

        private WmsExceptionCode _Code;
        [XmlAttribute(AttributeName = "code")]
        [DataMember] public WmsExceptionCode Code
        {
            get { return _Code; }
            set { _Code = value; }
        }


        private string _Locator;

        [XmlAttribute(AttributeName = "locator", DataType = "string")]
        [DataMember] public string Locator
        {
            get { return _Locator; }
            set { _Locator = value; }
        }


        private string _Message;

        [XmlText(DataType = "string")]
        [DataMember] public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }


    }
}