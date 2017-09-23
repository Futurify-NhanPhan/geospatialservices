using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Mark", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class Mark
    {
        private string m_WellKnownName;
        [XmlElement(ElementName = "WellKnownName", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public string WellKnownName
        {
            get { return m_WellKnownName; }
            set { m_WellKnownName = value; }
        }

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


        [XmlIgnore]
        public bool FormatSpecified;
        private string m_Format;
        [XmlElement(ElementName = "Format", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public string Format
        {
            get { return m_Format; }
            set { m_Format = value; FormatSpecified = true;}
        }

        [XmlIgnore]
        public bool MarkIndexSpecified;
        private int m_MarkIndex;
        [XmlElement(ElementName = "MarkIndex", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public int MarkIndex
        {
            get { return m_MarkIndex; }
            set { m_MarkIndex = value; MarkIndexSpecified = true;}
        }

        [XmlIgnore]
        public bool FillSpecified;
        private Fill m_Fill;

        [XmlElement(Type = typeof(Fill), ElementName = "Fill", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Fill Fill
        {
            get
            {
                if (m_Fill == null)
                {
                    m_Fill = new Fill();
                    FillSpecified = true;
                }
                return m_Fill;
            }
            set { m_Fill = value; FillSpecified = true; }
        }

        //[XmlIgnore]
        //public bool StrokeSpecified;
        //private Stroke m_Stroke;

        //[XmlElement(Type = typeof(Stroke), ElementName = "Fill", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        //public Stroke Stroke
        //{
        //    get
        //    {
        //        if (m_Stroke == null)
        //        {
        //            m_Stroke = new Stroke(); 
        //            StrokeSpecified = true;
        //        }
        //        return m_Stroke; }
        //    set { m_Stroke = value; StrokeSpecified = true; }
        //}
    }
}
