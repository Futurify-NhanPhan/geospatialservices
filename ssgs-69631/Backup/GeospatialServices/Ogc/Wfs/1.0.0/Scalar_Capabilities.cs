using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "Scalar_Capabilities", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Scalar_Capabilities
    {

        private Logical_Operators _Logical_Operators;

        [XmlElement(ElementName = "Logical_Operators", Type = typeof(Logical_Operators), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace=Declarations.OgcNameSpace)]
        public Logical_Operators Logical_Operators
        {
            get 
            {
                if (_Logical_Operators == null)
                {
                    _Logical_Operators = new Logical_Operators(); 
                }
                return _Logical_Operators; 
            }
            set { _Logical_Operators = value; }
        }

        private Comparison_Operators _Comparison_Operators;

        [XmlElement(ElementName = "Comparison_Operators", Type = typeof(Comparison_Operators), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public Comparison_Operators Comparison_Operators
        {
            get 
            {
                if (_Comparison_Operators == null)
                {
                    _Comparison_Operators = new Comparison_Operators(); 
                }
                return _Comparison_Operators; 
            }
            set { _Comparison_Operators = value; }
        }

        private  Arithmetic_Operators _Arithmetic_Operators;

        [XmlElement(ElementName = "Arithmetic_Operators", Type = typeof(Arithmetic_Operators), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public Arithmetic_Operators Arithmetic_Operators
        {
            get
            {
                if (_Arithmetic_Operators == null)
                {
                    _Arithmetic_Operators = new Arithmetic_Operators(); 
                }
                return _Arithmetic_Operators; 
            }
            set { _Arithmetic_Operators = value; }
        }


    }
}
