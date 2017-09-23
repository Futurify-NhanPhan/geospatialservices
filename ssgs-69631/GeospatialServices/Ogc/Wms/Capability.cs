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
    [XmlType(TypeName = "Capability", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class Capability
    {
        private Request _Request;

        [XmlElement(ElementName = "Request", Type = typeof(Request), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public Request Request
        {
            get {return _Request;}
            set {_Request = value;}
        }


        private Exception _Exception;

        [XmlElement(ElementName = "Exception", Type = typeof(Exception), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public Exception Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
        }

        [XmlIgnore] 
        [DataMember] public bool ExtendedCapabilitiesSpecified;

        private List<object> _ExtendedCapabilitiesList;

        [XmlElement(ElementName = "_ExtendedCapabilities", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public List<object> ExtendedCapabilities
        {
            get
            {
                if (_ExtendedCapabilitiesList == null)
                {
                    _ExtendedCapabilitiesList = new List<object>();
                    ExtendedCapabilitiesSpecified = true;
                }
                return _ExtendedCapabilitiesList;
            }
            set { _ExtendedCapabilitiesList = value; ExtendedCapabilitiesSpecified = true; }
        }

        private UserDefinedSymbolization _UserDefinedSymbolization;
        [XmlElement(ElementName = "UserDefinedSymbolization", Type = typeof(UserDefinedSymbolization), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public UserDefinedSymbolization UserDefinedSymbolization
        {
            get { return _UserDefinedSymbolization; }
            set { _UserDefinedSymbolization = value; }
        }



        private Layer _Layer;

        [XmlElement(ElementName = "Layer", Type = typeof(Layer), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public Layer Layer
        {
            get { return _Layer; }
            set { _Layer = value; }
        }


        
    }
}
