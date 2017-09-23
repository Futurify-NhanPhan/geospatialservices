using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "UserStyle", Namespace = Declarations.SldNameSpace), Serializable]
    public partial class UserStyle
    {
        public UserStyle()
        {

        }

        public UserStyle(string name)
        {
            this.Name = name;
        }

        [XmlIgnore]
        public bool NameSpecified;
        private string m_Name;

        [XmlElement(ElementName = "Name", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "string", Namespace = Declarations.SldNameSpace)]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; NameSpecified = true; }
        }

        [XmlIgnore]
        public bool DescriptionSpecified;
        private Description m_Description;

        [XmlElement(Type = typeof(Description), ElementName = "Description", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
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

        private int m_IsDefault;
        [XmlIgnore]
        public bool IsDefaultSpecified;
        
        [XmlElement(ElementName = "IsDefault", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public int IsDefault
        {
            get { return m_IsDefault; }
            set { m_IsDefault = value; IsDefaultSpecified = true; }
        }

        [XmlIgnore]
        public bool FeatureTypeStylesSpecified;
        private List<FeatureTypeStyle> m_FeatureTypeStyles;

        [XmlElement(ElementName = "FeatureTypeStyle", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<FeatureTypeStyle> FeatureTypeStyles
        {
            get
            {
                if (m_FeatureTypeStyles == null)
                {
                    m_FeatureTypeStyles = new List<FeatureTypeStyle>();
                    FeatureTypeStylesSpecified = true;
                }
                return m_FeatureTypeStyles;
            }
            set { m_FeatureTypeStyles = value; FeatureTypeStylesSpecified = true; }
        }
    }
}
