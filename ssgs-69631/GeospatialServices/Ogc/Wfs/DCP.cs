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
    [XmlType(TypeName = "DCP", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class DCP
    {

        private HTTP _HTTP;

        [XmlElement(Type = typeof(HTTP), ElementName = "HTTP", IsNullable = false, Form = XmlSchemaForm.Qualified,Namespace = Declarations.OwsNameSpace)]
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
