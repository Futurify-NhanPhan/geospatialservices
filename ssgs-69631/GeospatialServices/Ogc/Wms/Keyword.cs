using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms
{
    [DataContract]
    [XmlType(TypeName = "Keyword", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class Keyword
    {
        public Keyword()
        {
        
        }

        public Keyword(string vocabulary)
        {
            _Vocabulary = vocabulary; 
        }

        private string _Vocabulary;

        [XmlAttribute(AttributeName = "vocabulary", DataType = "string")]
        [DataMember] public string Vocabulary
        {
            get { return _Vocabulary; }
            set { _Vocabulary = value; }
        }
    }
}
