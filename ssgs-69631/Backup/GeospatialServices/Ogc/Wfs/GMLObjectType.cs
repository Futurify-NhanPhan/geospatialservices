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
    [XmlType(TypeName = "Operation", Namespace = Declarations.Wfs110NameSpace), Serializable]
    public partial class GMLObjectType
    {
        public GMLObjectType()
        {

        }

        private string _Name;

        [XmlElement(ElementName = "Name", Form = XmlSchemaForm.Unqualified, Type = typeof(string))]
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Title;

        [XmlElement(ElementName = "Title", Form = XmlSchemaForm.Unqualified, Type = typeof(string))]
        [DataMember]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Abstract;

        [XmlElement(ElementName = "Abstract", Form = XmlSchemaForm.Unqualified, Type = typeof(string))]
        [DataMember]
        public string Abstract
        {
            get { return _Abstract; }
            set { _Abstract = value; }
        }

        [XmlIgnore]
        [DataMember]
        public bool KeywordsListSpecified;

        private List<Keywords> _KeywordsList;

        [XmlElement(ElementName = "Keywords", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(Keywords))]
        [DataMember]
        public List<Keywords> KeywordsList
        {
            get
            {
                if (_KeywordsList == null)
                {
                    _KeywordsList = new List<Keywords>();
                    KeywordsListSpecified = true;
                }
                return _KeywordsList;
            }
            set { _KeywordsList = value; KeywordsListSpecified = true; }
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
        public bool OutputFormatsSpecified;

        private OutputFormatList _OutputFormats;

        [XmlElement(ElementName = "OutputFormats", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(OutputFormatList))]
        [DataMember]
        public OutputFormatList OutputFormats
        {
            get
            {
                if (_OutputFormats == null)
                {
                    _OutputFormats = new OutputFormatList() ;
                    OutputFormatsSpecified = true;
                }
                return _OutputFormats;
            }
            set { _OutputFormats = value; OutputFormatsSpecified = true; }
        }




    }
}
