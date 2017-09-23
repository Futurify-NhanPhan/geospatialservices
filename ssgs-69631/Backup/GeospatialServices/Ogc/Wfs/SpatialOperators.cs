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
    [XmlType(TypeName = "SpatialOperators", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class SpatialOperators
    {

        private List<SpatialOperator> _SpatialOperatorList;

        [XmlElement(ElementName = "SpatialOperatorList", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(SpatialOperator))]
        [DataMember]
        public List<SpatialOperator> SpatialOperatorList
        {
            get
            {
                if (_SpatialOperatorList == null)
                {
                    _SpatialOperatorList = new List<SpatialOperator>();
                }
                return _SpatialOperatorList;
            }
            set { _SpatialOperatorList = value; }
        }

    }
}
