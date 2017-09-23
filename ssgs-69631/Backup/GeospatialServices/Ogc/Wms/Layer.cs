using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace GeospatialServices.Ogc.Wms
{
    [DataContract]
    [XmlType(TypeName = "Layer", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class Layer 
    {
        private int _Queryable;

        [XmlAttribute(AttributeName = "queryable", DataType = "int")]
        [DataMember]
        public int Queryable
        {
            get { return _Queryable; }
            set { _Queryable = value; }
        }

        private int _Cascaded;

        [XmlAttribute(AttributeName = "cascaded", DataType = "int")]
        [DataMember]
        public int Cascaded
        {
            get { return _Cascaded; }
            set { _Cascaded = value; }
        }

        private int _Opaque;


        [XmlAttribute(AttributeName = "opaque", DataType = "int")]
        [DataMember]
        public int Opaque
        {
            get { return _Opaque; }
            set { _Opaque = value; }
        }

        private int _NoSubsets;


        [XmlAttribute(AttributeName = "noSubsets", DataType = "int")]
        [DataMember]
        public int NoSubsets
        {
            get { return _NoSubsets; }
            set { _NoSubsets = value; }
        }

        private int _FixedWidth;

        [XmlAttribute(AttributeName = "fixedWidth", DataType = "int")]
        [DataMember]
        public int FixedWidth
        {
            get { return _FixedWidth; }
            set { _FixedWidth = value; }
        }

        private int _FixedHeight;

        [XmlAttribute(AttributeName = "fixedHeight", DataType = "int")]
        [DataMember]
        public int FixedHeight
        {
            get { return _FixedHeight; }
            set { _FixedHeight = value; }
        }


        private string _Name;

        [XmlElement(ElementName = "Name", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


        private string _Title;

        [XmlElement(ElementName = "Title", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }


        [XmlIgnore]
        [DataMember]
        public bool AbstractSpecified;
        private string _Abstract;


        [XmlElement(ElementName = "Abstract", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public string Abstract
        {
            get { return _Abstract; }
            set { _Abstract = value; AbstractSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool KeyWordListSpecified;

        private List<Keyword> _KeywordList;


        [XmlArray(ElementName = "KeywordList", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [XmlArrayItem(ElementName = "Keyword", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<Keyword> KeywordList
        {
            get
            {
                if (_KeywordList == null)
                {
                    _KeywordList = new List<Keyword>();
                    KeyWordListSpecified = true;
                }
                return _KeywordList;
            }
            set { _KeywordList = value; KeyWordListSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool CRSListSpecified;

        private List<string> _CRSList;


        [XmlElement(ElementName = "CRS", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<string> CRSList
        {
            get
            {
                if (_CRSList == null)
                {
                    _CRSList = new List<string>();
                    CRSListSpecified = true;
                }
                return _CRSList;
            }
            set { _CRSList = value; CRSListSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool EX_GeographicBoundingBoxSpecified;

        private EX_GeographicBoundingBox _EX_GeographicBoundingBox;


        [XmlElement(ElementName = "EX_GeographicBoundingBox", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public EX_GeographicBoundingBox EX_GeographicBoundingBox
        {
            get
            {
                if (_EX_GeographicBoundingBox == null)
                {
                    _EX_GeographicBoundingBox = new EX_GeographicBoundingBox();
                    EX_GeographicBoundingBoxSpecified = true;
                }
                return _EX_GeographicBoundingBox;

            }
            set { _EX_GeographicBoundingBox = value; EX_GeographicBoundingBoxSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool BoundingBoxListSpecified;

        private List<BoundingBox> _BoundingBoxList;


        [XmlElement(ElementName = "BoundingBox", Type = typeof(BoundingBox), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<BoundingBox> BoundingBoxList
        {
            get
            {
                if (_BoundingBoxList == null)
                {
                    _BoundingBoxList = new List<BoundingBox>();
                    BoundingBoxListSpecified = true;
                }
                return _BoundingBoxList;

            }
            set { _BoundingBoxList = value; BoundingBoxListSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool DimensionListSpecified;

        private List<Dimension> _DimensionList;


        [XmlElement(ElementName = "Dimension", Type = typeof(Dimension), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<Dimension> DimensionList
        {
            get
            {
                if ((_DimensionList == null))
                {
                    _DimensionList = new List<Dimension>();
                    DimensionListSpecified = true;
                }
                return _DimensionList;

            }
            set { _DimensionList = value; DimensionListSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool AttributionListSpecified;

        private List<Attribution> _AttributionList;


        [XmlElement(ElementName = "Attribution", Type = typeof(Attribution), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<Attribution> AttributionList
        {
            get
            {
                if ((_AttributionList == null))
                {
                    _AttributionList = new List<Attribution>();
                    AttributionListSpecified = true;
                }
                return _AttributionList;

            }
            set { _AttributionList = value; AttributionListSpecified = true; }
        }



        [XmlIgnore]
        [DataMember]
        public bool AuthorityURLListSpecified;

        private List<AuthorityURL> _AuthorityURLList;


        [XmlElement(ElementName = "AuthorityURL", Type = typeof(AuthorityURL), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<AuthorityURL> AuthorityURLList
        {
            get
            {
                if ((_AuthorityURLList == null))
                {
                    _AuthorityURLList = new List<AuthorityURL>();
                    AuthorityURLListSpecified = true;
                }
                return _AuthorityURLList;

            }
            set { _AuthorityURLList = value; AuthorityURLListSpecified = true; }
        }



        [XmlIgnore]
        [DataMember]
        public bool IdentifierListSpecified;

        private List<Identifier> _IdentifierList;


        [XmlElement(ElementName = "Identifier", Type = typeof(Identifier), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<Identifier> IdentifierList
        {
            get
            {
                if ((_IdentifierList == null))
                {
                    _IdentifierList = new List<Identifier>();
                    IdentifierListSpecified = true;
                }
                return _IdentifierList;

            }
            set { _IdentifierList = value; IdentifierListSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool MetadataURLListSpecified;

        private List<MetadataURL> _MetadataURLList;


        [XmlElement(ElementName = "MetadataURL", Type = typeof(MetadataURL), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<MetadataURL> MetadataURLList
        {
            get
            {
                if ((_MetadataURLList == null))
                {
                    _MetadataURLList = new List<MetadataURL>();
                    MetadataURLListSpecified = true;
                }
                return _MetadataURLList;

            }
            set { _MetadataURLList = value; MetadataURLListSpecified = true; }
        }

        [XmlIgnore]
        [DataMember]
        public bool DataURLListSpecified;

        private List<DataURL> _DataURLList;


        [XmlElement(ElementName = "DataURL", Type = typeof(DataURL), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<DataURL> DataURLList
        {
            get
            {
                if ((_DataURLList == null))
                {
                    _DataURLList = new List<DataURL>();
                    DataURLListSpecified = true;
                }
                return _DataURLList;

            }
            set { _DataURLList = value; DataURLListSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool FeatureListURLListSpecified;

        private List<FeatureListURL> _FeatureListURLList;


        [XmlElement(ElementName = "FeatureListURL", Type = typeof(FeatureListURL), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<FeatureListURL> FeatureListURLList
        {
            get
            {
                if ((_FeatureListURLList == null))
                {
                    _FeatureListURLList = new List<FeatureListURL>();
                    FeatureListURLListSpecified = true;
                }
                return _FeatureListURLList;

            }
            set { _FeatureListURLList = value; FeatureListURLListSpecified = true; }
        }

        [XmlIgnore]
        [DataMember]
        public bool StyleListSpecified;
        private List<Style> _StyleList;


        [XmlElement(ElementName = "Style", Type = typeof(Style), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<Style> StyleList
        {
            get
            {
                if ((_StyleList == null))
                {
                    _StyleList = new List<Style>();
                    StyleListSpecified = true;
                }
                return _StyleList;

            }
            set { _StyleList = value; StyleListSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool MinScaleDenominatorSpecified;
        private double _MinScaleDenominator;


        [XmlElement(ElementName = "MinScaleDenominator", IsNullable = false, DataType = "double", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public double MinScaleDenominator
        {
            get { return _MinScaleDenominator; }
            set { _MinScaleDenominator = value; MinScaleDenominatorSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool MaxScaleDenominatorSpecified;
        private double _MaxScaleDenominator;


        [XmlElement(ElementName = "MaxScaleDenominator", IsNullable = false, DataType = "double", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public double MaxScaleDenominator
        {
            get { return _MaxScaleDenominator; }
            set { _MaxScaleDenominator = value; MaxScaleDenominatorSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool LayerListSpecified;
        private List<Layer> _LayerList;


        [XmlElement(ElementName = "Layer", Type = typeof(Layer), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public List<Layer> LayerList
        {
            get
            {
                if (_LayerList == null)
                {
                    _LayerList = new List<Layer>();
                    LayerListSpecified = true;
                }
                return _LayerList;
            }
            set
            {
                _LayerList = value;
                LayerListSpecified = true;
            }
        }

        }
    }

