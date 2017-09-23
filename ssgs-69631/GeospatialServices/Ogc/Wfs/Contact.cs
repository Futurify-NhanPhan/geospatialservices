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
    [XmlType(TypeName = "Contact", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class Contact
    {
        public Contact()
        {

        }

        [XmlIgnore]
        [DataMember]
        public bool PhoneSpecified;

        private Telephone _Phone;

        [XmlElement(ElementName = "Phone", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(Telephone))]
        [DataMember]
        public Telephone Phone
        {
            get 
            {
                if (_Phone == null)
                {
                    _Phone = new Telephone();
                    PhoneSpecified = true;
                }
                return _Phone; 
            }
            set { _Phone = value; PhoneSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool AddressSpecified;

        private Address _Address;

        [XmlElement(ElementName = "Address", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(Address))]
        [DataMember]
        public Address Address
        {
            get
            {
                if (_Address == null)
                {
                    _Address = new Address();
                    AddressSpecified = true;
                }
                return _Address;
            }
            set { _Address = value; AddressSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool OnlineResourceSpecified;

        private OnlineResource _OnlineResource;

        [XmlElement(ElementName = "OnlineResource", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(OnlineResource))]
        [DataMember]
        public OnlineResource OnlineResource
        {
            get
            {
                if (_OnlineResource == null)
                {
                    _OnlineResource = new OnlineResource();
                    OnlineResourceSpecified = true;
                }
                return _OnlineResource;
            }
            set { _OnlineResource = value; OnlineResourceSpecified = true; }
        }



        private string _HoursOfService;

        [XmlElement(ElementName = "HoursOfService", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string HoursOfService
        {
            get { return _HoursOfService; }
            set { _HoursOfService = value; }
        }

        private string _ContactInstructions;

        [XmlElement(ElementName = "ContactInstructions", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string AdministrativeArea
        {
            get { return _ContactInstructions; }
            set { _ContactInstructions = value; }
        }
    }
}


