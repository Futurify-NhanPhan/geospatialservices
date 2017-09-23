using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Style", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class Style
    {

        [XmlIgnore]
        public bool CurrentSpecified;
        private int m_Current;

        [XmlAttribute(AttributeName = "current", DataType = "int")]
        public int Current
        {
            get { return m_Current; }
            set { m_Current = value; CurrentSpecified = true; }
        }

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
            set { m_Title = value; TitleSpecified = true; }
        }

        [XmlIgnore] 
        public bool AbstractSpecified = true;
        private string m_Abstract;

        [XmlElement(ElementName = "Abstract", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string Abstract
        {
            get { return m_Abstract; }
            set { m_Abstract = value; AbstractSpecified = true; }
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
        public bool SLDSpecified;


        private SLD m_SLD;

        [XmlElement(Type = typeof(SLD), ElementName = "SLD", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public SLD SLD
        {
            get
            {
                if (m_SLD == null)
                {
                    m_SLD = new SLD();
                    SLDSpecified = true;
                }
                return m_SLD;
            }
            set { m_SLD = value; SLDSpecified = true; }
        }

    }
}
