using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [DataContract]
    [XmlInclude(typeof(PropertyIsBetween))]
    [XmlInclude(typeof(PropertyIsEqualTo))]
    [XmlInclude(typeof(PropertyIsGreaterThan))]
    [XmlInclude(typeof(PropertyIsGreaterThanOrEqualTo))]
    [XmlInclude(typeof(PropertyIsLessThan))]
    [XmlInclude(typeof(PropertyIsLessThanOrEqualTo))]
    [XmlInclude(typeof(PropertyIsLike))]
    [XmlInclude(typeof(PropertyIsNotEqualTo))]
    [XmlInclude(typeof(PropertyIsNull))]
    [XmlType(TypeName = "BaseComparisonOps", Namespace = Declarations.OgcNameSpace), Serializable]
    public abstract partial class BaseComparisonOps
    {
        

    }
}
