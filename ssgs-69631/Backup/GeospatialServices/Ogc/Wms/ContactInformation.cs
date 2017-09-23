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
    [XmlType(TypeName = "ContactInformation", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class ContactInformation
    {
        private ContactPersonPrimary _ContactPersonPrimary;

        [XmlElement(Type = typeof(ContactPersonPrimary), ElementName = "ContactPersonPrimary", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public ContactPersonPrimary ContactPersonPrimary
        {
            get { return _ContactPersonPrimary = (_ContactPersonPrimary == null) ? new ContactPersonPrimary() : _ContactPersonPrimary; }
            set { _ContactPersonPrimary = value; }
        }

        private string _ContactPosition;

        [XmlElement(ElementName = "ContactPosition", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string ContactPosition
        {
            get { return _ContactPosition; }
            set { _ContactPosition = value; }
        }
        
        private ContactAddress _ContactAddress;

        [XmlElement(Type = typeof(ContactAddress), ElementName = "ContactAddress", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public ContactAddress ContactAddress
        {
            get { return _ContactAddress = (_ContactAddress == null)? new ContactAddress(): _ContactAddress; }
            set { _ContactAddress = value; }
        }

        private string _ContactVoiceTelephone;

        [XmlElement(ElementName = "ContactVoiceTelephone", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string ContactVoiceTelephone
        {
            get { return _ContactVoiceTelephone; }
            set { _ContactVoiceTelephone = value; }
        }

        private string _ContactFacsimileTelephone;

        [XmlElement(ElementName = "ContactFacsimileTelephone", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string ContactFacsimileTelephone
        {
            get { return _ContactFacsimileTelephone; }
            set { _ContactFacsimileTelephone = value; }
        }

        private string _ContactElectronicMailAddress;

        [XmlElement(ElementName = "ContactElectronicMailAddress", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string ContactElectronicMailAddress
        {
            get { return _ContactElectronicMailAddress; }
            set { _ContactElectronicMailAddress = value; }
        }
        
    }
}
