using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [KnownType(typeof(PropertyIsBetween))]
    [KnownType(typeof(PropertyIsEqualTo))]
    [KnownType(typeof(PropertyIsGreaterThan))]
    [KnownType(typeof(PropertyIsGreaterThanOrEqualTo))]
    [KnownType(typeof(PropertyIsLessThan))]
    [KnownType(typeof(PropertyIsLessThanOrEqualTo))]
    [KnownType(typeof(PropertyIsLike))]
    [KnownType(typeof(PropertyIsNotEqualTo))]
    [KnownType(typeof(PropertyIsNull))]
    [XmlInclude(typeof(PropertyIsBetween))]
    [XmlInclude(typeof(PropertyIsEqualTo))]
    [XmlInclude(typeof(PropertyIsGreaterThan))]
    [XmlInclude(typeof(PropertyIsGreaterThanOrEqualTo))]
    [XmlInclude(typeof(PropertyIsLessThan))]
    [XmlInclude(typeof(PropertyIsLessThanOrEqualTo))]
    [XmlInclude(typeof(PropertyIsLike))]
    [XmlInclude(typeof(PropertyIsNotEqualTo))]
    [XmlInclude(typeof(PropertyIsNull))]
    [DataContract]
    [XmlType(TypeName = "Filter", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Filter
    {
        public Filter()
        {
        }

        [XmlIgnore]
        [DataMember]
        public bool FilterExpressionSpecified;

        [XmlIgnore]
        [DataMember]
        public FilterTypes FilterSelection;

        private BaseComparisonOps _FilterExpression;

        [DataMember]
        [XmlChoiceIdentifier(MemberName = "FilterSelection")]
        [XmlElement(ElementName = "PropertyIsBetween", Type = typeof(PropertyIsBetween), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [XmlElement(ElementName = "PropertyIsEqualTo", Type = typeof(PropertyIsEqualTo), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [XmlElement(ElementName = "PropertyIsGreaterThan", Type = typeof(PropertyIsGreaterThan), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [XmlElement(ElementName = "PropertyIsGreaterThanOrEqualTo", Type = typeof(PropertyIsGreaterThanOrEqualTo), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [XmlElement(ElementName = "PropertyIsLessThan", Type = typeof(PropertyIsLessThan), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [XmlElement(ElementName = "PropertyIsLessThanOrEqualTo", Type = typeof(PropertyIsLessThanOrEqualTo), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [XmlElement(ElementName = "PropertyIsLike", Type = typeof(PropertyIsLike), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [XmlElement(ElementName = "PropertyIsNotEqualTo", Type = typeof(PropertyIsNotEqualTo), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [XmlElement(ElementName = "PropertyIsNull", Type = typeof(PropertyIsNull), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]


        public BaseComparisonOps FilterExpression
        {
            get { return _FilterExpression; }
            set
            {
                _FilterExpression = value;
                FilterExpressionSpecified = true;
            }
        }
    }
}
