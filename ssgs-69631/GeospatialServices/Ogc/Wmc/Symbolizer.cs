using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "BaseSymbolizer", Namespace = Declarations.SeNameSpace), Serializable]
    public abstract partial class BaseSymbolizer
    {
        [XmlAttribute(AttributeName = "version", DataType = "string")]
        private String m_Version;

        public String Version
        {
            get { return m_Version; }
            set { m_Version = value; }
        }


        [XmlAttribute(AttributeName = "uom", DataType = "string")]
        private string m_UOM;

        public string UOM
        {
            get { return m_UOM; }
            set { m_UOM = value; }
        }


        [XmlIgnore]
        public bool OnlineResourceSpecified;
        private OnlineResource m_OnlineResource;

        [XmlElement(Type = typeof(OnlineResource), ElementName = "OnlineResource", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
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
        
        
       
    }
}
