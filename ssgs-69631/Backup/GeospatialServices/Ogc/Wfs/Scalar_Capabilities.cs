using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{
    [DataContract]
    [XmlType(TypeName = "Scalar_Capabilities", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Scalar_Capabilities
    {


        private LogicalOperators _LogicalOperators;

        [XmlElement(ElementName = "LogicalOperators", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(LogicalOperators))]
        [DataMember]
        public LogicalOperators LogicalOperators
        {
            get
            {
                if (_LogicalOperators == null)
                {
                    _LogicalOperators = new LogicalOperators();
                }
                return _LogicalOperators;
            }
            set { _LogicalOperators = value; }
        }


        private ComparisonOperators _ComparisonOperators;

        [XmlElement(ElementName = "ComparisonOperators", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(ComparisonOperators))]
        [DataMember]
        public ComparisonOperators ComparisonOperators
        {
            get
            {
                if (_ComparisonOperators == null)
                {
                    _ComparisonOperators = new ComparisonOperators();
                }
                return _ComparisonOperators;
            }
            set { _ComparisonOperators = value; }
        }


        private ArithmeticOperators _ArithmeticOperators;

        [XmlElement(ElementName = "ArithmeticOperators", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(ArithmeticOperators))]
        [DataMember]
        public ArithmeticOperators ArithmeticOperators
        {
            get
            {
                if (_ArithmeticOperators == null)
                {
                    _ArithmeticOperators = new ArithmeticOperators ();
                }
                return _ArithmeticOperators;
            }
            set { _ArithmeticOperators = value; }
        }

    }
}
