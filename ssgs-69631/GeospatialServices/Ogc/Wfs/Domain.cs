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
    [XmlType(TypeName = "Domain", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class Domain
    {
        public Domain()
        {

        }

        public Domain(string name, string value)
        {
            this.Name = name;
            this.ValueList.Add(value);  
        }


        private string _Name;

        [XmlAttribute(AttributeName = "name", DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private List<string> _ValueList;

        [XmlElement(ElementName = "Value", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public List<string> ValueList
        {
            get
            {
                if (_ValueList == null)
                {
                    _ValueList = new List<string>();
                }
                return _ValueList;
            }
            set { _ValueList = value;}
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
