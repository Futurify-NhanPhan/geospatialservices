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
    [XmlType(TypeName = "ServiceIdentification", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class ServiceIdentification
    {
        public ServiceIdentification()
        {

        }

        private string _Title;

        [XmlElement(ElementName = "Title", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Abstract;

        [XmlElement(ElementName = "Abstract", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public string Abstract
        {
            get { return _Abstract; }
            set { _Abstract = value; }
        }

        [XmlIgnore]
        [DataMember]
        public bool KeywordsSpecified;

        private Keywords _Keywords;

        [XmlElement(ElementName = "Keywords", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(Keywords))]
        [DataMember]
        public Keywords Keywords
        {
            get
            {
                if (_Keywords == null)
                {
                    _Keywords = new Keywords();
                    KeywordsSpecified = true;
                }
                return _Keywords;
            }
            set { _Keywords = value; KeywordsSpecified = true; }
        }

        private Code _ServiceType;

        [XmlElement(ElementName = "ServiceType",Type = typeof(Code), Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        [DataMember]
        public Code ServiceType
        {
            get
            {
                if (_ServiceType == null)
                {
                    _ServiceType = new Code();
                    
                }
                return _ServiceType;
            }
            set { _ServiceType = value; }
        }


        private List<string> _ServiceTypeVersionList;

        [XmlElement(ElementName = "ServiceTypeVersion", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public List<string> ServiceTypeVersionList
        {
            get
            {
                if (_ServiceTypeVersionList == null)
                {
                    _ServiceTypeVersionList = new List<string>();
                }
                return _ServiceTypeVersionList;
            }
            set { _ServiceTypeVersionList = value; }
        }


        private string _Fees;

        [XmlElement(Type = typeof(string), ElementName = "Fees", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace=Declarations.OwsNameSpace)]
        [DataMember]
        public string Fees
        {
            get { return _Fees; }
            set
            {
                _Fees = value;
            }
        }


        private List<string> _AccessConstraints;

        [XmlElement(Type = typeof(string), ElementName = "AccessConstraints", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        [DataMember]
        public List<string> AccessConstraints
        {
            get 
            {
                if (_AccessConstraints == null)
                {
                    _AccessConstraints = new List<string>(); 
                }
                return _AccessConstraints; 
            }
            set
            {
                _AccessConstraints = value;
            }
        }
            
    }
}
