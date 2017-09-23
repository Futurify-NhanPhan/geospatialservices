using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "Arithmetic_Operators", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Arithmetic_Operators
    {

        private Simple_Arithmetic _Simple_Arithmetic;

        [XmlElement(ElementName = "Simple_Arithmetic", Type = typeof(Simple_Arithmetic), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public Simple_Arithmetic Simple_Arithmetic
        {
            get { return _Simple_Arithmetic; }
            set { _Simple_Arithmetic = value; }
        }

        private Functions _Functions;

        [XmlElement(ElementName = "Functions", Type = typeof(Functions), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public Functions Functions
        {
            get { return _Functions; }
            set { _Functions = value; }
        }
        
    }
}
