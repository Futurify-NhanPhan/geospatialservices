using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{
    [DataContract]
    [XmlType(TypeName = "ArithmeticOperators", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class ArithmeticOperators
    {

        private SimpleArithmetic _SimpleArithmetic;

        [XmlElement(ElementName = "SimpleArithmetic",Type = typeof(SimpleArithmetic), Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [DataMember]
        public SimpleArithmetic SimpleArithmetic
        {
            get { return _SimpleArithmetic; }
            set { _SimpleArithmetic = value; }
        }

        private Functions _Functions;

        [XmlElement(ElementName = "Functions", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(Functions))]
        [DataMember]
        public Functions Functions
        {
            get
            {
                if (_Functions == null)
                {
                    _Functions = new Functions();
                }
                return _Functions;
            }
            set { _Functions = value; }
        }

    }
}
