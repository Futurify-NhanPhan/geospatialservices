using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Literal", Namespace = Declarations.OgcNameSpace), Serializable]
    [DataContract]
    public partial class Literal
    {
        private string _Value;
        
        [XmlText()]
        [DataMember]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
}
