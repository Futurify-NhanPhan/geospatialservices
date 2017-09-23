using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms
{
    [DataContract]
    [XmlType(TypeName = "HTTP", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class HTTP
    {

        private Get _Get;

        [XmlElement(Type = typeof(Get), ElementName = "Get", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public Get Get
        {
            get { return _Get; }
            set { _Get = value; }
        }

        [XmlIgnore] 
        [DataMember] public bool PostSpecified;

        private Post _Post;

        [XmlElement(Type = typeof(Post), ElementName = "Post", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public Post Post
        {
            get 
            {
                if (_Post == null)
                {
                    _Post = new Post();
                    PostSpecified = true;
                }
                return _Post; 
            }
            set { _Post = value; PostSpecified = true; }
        }


    }
}
