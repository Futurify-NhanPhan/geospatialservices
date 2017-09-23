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
    [XmlType(TypeName = "Post", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class Post
    {

        private OnlineResource _OnlineResource;

        [XmlElement(Type = typeof(OnlineResource), ElementName = "OnlineResource", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public OnlineResource OnlineResource
        {
            get { return _OnlineResource; }
            set { _OnlineResource = value; }
        }


    }
}
