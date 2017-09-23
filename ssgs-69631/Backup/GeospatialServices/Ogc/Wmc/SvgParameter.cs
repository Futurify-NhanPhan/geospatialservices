using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "SvgParameter", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class SvgParameter
    {
        public SvgParameter()
        {
        }

        public SvgParameter(string name, string expression)
        {
            m_Name = name;
            m_Expression = expression;
        }

        private string m_Name;

        [XmlAttribute(AttributeName = "name", DataType = "string")]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        
        private string m_Expression;

        [XmlText()]
        public string Expression
        {
            get
            {return m_Expression;}
            set { m_Expression = value;}
        }
    }
}
