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
    [XmlType(TypeName = "ContactPersonPrimary", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class ContactPersonPrimary
    {

        private string _ContactPerson;

        [XmlElement(ElementName = "ContactPerson", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string ContactPerson
        {
            get { return _ContactPerson; }
            set { _ContactPerson = value; }
        }
        private string _ContactOrganisation;

        [XmlElement(ElementName = "ContactOrganization", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string ContactOrganisation
        {
            get { return _ContactOrganisation; }
            set { _ContactOrganisation = value; }
        }
    }
}
