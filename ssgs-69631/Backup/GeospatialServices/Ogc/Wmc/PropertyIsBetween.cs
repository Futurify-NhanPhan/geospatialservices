using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "PropertyIsBetween", Namespace = Declarations.OgcNameSpace), Serializable]
    [DataContract]
    public partial class PropertyIsBetween : BaseComparisonOps 
    {
        [XmlIgnore]
        [DataMember]
        public bool PropertyNameSpecified;
        private string _PropertyName;

        [XmlElement(Type = typeof(string), ElementName = "PropertyName", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [DataMember]
        public string PropertyName 
        {
            get { return _PropertyName;}
            set { _PropertyName = value; PropertyNameSpecified = true; }
        }

        [XmlIgnore]
        [DataMember]
        public bool UpperBoundarySpecified;
        private Literal _UpperBoundary;

        [XmlElement(Type = typeof(Literal), ElementName = "UpperBoundary", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [DataMember]
        public Literal UpperBoundary
        {
            get 
            {
                if (_UpperBoundary == null)
                {
                    _UpperBoundary = new Literal();
                    UpperBoundarySpecified = true;
                }
                return _UpperBoundary; 
            }
            set { _UpperBoundary = value; UpperBoundarySpecified = true; }
        }

        [XmlIgnore]
        [DataMember]
        public bool LowerBoundarySpecified;
        private Literal _LowerBoundary;

        [XmlElement(Type = typeof(Literal), ElementName = "LowerBoundary", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [DataMember]
        public Literal LowerBoundary
        {
            get 
            {
                if (_LowerBoundary == null)
                {
                    _LowerBoundary = new Literal();
                    LowerBoundarySpecified = true;
                }
                return _LowerBoundary; 
            }
            set { _LowerBoundary = value; LowerBoundarySpecified = true; }
        }
        
    }
}
