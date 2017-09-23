using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "URL", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class URL
    {
        [XmlIgnore]
        public bool WidthSpecified = false ;
        private int m_Width;

        [XmlAttribute(AttributeName = "width", DataType = "int", Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public int Width
        {
            get { return m_Width; }
            set { m_Width = value; WidthSpecified = true; }
        }

        [XmlIgnore]
        public bool HeightSpecified = false;
        private int m_Height;
        
        [XmlAttribute(AttributeName = "height", DataType = "int", Form=XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public int Height
        {
            get { return m_Height; }
            set { m_Height = value; HeightSpecified = true; }
        }

        [XmlIgnore]
        public bool FormatSpecified = false;
        private string m_Format;

        [XmlAttribute(AttributeName = "format", DataType = "string", Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public string Format
        {
            get { return m_Format; }
            set { m_Format = value; FormatSpecified = true; }
        }
        
        private OnlineResource m_OnlineResource;
        
        [XmlElement(Type = typeof(OnlineResource), ElementName = "OnlineResource", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public OnlineResource OnlineResource
        {
            get { return m_OnlineResource = (m_OnlineResource == null) ? new OnlineResource() : m_OnlineResource; }
            set { m_OnlineResource = value; }
        }
    }
}
