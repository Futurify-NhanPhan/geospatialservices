using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [DataContract]
    [XmlType(TypeName = "PropertyIsEqualTo", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class PropertyIsEqualTo : BaseComparisonOps
    {
        [XmlIgnore]
        [DataMember]
        public bool PropertyNameSpecified;
        private string _PropertyName;

        [DataMember]
        [XmlElement(Type = typeof(string), ElementName = "PropertyName", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public string PropertyName
        {
            get { return _PropertyName; }
            set { _PropertyName = value; PropertyNameSpecified = true; }
        }

        [XmlIgnore]
        [DataMember]
        public bool LiteralSpecified;
        private Literal _Literal;


        [DataMember]
        [XmlElement(Type = typeof(Literal), ElementName = "Literal", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public Literal Literal
        {
            get
            {
                if (_Literal == null)
                {
                    _Literal = new Literal();
                    LiteralSpecified = true;
                }
                return _Literal;
            }
            set { _Literal = value; LiteralSpecified = true; }
        }
    }
}
