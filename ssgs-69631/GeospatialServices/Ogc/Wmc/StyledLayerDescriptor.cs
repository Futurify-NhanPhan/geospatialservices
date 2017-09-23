using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "StyledLayerDescriptor", Namespace = Declarations.SldNameSpace), Serializable]
    public partial class StyledLayerDescriptor
    {
        private String m_Version;

        [XmlAttribute(AttributeName = "version", DataType = "string")]
        public string Version
        {
            get { return m_Version; }
            set { m_Version = value; }
        }
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

        [XmlElement(Type = typeof(Description), ElementName = "Description", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace )]
        public Description Description
        {
            get { return m_Description; }
            set { m_Description = value; DescriptionSpecified = true; }
        }

        [XmlIgnore]
        public bool EnvironmentVariablesSpecified;

        private XmlElement m_EnvironmentVariables;

        [XmlAnyElement()]
        public XmlElement EnvironmentVariables
        {
            get { return m_EnvironmentVariables; }
            set { m_EnvironmentVariables = value; EnvironmentVariablesSpecified = true; }
        }

        [XmlIgnore]
        public bool UseSLDLibrarySpecified;
        private List<OnlineResource> m_UseSLDLibrary;

        [XmlArray(ElementName = "UseSLDLibrary", Form = XmlSchemaForm.Qualified)]
        [XmlArrayItem(ElementName = "OnlineResource", Form = XmlSchemaForm.Qualified)]
        public List<OnlineResource> UseSLDLibrary
        {
            get
            {
                if (m_UseSLDLibrary == null)
                {
                    m_UseSLDLibrary = new List<OnlineResource>();
                    UseSLDLibrarySpecified = true;
                }

                return m_UseSLDLibrary;
            }
            set { m_UseSLDLibrary = value; UseSLDLibrarySpecified = true; }
        }

        [XmlIgnore]
        public bool NamedLayersSpecified;
        private List<NamedLayer> m_NamedLayers;

        [XmlElement(Type = typeof(NamedLayer), ElementName = "NamedLayer", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public List<NamedLayer> NamedLayers
        {
            get
            {
                if (m_NamedLayers == null)
                {
                    m_NamedLayers = new List<NamedLayer>();
                    NamedLayersSpecified = true;
                }
                return m_NamedLayers;
            }
            set { m_NamedLayers = value; NamedLayersSpecified = true; }
        }

        [XmlIgnore]
        public bool UserLayersSpecified;
        private List<UserLayer> m_UserLayers;

        [XmlElement(Type = typeof(UserLayer), ElementName = "UserLayer", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public List<UserLayer> UserLayers
        {
            get
            {
                if (m_UserLayers == null)
                {
                    m_UserLayers = new List<UserLayer>();
                    UserLayersSpecified = true;
                }
                return m_UserLayers;
            }

            set { m_UserLayers = value; UserLayersSpecified = true; }
        }

    }
}
