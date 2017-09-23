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
    [XmlType(TypeName = "Comparison_Operators", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Comparison_Operators
    {

        private Simple_Comparisons _SimpleComparisons;

        [XmlElement(ElementName = "Simple_Comparisons", Type = typeof(Simple_Comparisons), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public Simple_Comparisons Simple_Comparisons
        {
            get { return _SimpleComparisons; }
            set { _SimpleComparisons = value; }
        }
        
        private Like _Like;

        [XmlElement(ElementName = "Like", Type = typeof(Like), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public Like Like
        {
            get { return _Like; }
            set { _Like = value; }
        }
        

        private Between _Between;

        [XmlElement(ElementName = "Between", Type = typeof(Between), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public Between Between
        {
            get { return _Between; }
            set { _Between = value; }
        }


        private NullCheck _NullCheck;

        [XmlElement(ElementName = "NullCheck", Type = typeof(NullCheck), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public NullCheck NullCheck
        {
            get { return _NullCheck; }
            set { _NullCheck = value; }
        }


    }
}
