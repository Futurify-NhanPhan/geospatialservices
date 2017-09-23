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
    [XmlType(TypeName = "ServiceProvider", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class ServiceProvider
    {
        public ServiceProvider()
        {

        }

        private string _ProviderName;

        [XmlElement(ElementName = "ProviderName", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string ProviderName
        {
            get { return _ProviderName; }
            set { _ProviderName = value; }
        }


        [XmlIgnore]
        [DataMember]
        public bool ProviderSiteSpecified;

        private OnlineResource _ProviderSite;

        [XmlElement(ElementName = "ProviderSite", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(OnlineResource))]
        [DataMember]
        public OnlineResource ProviderSite
        {
            get
            {
                if (_ProviderSite == null)
                {
                    _ProviderSite = new OnlineResource();
                    ProviderSiteSpecified = true;
                }
                return _ProviderSite;
            }
            set { _ProviderSite = value; ProviderSiteSpecified = true; }
        }



        

        [XmlIgnore]
        [DataMember]
        public bool ServiceContactSpecified;

        private ResponsiblePartySubset _ServiceContact;

        [XmlElement(ElementName = "ServiceContact", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(ResponsiblePartySubset))]
        [DataMember]
        public ResponsiblePartySubset ServiceContact
        {
            get
            {
                if (_ServiceContact == null)
                {
                    _ServiceContact = new ResponsiblePartySubset();
                    ServiceContactSpecified = true;
                }
                return _ServiceContact;
            }
            set { _ServiceContact = value; ServiceContactSpecified = true; }
        }

    }
}
