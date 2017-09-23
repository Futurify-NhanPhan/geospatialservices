using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace  GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "NamedLayer", Namespace = Declarations.SldNameSpace), Serializable]
    public partial class NamedLayer
    {

        private string m_Name;

        [XmlElement(ElementName = "Name", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "string", Namespace = Declarations.SldNameSpace )]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value;  }
        }

        [XmlIgnore]
        public bool DescriptionSpecified;
        private Description m_Description;

        [XmlElement(ElementName = "Description", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace )]
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

        [XmlIgnore]
        public bool LayerFeatureConstraintsSpecified;
        private List<FeatureTypeConstraint> m_LayerFeatureConstraints;

        [XmlArray(ElementName = "LayerFeatureConstraints", Form = XmlSchemaForm.Qualified)]
        [XmlArrayItem(ElementName = "FeatureTypeConstraint", Form = XmlSchemaForm.Qualified)] 
        public List<FeatureTypeConstraint> LayerFeatureConstraints
        {
            get
            {
                if (m_LayerFeatureConstraints == null)
                {
                    m_LayerFeatureConstraints = new List<FeatureTypeConstraint>();
                    LayerFeatureConstraintsSpecified = true;

                }
                return m_LayerFeatureConstraints;
            }
            set { m_LayerFeatureConstraints = value; LayerFeatureConstraintsSpecified = true; }
        }

        [XmlIgnore]
        public bool NamedStylesSpecified;
        private List<NamedStyle> m_NamedStyles;

        [XmlElement(ElementName = "NamedStyle", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public List<NamedStyle> NamedStyles
        {
            get
            {
                if (m_NamedStyles == null)
                {
                    m_NamedStyles = new List<NamedStyle>();
                    NamedStylesSpecified = true;
                }
                return m_NamedStyles;
            }
            set { m_NamedStyles = value; NamedStylesSpecified = true; }
        }

        [XmlIgnore]
        public bool UserStylesSpecified;
        private List<UserStyle> m_UserStyles;

        [XmlElement(Type = typeof(UserStyle), ElementName = "UserStyle", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public List<UserStyle> UserStyles
        {
            get
            {
                if (m_UserStyles == null)
                {
                    m_UserStyles = new List<UserStyle>();
                    UserStylesSpecified = true;
                }
                return m_UserStyles;
            }
            set { m_UserStyles = value; UserStylesSpecified = true; }
        }
    }

}
