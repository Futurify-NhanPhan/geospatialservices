using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "FeatureTypeStyle", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class FeatureTypeStyle
    {
        private string m_Version;

        [XmlAttribute(AttributeName = "version", DataType = "string")]
        public string Version
        {
            get { return m_Version; }
            set { m_Version = value; }
        }

        private string m_Name;

        [XmlElement(ElementName = "Name", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "string", Namespace = Declarations.SeNameSpace)]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        [XmlIgnore]
        public bool DescriptionSpecified;
        private Description m_Description;

        [XmlElement(Type = typeof(Description), ElementName = "Description", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Description Description
        {
            get
            {
                if (m_Description == null)
                {
                    m_Description = new Description();
                    DescriptionSpecified = true;
                }

                return m_Description;
            }
            set { m_Description = value; DescriptionSpecified = true; }
        }

        private string m_FeatureTypeName;
        
        [XmlElement(ElementName = "FeatureTypeName", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "string", Namespace = Declarations.SeNameSpace)]
        public string FeatureTypeName
        {
            get { return m_FeatureTypeName; }
            set { m_FeatureTypeName = value; }
        }

        [XmlIgnore]
        public bool SemanticTypeIdentifiersSpecified;
        private List<string> m_SemanticTypeIdentifiers;

        [XmlElement(ElementName = "SemanticTypeIdentifier", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<string> SemanticTypeIdentifiers
        {
            get
            {
                if (m_SemanticTypeIdentifiers == null)
                {
                    m_SemanticTypeIdentifiers = new List<string>();
                    SemanticTypeIdentifiersSpecified = true;

                }
                return m_SemanticTypeIdentifiers;
            }
            set { m_SemanticTypeIdentifiers = value; SemanticTypeIdentifiersSpecified = true; }
        }


        [XmlIgnore]
        public bool OnlineResourcesSpecified;
        private List<OnlineResource> m_OnlineResources;

        [XmlElement(ElementName = "OnlineResource", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public System.Collections.Generic.List<OnlineResource> OnlineResources
        {
            get { return m_OnlineResources; }
            set { m_OnlineResources = value; OnlineResourcesSpecified = true; }
        }

        [XmlIgnore]
        public bool RulesSpecified;
        private List<Rule> m_Rules;

        [XmlElement(ElementName = "Rule", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<Rule> Rules
        {
            get
            {
                if (m_Rules == null)
                {
                    m_Rules = new List<Rule>();
                    RulesSpecified = true;
                }
                return m_Rules;
            }
            set { m_Rules = value; }
        }
    }
}
