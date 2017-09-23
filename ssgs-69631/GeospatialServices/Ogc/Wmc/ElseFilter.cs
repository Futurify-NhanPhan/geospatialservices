using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "ElseFilter", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class ElseFilter
    {
        public ElseFilter()
        {
        }

        public ElseFilter(string expression)
        {
            m_Expression = expression;
        }

        private string m_Expression;

        [XmlElement(ElementName = "Expression", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public string Expression
        {
            get { return m_Expression; }
            set { m_Expression = value; }
        }

    }
}
