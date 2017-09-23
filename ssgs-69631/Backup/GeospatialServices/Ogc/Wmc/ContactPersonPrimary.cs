using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "ContactPersonPrimary", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class ContactPersonPrimary
    {

        private string m_ContactPerson;

        [XmlElement(ElementName = "ContactPerson", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string ContactPerson
        {
            get { return m_ContactPerson; }
            set { m_ContactPerson = value; }
        }
        private string m_ContactOrganisation;

        [XmlElement(ElementName = "ContactOrganization", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string ContactOrganisation
        {
            get { return m_ContactOrganisation; }
            set { m_ContactOrganisation = value; }
        }
    }
}
