using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "ParameterValue", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class ParameterValue
    {

        [XmlIgnore]
        public bool ExpressionsSpecified ;
        private List<Expression> m_Expressions;
        
        [XmlElement(Type = typeof(Expression), ElementName = "Expression", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<Expression> Expressions
        {
            get
            {
                if (m_Expressions == null)
                {
                    m_Expressions = new List<Expression>();
                    ExpressionsSpecified = true;
                }
                return m_Expressions; }
                set { m_Expressions = value; ExpressionsSpecified = true;  }
        }
    }
}
