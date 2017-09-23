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
    [XmlType(TypeName = "OperationsMetadata", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class OperationsMetadata
    {
        public OperationsMetadata()
        {

        }

        private List<Operation> _OperationList;

        [XmlElement(ElementName = "Operation", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(Operation))]
        [DataMember]
        public List<Operation> OperationList
        {
            get
            {
                if (_OperationList == null)
                {
                    _OperationList = new List<Operation>();
                }
                return _OperationList;
            }
            set { _OperationList = value; }
        }


        [XmlIgnore]
        [DataMember]
        public bool ParameterListSpecified;

        private List<Domain> _ParameterList;

        [XmlElement(ElementName = "Parameter", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(Domain))]
        [DataMember]
        public List<Domain> ParameterList
        {
            get
            {
                if (_ParameterList == null)
                {
                    _ParameterList = new List<Domain>();
                    ParameterListSpecified = true;
                }
                return _ParameterList;
            }
            set { _ParameterList = value; ParameterListSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool ConstraintListSpecified;

        private List<Domain> _ConstraintList;

        [XmlElement(ElementName = "Constraint", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(Domain))]
        [DataMember]
        public List<Domain> ConstraintList
        {
            get
            {
                if (_ConstraintList == null)
                {
                    _ConstraintList = new List<Domain>();
                    ConstraintListSpecified = true;
                }
                return _ConstraintList;
            }
            set { _ConstraintList = value; ConstraintListSpecified = true; }
        }


        [XmlIgnore]
        [DataMember]
        public bool ExtendedCapabilitiesListSpecified;

        private List<ExtendedCapabilities> _ExtendedCapabilitiesList;

        [XmlElement(ElementName = "ExtendedCapabilities", Type = typeof(ExtendedCapabilities), Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        [DataMember]
        public List<ExtendedCapabilities> ExtendedCapabilitiesList
        {
            get
            {
                if (_ExtendedCapabilitiesList == null)
                {
                    _ExtendedCapabilitiesList = new List<ExtendedCapabilities>();
                    ExtendedCapabilitiesListSpecified = true;
                }
                return _ExtendedCapabilitiesList;
            }
            set { _ExtendedCapabilitiesList = value; ExtendedCapabilitiesListSpecified = true; }
        }




    }
}
