using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{
    [DataContract]
    [XmlType(TypeName = "HTTP", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class HTTP
    {

        private RequestMethod  _Get;

        [XmlElement(Type = typeof(RequestMethod), ElementName = "Get", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace=Declarations.OwsNameSpace)]
        [DataMember]
        public RequestMethod Get
        {
            get 
            {
                if (_Get == null)
                {
                    _Get = new RequestMethod(); 
                }
                return _Get; 
            }
            set { _Get = value; }
        }


        private RequestMethod _Post;

        [XmlElement(Type = typeof(RequestMethod), ElementName = "Post", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        [DataMember]
        public RequestMethod Post
        {
            get 
            {
                if (_Post == null)
                {
                    _Post = new RequestMethod(); 
                }
                return _Post; 
            }
            set { _Post = value; }
        }

    }
}
