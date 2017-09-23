using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "ContactAddress", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class ContactAddress
    {
        private string m_AddressType;

        [XmlElement(ElementName = "AddressType", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string AddressType
        {
            get { return m_AddressType; }
            set { m_AddressType = value; }
        }
        private string m_Address;

        [XmlElement(ElementName = "Address", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }
        private string m_City;

        [XmlElement(ElementName = "City", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string City
        {
            get { return m_City; }
            set { m_City = value; }
        }
        private string m_StateOrProvince;

        [XmlElement(ElementName = "StateOrProvince", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string StateOrProvince
        {
            get { return m_StateOrProvince; }
            set { m_StateOrProvince = value; }
        }

        private string m_PostCode;
        [XmlElement(ElementName = "PostCode", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string PostCode
        {
            get { return m_PostCode; }
            set { m_PostCode = value; }
        }

        private string m_Country;
        [XmlElement(ElementName = "Country", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string Country
        {
            get { return m_Country; }
            set { m_Country = value; }
        }
    }
}
