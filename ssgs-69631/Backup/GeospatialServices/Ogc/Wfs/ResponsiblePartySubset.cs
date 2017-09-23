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
    [XmlType(TypeName = "ResponsiblePartySubset", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class ResponsiblePartySubset
    {
        public ResponsiblePartySubset()
        {

        }

        private string _InidividualName;

        [XmlElement(ElementName = "InidividualName", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string InidividualName
        {
            get { return _InidividualName; }
            set { _InidividualName = value; }
        }


        private string _PositionName;

        [XmlElement(ElementName = "PositionName", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string PositionName
        {
            get { return _PositionName; }
            set { _PositionName = value; }
        }



        [XmlIgnore]
        [DataMember]
        public bool ContactInfoSpecified;

        private Contact _Contact;

        [XmlElement(ElementName = "ContactInfo", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(Contact))]
        [DataMember]
        public Contact ContactInfo
        {
            get
            {
                if (_Contact == null)
                {
                    _Contact = new Contact();
                    ContactInfoSpecified = true;
                }
                return _Contact;
            }
            set { _Contact = value; ContactInfoSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool RoleSpecified;

        private Code _Role;

        [XmlElement(ElementName = "Role",  Type = typeof(Code), Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        [DataMember]
        public Code Role
        {
            get
            {
                if (_Role == null)
                {
                    _Role = new Code();
                    RoleSpecified = true;
                }
                return _Role;
            }
            set { _Role = value; RoleSpecified = true; }
        }
    }
}
