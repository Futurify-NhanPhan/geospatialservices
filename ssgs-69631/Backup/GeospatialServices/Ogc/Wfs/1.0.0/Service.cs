using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "Service", Namespace = Declarations.Wfs100DefaultNameSpace), Serializable]
    public partial class Service
    {
        public Service()
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

        private string _Keywords;

        [XmlElement(ElementName = "Keywords", Form = XmlSchemaForm.Unqualified, Type = typeof(string))]
        [DataMember]
        public string Keywords
        {
            get { return _Keywords; }
            set { _Keywords = value; }
        }


        private string _OnlineResource;

        [XmlElement(Type = typeof(string), ElementName = "OnlineResource", IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string OnlineResource
        {
            get { return _OnlineResource; }
            set
            {
                _OnlineResource = value;
            }
        }


        private string _Fees;

        [XmlElement(Type = typeof(string), ElementName = "Fees", IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string Fees
        {
            get { return _Fees; }
            set
            {
                _Fees = value;
            }
        }


        private string _AccessConstraints;

        [XmlElement(Type = typeof(string), ElementName = "AccessConstraints", IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string AccessConstraints
        {
            get { return _AccessConstraints; }
            set
            {
                _AccessConstraints = value;
            }
        }
            
    }
}
