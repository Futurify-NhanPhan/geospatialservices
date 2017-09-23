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
    [XmlType(TypeName = "Operation", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class Operation
    {
        public Operation()
        {

        }

        private string _Name;

        [XmlAttribute(AttributeName = "name", DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        
        private List<DCP> _DCPList;

        [XmlElement(ElementName = "DCP", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(DCP))]
        [DataMember]
        public List<DCP> DCPList
        {
            get
            {
                if (_DCPList == null)
                {
                    _DCPList = new List<DCP>();
                }
                return _DCPList;
            }
            set { _DCPList = value; }
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
        public bool MetadataListSpecified;

        private List<Metadata> _MetadataList;

        [XmlElement(ElementName = "Metadata", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(Metadata))]
        [DataMember]
        public List<Metadata> MetadataList
        {
            get
            {
                if (_MetadataList == null)
                {
                    _MetadataList = new List<Metadata>();
                    MetadataListSpecified = true;
                }
                return _MetadataList;
            }
            set { _MetadataList = value; MetadataListSpecified = true; }
        }




    }
}
