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
    [XmlType(TypeName = "DCPType", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class DCPType
    {

        private HTTP _HTTP;

        [XmlElement(Type = typeof(HTTP), ElementName = "HTTP", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public HTTP HTTP
        {
            get { return _HTTP; }
            set { _HTTP = value; }
        }
    }
}
