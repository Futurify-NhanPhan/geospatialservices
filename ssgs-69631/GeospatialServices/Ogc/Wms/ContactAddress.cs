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
    [XmlType(TypeName = "ContactAddress", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class ContactAddress
    {
        private string _AddressType;

        [XmlElement(ElementName = "AddressType", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string AddressType
        {
            get { return _AddressType; }
            set { _AddressType = value; }
        }
        private string _Address;

        [XmlElement(ElementName = "Address", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _City;

        [XmlElement(ElementName = "City", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        private string _StateOrProvince;

        [XmlElement(ElementName = "StateOrProvince", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string StateOrProvince
        {
            get { return _StateOrProvince; }
            set { _StateOrProvince = value; }
        }

        private string _PostCode;
        [XmlElement(ElementName = "PostCode", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string PostCode
        {
            get { return _PostCode; }
            set { _PostCode = value; }
        }

        private string _Country;
        [XmlElement(ElementName = "Country", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
    }
}
