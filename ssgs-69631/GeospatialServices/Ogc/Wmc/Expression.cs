using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Expression", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class Expression
    {
        public Expression()
        {
        }

        public Expression(string value)
        {
            m_Value = value;
        }
        
        
        private string m_Value;

        [XmlText(DataType = "string")]
        public string Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }
    }
}
