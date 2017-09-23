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
    [XmlType(TypeName = "WFS_Capabilities", Namespace = Declarations.Wfs110DefaultNameSpace), Serializable]
    public partial class WFS_Capabilities
    {

        public WFS_Capabilities()
        {
            this._Version = "1.1.0";
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
        [DataMember]
        public bool ServiceIdentificationSpecified;

        private ServiceIdentification _ServiceIdentification;

        [XmlElement(ElementName = "ServiceIdentification", Form = XmlSchemaForm.Unqualified, Type = typeof(ServiceIdentification))]
        [DataMember]
        public ServiceIdentification ServiceIdentification
        {
            get
            {
                if (_ServiceIdentification == null)
                {
                    _ServiceIdentification = new ServiceIdentification();
                    ServiceIdentificationSpecified = true;
                }
                return _ServiceIdentification;
            }
            set { _ServiceIdentification = value; ServiceIdentificationSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool ServiceProviderSpecified;

        private ServiceProvider _ServiceProvider;

        [XmlElement(ElementName = "ServiceProvider", Form = XmlSchemaForm.Unqualified, Type = typeof(ServiceProvider))]
        [DataMember]
        public ServiceProvider ServiceProvider
        {
            get
            {
                if (_ServiceProvider == null)
                {
                    _ServiceProvider = new ServiceProvider();
                    ServiceProviderSpecified = true;
                }
                return _ServiceProvider;
            }
            set { _ServiceProvider = value; ServiceProviderSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool OperationsMetadataSpecified;

        private OperationsMetadata _OperationsMetadata;

        [XmlElement(ElementName = "OperationsMetadata", Form = XmlSchemaForm.Unqualified, Type = typeof(OperationsMetadata))]
        [DataMember]
        public OperationsMetadata OperationsMetadata
        {
            get
            {
                if (_OperationsMetadata == null)
                {
                    _OperationsMetadata = new OperationsMetadata();
                    OperationsMetadataSpecified = true;
                }
                return _OperationsMetadata;
            }
            set { _OperationsMetadata = value; OperationsMetadataSpecified = true; }
        }

        [XmlIgnore]
        [DataMember]
        public bool FeatureTypeListSpecified;

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
                    FeatureTypeListSpecified = true;
                }
                return _FeatureTypeList;
            }
            set { _FeatureTypeList = value; FeatureTypeListSpecified = true;  }
        }


        [XmlIgnore]
        [DataMember]
        public bool ServesGMLObjectTypeListSpecified;

        private GMLObjectTypeList _ServersGMLObjectTypeList;

        [XmlElement(ElementName = "ServersGMLObjectTypeList", Form = XmlSchemaForm.Unqualified, Type = typeof(GMLObjectTypeList))]
        [DataMember]
        public GMLObjectTypeList ServersGMLObjectTypeList
        {
            get
            {
                if (_ServersGMLObjectTypeList == null)
                {
                    _ServersGMLObjectTypeList = new GMLObjectTypeList();
                    ServesGMLObjectTypeListSpecified = true;
                }
                return _ServersGMLObjectTypeList;
            }
            set { _ServersGMLObjectTypeList = value; ServesGMLObjectTypeListSpecified = true; }
        }

        [XmlIgnore]
        [DataMember]
        public bool SupportsGMLObjectTypeListSpecified;


        private GMLObjectTypeList _SupportsGMLObjectTypeList;

        [XmlElement(ElementName = "SupportsGMLObjectTypeList", Form = XmlSchemaForm.Unqualified, Type = typeof(GMLObjectTypeList))]
        [DataMember]
        public GMLObjectTypeList SupportsGMLObjectTypeList
        {
            get
            {
                if (_SupportsGMLObjectTypeList == null)
                {
                    _SupportsGMLObjectTypeList = new GMLObjectTypeList();
                    SupportsGMLObjectTypeListSpecified = true;
                }
                return _SupportsGMLObjectTypeList;
            }
            set { _SupportsGMLObjectTypeList = value; SupportsGMLObjectTypeListSpecified = true; }
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
