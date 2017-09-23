using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "PropertyIsNull", Namespace = Declarations.OgcNameSpace), Serializable]
    [DataContract]
    public partial class PropertyIsNull : BaseComparisonOps
    {
        [XmlIgnore]
        [DataMember]
        public bool PropertyNameSpecified;
        private string _PropertyName;

        [XmlElement(Type = typeof(string), ElementName = "PropertyName", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [DataMember]
        public string PropertyName
        {
            get { return _PropertyName; }
            set { _PropertyName = value; PropertyNameSpecified = true; }
        }
        
    }
}
