using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "UserLayer", Namespace = Declarations.SldNameSpace),  Serializable]
    public partial class UserLayer
    {
        private string m_Name;

        [XmlElement(ElementName = "Name", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "string", Namespace = Declarations.SldNameSpace)]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }


        [XmlIgnore] 
        public bool DescriptionSpecified;
        private Description m_Description;

        [XmlElement(ElementName = "Description", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
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
        public bool RemoteOWSSpecified;
        private RemoteOWS m_RemoteOWS;

        [XmlElement(Type = typeof(RemoteOWS), ElementName = "RemoteOWS", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public RemoteOWS RemoteOWS
        {
            get
            {
                if (m_RemoteOWS == null)
                {
                    m_RemoteOWS = new RemoteOWS();
                    RemoteOWSSpecified = true;
                }

                return m_RemoteOWS;
            }
            set { m_RemoteOWS = value; RemoteOWSSpecified = true; }
        }

        private List<FeatureTypeConstraint> m_LayerFeatureConstraints;

        public List<FeatureTypeConstraint> LayerFeatureConstraints
        {
            get { return m_LayerFeatureConstraints; }
            set { m_LayerFeatureConstraints = value; }
        }

        private List<UserStyle> m_UserStyles;

        public List<UserStyle> UserStyles
        {
            get { return m_UserStyles; }
            set { m_UserStyles = value; }
        }
    }
}
