using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Format", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class Format
    {
        public Format()
        {
        }

        public Format(string formatName, int current)
        {
            m_FormatName = formatName;
            m_Current = current;
        }

        private string m_FormatName;

        [XmlText(DataType = "string")]
        public string FormatName
        {
            get { return m_FormatName; }
            set { m_FormatName = value; }
        }
        private int m_Current;
        [XmlAttribute(AttributeName = "current", DataType = "int")]
        public int Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }
    }
}
