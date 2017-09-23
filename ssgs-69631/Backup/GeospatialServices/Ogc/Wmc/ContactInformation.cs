using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{

    [XmlType(TypeName = "ContactInformation", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class ContactInformation
    {
        
        private ContactAddress m_ContactAddress;

        [XmlElement(Type = typeof(ContactAddress), ElementName = "ContactAddress", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public ContactAddress ContactAddress
        {
            get { return m_ContactAddress = (m_ContactAddress == null)? new ContactAddress(): m_ContactAddress; }
            set { m_ContactAddress = value; }
        }

        private string m_ContactVoiceTelephone;

        [XmlElement(ElementName = "ContactVoiceTelephone", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string ContactVoiceTelephone
        {
            get { return m_ContactVoiceTelephone; }
            set { m_ContactVoiceTelephone = value; }
        }

        private string m_ContactFacsimileTelephone;

        [XmlElement(ElementName = "ContactFacsimileTelephone", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string ContactFacsimileTelephone
        {
            get { return m_ContactFacsimileTelephone; }
            set { m_ContactFacsimileTelephone = value; }
        }

        private string m_ContactElectronicMailAddress;

        [XmlElement(ElementName = "ContactElectronicMailAddress", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string ContactElectronicMailAddress
        {
            get { return m_ContactElectronicMailAddress; }
            set { m_ContactElectronicMailAddress = value; }
        }

        private string m_ContactPosition;

        [XmlElement(ElementName = "ContactPosition", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string ContactPosition
        {
            get { return m_ContactPosition; }
            set { m_ContactPosition = value; }
        }

        private ContactPersonPrimary m_ContactPersonPrimary;
        
        [XmlElement(Type = typeof(ContactPersonPrimary), ElementName = "ContactPersonPrimary", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public ContactPersonPrimary ContactPersonPrimary
        {
            get { return m_ContactPersonPrimary = (m_ContactPersonPrimary == null) ? new ContactPersonPrimary() : m_ContactPersonPrimary; }
            set { m_ContactPersonPrimary = value; }
        }
    }
}
