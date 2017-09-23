using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace  GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "ExternalGraphic", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class ExternalGraphic
    {
        [XmlIgnore]
        public bool OnlineResourceSpecified;
        private OnlineResource m_OnlineResource;

        [XmlElement(Type = typeof(OnlineResource), ElementName = "OnlineResource", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.SeNameSpace)]
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
        public bool InlineContentSpecified;
        private InlineContent m_InlineContent;

        [XmlElement(Type = typeof(InlineContent), ElementName = "InlineContent", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public InlineContent InlineContent
        {
            get
            {
                if (m_InlineContent == null)
                {
                    m_InlineContent = new InlineContent();
                    InlineContentSpecified = true;
                }
                return m_InlineContent;
            }
            set { m_InlineContent = value; InlineContentSpecified = true; }
        }

        private string m_Format;

        [XmlElement(ElementName = "Format", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public string Format
        {
            get { return m_Format; }
            set { m_Format = value; }
        }

        [XmlIgnore]
        public bool ColorReplacementsSpecified;
        private List<Recode> m_ColourReplacements;


        [XmlElement(Type = typeof(Recode), ElementName = "ColorReplacement", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<Recode> ColourReplacements
        {
            get
            {
                if (m_ColourReplacements == null)
                {
                    m_ColourReplacements = new List<Recode>();
                    ColorReplacementsSpecified = true;
                }
                return m_ColourReplacements;
            }
            set { m_ColourReplacements = value; ColorReplacementsSpecified = true; }
        }
    }
}
