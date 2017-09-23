using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms
{

    [DataContract]
    [XmlType(TypeName = "WMS_Capabilities", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class WMS_Capabilities
    {

        public WMS_Capabilities()
        {
            this._Version = "1.3.0";
        }


        private string _Version;

        [DataMember] 
        [XmlAttribute(AttributeName = "version", DataType = "string")]
        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }


        private string _UpdateSequence;

        [DataMember] 
        [XmlAttribute(AttributeName = "updateSequence", DataType = "string")]
        public string UpdateSequence
        {
            get { return _UpdateSequence; }
            set { _UpdateSequence = value; }
        }


        [XmlIgnore]
        [DataMember] public bool ServiceSpecified;

        private Service _Service;

        [XmlElement(Type = typeof(Service), ElementName = "Service", IsNullable = true, Form = XmlSchemaForm.Qualified, Namespace=Declarations.WmsNameSpace)]
        [DataMember] public Service Service
        {
            get{return _Service;}
            set { _Service = value; ServiceSpecified = true; }
        }

        [XmlIgnore]
        [DataMember] public bool CapabilitySpecified;

        private Capability _Capability;

        [XmlElement(Type = typeof(Capability), ElementName = "Capability", IsNullable = true, Form=XmlSchemaForm.Qualified, Namespace=Declarations.WmsNameSpace )]
        [DataMember] public Capability Capability
        {
            get{ return _Capability;}
            set{_Capability = value; CapabilitySpecified = true;}
        }
    }

}
