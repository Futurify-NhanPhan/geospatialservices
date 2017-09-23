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
    [XmlType(TypeName = "DCPType", Namespace = Declarations.Wfs110NameSpace), Serializable]
    public partial class DCPType
    {

        private HTTP _HTTP;

        [XmlElement(Type = typeof(HTTP), ElementName = "HTTP", IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember] public HTTP HTTP
        {
            get 
            {
                if (_HTTP == null)
                {
                    _HTTP = new HTTP(); 
                }

                return _HTTP; 
            }
            set { _HTTP = value; }
        }


    }
}
