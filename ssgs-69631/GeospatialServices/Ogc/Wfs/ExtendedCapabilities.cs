using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{

    [DataContract]
    [XmlType(TypeName = "ExtendedCapabilities", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class ExtendedCapabilities
    {
        private string _Any;

        [XmlAttribute()]
        [DataMember]
        public string  Any
        {
            get { return _Any; }
            set { _Any = value; }
        }

        
        [XmlIgnore] 
        [DataMember] public bool AnyExtendedCapabilitiesSpecified;

        private List<string> _AnyExtendedCapabilitiesList;

        [XmlElement(ElementName = "ExtendedCapabilities",Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public List<string> AnyExtendedCapabilities
        {
            get
            {
                if (_AnyExtendedCapabilitiesList == null)
                {
                    _AnyExtendedCapabilitiesList = new List<string>();
                    AnyExtendedCapabilitiesSpecified = true;
                }
                return _AnyExtendedCapabilitiesList;
            }
            set { _AnyExtendedCapabilitiesList = value; AnyExtendedCapabilitiesSpecified = true; }
        }
        
    }
}
