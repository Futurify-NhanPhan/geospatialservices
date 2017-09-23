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
    [XmlType(TypeName = "ComparisonOperators", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class ComparisonOperators
    {

        private List<ComparisonOperatorTypes> _ComparisonOperatorList;

        [XmlElement(ElementName = "ComparisonOperator", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [DataMember]
        public List<ComparisonOperatorTypes> ComparisonOperatorList
        {
            get
            {
                if (_ComparisonOperatorList == null)
                {
                    _ComparisonOperatorList = new List<ComparisonOperatorTypes>();
                }
                return _ComparisonOperatorList;
            }
            set { _ComparisonOperatorList = value; }
        }

    }
}
