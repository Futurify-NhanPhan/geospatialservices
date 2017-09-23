using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "FeatureType", Namespace = Declarations.Wfs100DefaultNameSpace), Serializable]
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


        private string _Keywords;

        [XmlElement(ElementName = "Keywords", Form = XmlSchemaForm.Unqualified, Type = typeof(string))]
        [DataMember]
        public string Keywords
        {
            get { return _Keywords; }
            set { _Keywords = value; }
        }

        private string _SRS;

        [XmlElement(ElementName = "SRS", Form = XmlSchemaForm.Unqualified, Type = typeof(string))]
        [DataMember]
        public string SRS
        {
            get { return _SRS; }
            set { _SRS = value; }
        }


        private Operations _Operations;

        [XmlElement(Type = typeof(Operations), ElementName = "Operations", IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public Operations Operations
        {
            get {return _Operations;}
            set {_Operations = value;}
        }

        [XmlIgnore]
        [DataMember]
        public bool LatLongBoundingBoxListSpecified = false;

        private List<LatLongBoundingBox> _LatLongBoundingBoxList;

        [XmlElement(ElementName = "LatLongBoundingBox", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public List<LatLongBoundingBox> LatLongBoundingBoxList
        {
            get
            {
                if (_LatLongBoundingBoxList == null)
                {
                    _LatLongBoundingBoxList = new List<LatLongBoundingBox>();
                    LatLongBoundingBoxListSpecified = true;
                }
                return _LatLongBoundingBoxList;
            }
            set { _LatLongBoundingBoxList = value; LatLongBoundingBoxListSpecified = true; }
        }
        
        [XmlIgnore]
        [DataMember] 
        public bool MetadataURLListSpecified;

        private List<MetadataURL> _MetadataURLList;

        [XmlElement(ElementName = "MetadataURL", Form = XmlSchemaForm.Unqualified, Type = typeof(MetadataURL))]
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
