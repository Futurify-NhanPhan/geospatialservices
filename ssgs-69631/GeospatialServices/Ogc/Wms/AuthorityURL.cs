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
    [XmlType(TypeName = "AuthorityURL", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class AuthorityURL
    {
       
        [XmlIgnore]
        [DataMember] public bool NameSpecified = false;
        private string _Name;

        [XmlAttribute(AttributeName = "name", DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string Name
        {
            get { return _Name; }
            set { _Name = value; NameSpecified = true; }
        }

        private OnlineResource _OnlineResource;

        [XmlElement(Type = typeof(OnlineResource), ElementName = "OnlineResource", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public OnlineResource OnlineResource
        {
            get { return _OnlineResource = (_OnlineResource == null) ? new OnlineResource() : _OnlineResource; }
            set { _OnlineResource = value; }
        }
    }
}
