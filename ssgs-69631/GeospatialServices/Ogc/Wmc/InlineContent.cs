using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "InlineContent", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class InlineContent
    {
        private EncodingTypes m_Encoding;

        [XmlAttribute(AttributeName = "encoding")]
        public EncodingTypes Encoding
        {
            get { return m_Encoding; }
            set { m_Encoding = value; }
        }

        private XmlElement m_Any;

        [XmlAnyElement()]
        public XmlElement Any
        {
            get { return m_Any; }
            set { m_Any = value; }
        }
    }
}
