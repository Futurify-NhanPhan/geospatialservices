using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "Capability", Namespace = Declarations.Wfs100DefaultNameSpace), Serializable]
    public partial class Capability
    {

        private Request _Request;

        [XmlElement(ElementName = "Request", Type = typeof(Request), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public Request Request
        {
            get
            {
                if (_Request == null)
                {
                    _Request = new Request();
                }
                return _Request;
            }
            set { _Request = value; }
        }


        private string _VendorSpecificCapabilities;

        [XmlElement(ElementName = "VendorSpecificCapabilities", Type = typeof(string), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string VendorSpecificCapabilities
        {
            get { return _VendorSpecificCapabilities;}
            set { _VendorSpecificCapabilities = value; }
        }


    }
}
