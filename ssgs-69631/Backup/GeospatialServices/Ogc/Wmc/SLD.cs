using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "SLD", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class SLD
    {
        [XmlIgnore]
        public bool NameSpecified;
        private string m_Name;

        [XmlElement(ElementName = "Name", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; NameSpecified = true; }
        }

        [XmlIgnore]
        public bool TitleSpecified;
        private string m_Title;

        [XmlElement(ElementName = "Title", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; TitleSpecified = true;}
        }

        [XmlIgnore]
        public bool LegendURLSpecified;
        private URL m_LegendURL;

        [XmlElement(Type = typeof(URL), ElementName = "LegendURL", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public URL LegendURL
        {
            get
            {
                if (m_LegendURL == null)
                {
                    m_LegendURL = new URL();
                    LegendURLSpecified = true;
                }
                return m_LegendURL;
            }
            set { m_LegendURL = value; LegendURLSpecified = true; }
        }

        [XmlIgnore]
        public bool OnlineResourceSpecified;
        private OnlineResource m_OnlineResource;

        [XmlElement(Type = typeof(OnlineResource), ElementName = "OnlineResource", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public OnlineResource OnlineResource
        {
            get 
            {
                if (m_OnlineResource == null)
                {
                    m_OnlineResource = new OnlineResource();
                    OnlineResourceSpecified = true;
                }
                
                return m_OnlineResource;
            }
            set { m_OnlineResource = value; OnlineResourceSpecified = true; }
        }

        [XmlIgnore]
        public bool StyledLayerDescriptorSpecified;
        private StyledLayerDescriptor m_StyledLayerDescriptor;

        [XmlElement(Type = typeof(StyledLayerDescriptor), ElementName = "StyledLayerDescriptor", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public StyledLayerDescriptor StyledLayerDescriptor
        {
            get
            {
                if (m_StyledLayerDescriptor == null)
                {
                    m_StyledLayerDescriptor = new StyledLayerDescriptor();
                    StyledLayerDescriptorSpecified = true;
                }
                return m_StyledLayerDescriptor;
            }
            set { m_StyledLayerDescriptor = value; StyledLayerDescriptorSpecified = true; }
        }

        [XmlIgnore]
        public bool FeatureTypeStyleSpecified;
        private FeatureTypeStyle m_FeatureTypeStyle;

        [XmlElement(Type = typeof(FeatureTypeStyle), ElementName = "FeatureTypeStyle", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public FeatureTypeStyle FeatureTypeStyle
        {
            get
            {
                if (m_FeatureTypeStyle == null)
                {
                    m_FeatureTypeStyle = new FeatureTypeStyle();
                    FeatureTypeStyleSpecified = true;

                }
                return m_FeatureTypeStyle;
            }
            set { m_FeatureTypeStyle = value; FeatureTypeStyleSpecified = true; }
        }
     
    }
}
