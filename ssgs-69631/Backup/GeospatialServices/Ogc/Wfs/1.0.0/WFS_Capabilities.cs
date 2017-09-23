using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{

    [DataContract]
    [XmlType(TypeName = "WFS_Capabilities", Namespace = Declarations.Wfs100DefaultNameSpace), Serializable]
    public partial class WFS_Capabilities
    {

        public WFS_Capabilities()
        {
            this._Version = "1.0.0";
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


        
        private Service _Service;

        [XmlElement(ElementName = "Service", Form = XmlSchemaForm.Unqualified, Type = typeof(Service))]
        [DataMember]
        public Service Service
        {
            get
            {
                if (_Service == null)
                {
                    _Service = new Service();
                }
                return _Service;
            }
            set { _Service = value;}
        }

        private Capability _Capability;

        [XmlElement(ElementName = "Capability", Form = XmlSchemaForm.Unqualified, Type = typeof(Capability))]
        [DataMember]
        public Capability Capability
        {
            get
            {
                if (_Capability == null)
                {
                    _Capability = new Capability();
                }
                return _Capability;
            }
            set { _Capability = value; }
        }



        
        private FeatureTypeList _FeatureTypeList;

        [XmlElement(ElementName = "FeatureTypeList", Form = XmlSchemaForm.Unqualified, Type = typeof(FeatureTypeList))]
        [DataMember]
        public FeatureTypeList FeatureTypeList
        {
            get
            {
                if (_FeatureTypeList == null)
                {
                    _FeatureTypeList = new FeatureTypeList();
                }
                return _FeatureTypeList;
            }
            set { _FeatureTypeList = value;  }
        }


        

        private Filter_Capabilities _Filter_Capabilities;

        [XmlElement(ElementName = "Filter_Capabilities", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(Filter_Capabilities))]
        [DataMember]
        public Filter_Capabilities Filter_Capabilities
        {
            get
            {
                if (_Filter_Capabilities == null)
                {
                    _Filter_Capabilities = new Filter_Capabilities();
                }
                return _Filter_Capabilities;
            }
            set { _Filter_Capabilities = value; }
        }


        
    }

}
