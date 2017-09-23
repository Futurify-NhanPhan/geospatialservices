using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "FunctionName", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class FunctionName
    {


        public FunctionName()
        {
        }

        public FunctionName(string value)
        {
            _Value = value;
        }

        private string _nArgs;

        [XmlAttribute(AttributeName = "nArgs", DataType = "string")]
        [DataMember]
        public string nArgs
        {
            get { return _nArgs; }
            set { _nArgs = value; }
        }


        private string _Value;

        [XmlText(DataType = "string")]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }


    }

}
