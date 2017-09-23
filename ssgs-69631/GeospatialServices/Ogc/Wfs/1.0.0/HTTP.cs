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
    [XmlType(TypeName = "HTTP", Namespace = Declarations.Wfs100DefaultNameSpace), Serializable]
    public partial class HTTP
    {      

        private Get _Get;

        [XmlElement(Type = typeof(Get), ElementName = "Get", IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public Get Get
        {
            get { return _Get; }
            set {_Get = value; }
        }


        private Post _Post;

        [XmlElement(Type = typeof(Post), ElementName = "Post", IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public Post Post
        {
            get { return _Post;  }
            set { _Post = value; }
        }

     }
   
}
