using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{
    [DataContract]
    [XmlType(TypeName = "FeatureType", Namespace = Declarations.Wfs110NameSpace), Serializable]
    public partial class FeatureType
    {
        public FeatureType()
        {

        }

        private string _Name;

        [XmlElement(ElementName = "Name", Form = XmlSchemaForm.Unqualified, Type = typeof(string))]
        [DataMember] 
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Title;

        [XmlElement(ElementName = "Title", Form = XmlSchemaForm.Unqualified, Type = typeof(string))]
        [DataMember] 
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Abstract;

        [XmlElement(ElementName = "Abstract", Form = XmlSchemaForm.Unqualified, Type = typeof(string))]
        [DataMember] 
        public string Abstract
        {
            get { return _Abstract; }
            set { _Abstract = value; }
        }


        [XmlIgnore]
        [DataMember]
        public bool KeywordsListSpecified;

        private List<Keywords> _KeywordsList;

        [XmlElement(ElementName = "Keywords", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(Keywords))]
        [DataMember]
        public List<Keywords> KeywordsList
        {
            get
            {
                if (_KeywordsList == null)
                {
                    _KeywordsList = new List<Keywords>();
                    KeywordsListSpecified = true;
                }
                return _KeywordsList;
            }
            set { _KeywordsList = value; KeywordsListSpecified = true; }
        }



        [XmlIgnore]
        [DataMember]
        public bool SRSListSpecified;

        [XmlIgnore]
        [DataMember]
        public SRSTypes[] SRSSelections;

        private object[] _SRSList;

        [XmlChoiceIdentifier(MemberName = "SRSSelections")]
        [XmlElement(ElementName = "DefaultSRS", Type = typeof(string), DataType = "anyURI", Form = XmlSchemaForm.Unqualified)]
        [XmlElement(ElementName = "NoSRS", Type = typeof(string), DataType = "anyURI", Form = XmlSchemaForm.Unqualified)]
        [XmlElement(ElementName = "OtherSRS", Type = typeof(string), DataType = "anyURI", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public object[] SRSList
        {
            get { return _SRSList; }
            set { _SRSList = value; SRSListSpecified = true; }
        }


        private List<OperationType> _OperationList;

        [XmlElement(ElementName = "Operation", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public List<OperationType> OperationList
        {
            get
            {
                if (_OperationList == null)
                {
                    _OperationList = new List<OperationType>();
                }
                return _OperationList;
            }
            set { _OperationList = value; }
        }

        private OutputFormatList _OutputFormatList;

        [XmlElement(ElementName = "OutputFormats", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public OutputFormatList OutputFormats
        {
            get
            {
                if (_OutputFormatList == null)
                {
                    _OutputFormatList = new OutputFormatList();
                }

                return _OutputFormatList;
            }
            set { _OutputFormatList = value; }
        }


        private WGS84BoundingBox _WGS84BoundingBox;

        [XmlElement(ElementName = "WGS84BoundingBox", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public WGS84BoundingBox WGS84BoundingBox
        {
            get
            {
                if (_WGS84BoundingBox == null)
                {
                    _WGS84BoundingBox = new WGS84BoundingBox();
                }

                return _WGS84BoundingBox;
            }
            set { _WGS84BoundingBox = value; }
        }

        [XmlIgnore]
        [DataMember]
        public bool MetadataURLListSpecified;

        private List<MetadataURL> _MetadataURLList;

        [XmlElement(ElementName = "MetadataURL", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public List<MetadataURL> MetadataURLList
        {
            get
            {
                if (_MetadataURLList == null)
                {
                    _MetadataURLList = new List<MetadataURL>();
                    MetadataURLListSpecified = true;
                }

                return _MetadataURLList;
            }
            set { _MetadataURLList = value; MetadataURLListSpecified = true; }
        }



    }
}
