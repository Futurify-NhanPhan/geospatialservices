using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "MetadataURL", Namespace = Declarations.Wfs100NameSpace), Serializable]
    public partial class MetadataURL
    {

        private string _Type;

        [XmlAttribute(AttributeName = "type", DataType = "string", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _Format;

        [XmlAttribute(AttributeName = "format", DataType = "string", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string Format
        {
            get { return _Format; }
            set { _Format = value; }
        }


    }
}
