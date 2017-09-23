using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{
    [DataContract]
    [XmlType(TypeName = "Address", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class Address
    {
        public Address()
        {
            
        }


        [XmlIgnore]
        [DataMember]
        public bool DeliveryPointListSpecified;

        private List<string> _DeliveryPointList;

        [XmlElement(ElementName = "DeliveryPoint", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public List<string> DeliveryPointList
        {
            get
            {
                if (_DeliveryPointList == null)
                {
                    _DeliveryPointList = new List<string>();
                    DeliveryPointListSpecified = true;
                }
                return _DeliveryPointList;
            }
            set { _DeliveryPointList = value; DeliveryPointListSpecified = true; }
        }

        private string _City;

        [XmlElement(ElementName = "City", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        private string _AdministrativeArea;

        [XmlElement(ElementName = "AdministrativeArea", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string AdministrativeArea
        {
            get { return _AdministrativeArea; }
            set { _AdministrativeArea = value; }
        }

        private string _PostalCode;

        [XmlElement(ElementName = "PostalCode", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }

        private string _Country;

        [XmlElement(ElementName = "Country", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        [XmlIgnore]
        [DataMember]
        public bool ElectronicMailAddressSpecified;

        private List<string> _ElectronicMailAddressList;

        [XmlElement(ElementName = "ElectronicMailAddress", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public List<string> ElectronicMailAddressList
        {
            get
            {
                if (_ElectronicMailAddressList == null)
                {
                    _ElectronicMailAddressList = new List<string>();
                    ElectronicMailAddressSpecified = true;
                }
                return _ElectronicMailAddressList;
            }
            set { _ElectronicMailAddressList = value; ElectronicMailAddressSpecified = true; }
        }
       
    }
}


