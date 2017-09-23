using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "Post", Namespace = Declarations.Wfs100NameSpace), Serializable]
    public partial class Post
    {

        private string _OnlineResource;

        [XmlAttribute(AttributeName = "onlineResource", DataType = "string", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string OnlineResource
        {
            get { return _OnlineResource; }
            set { _OnlineResource = value; }
        }


    }
}
