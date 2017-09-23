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
    [XmlType(TypeName = "ServiceExceptionReport", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class ServiceExceptionReport
    {

        public ServiceExceptionReport()
        {
            this._Version = "1.3.0";
        }


        private string _Version;

        [XmlAttribute(AttributeName = "version", DataType = "string")]
        [DataMember] public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        [XmlIgnore] 
        [DataMember] public bool ServiceExceptionListSpecified;

        private List<ServiceException> _ServiceExceptionList;

        [XmlElement(ElementName = "ServiceException", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public List<ServiceException> ServiceExceptionList
        {
            get
            {
                if (_ServiceExceptionList == null)
                {
                    _ServiceExceptionList = new List<ServiceException>();
                    ServiceExceptionListSpecified = true;
                }
                return _ServiceExceptionList;
            }
            set { _ServiceExceptionList = value; ServiceExceptionListSpecified = true; }
        }
 
    }
}