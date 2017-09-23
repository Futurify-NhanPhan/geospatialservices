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
    [XmlType(TypeName = "Telephone", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class Telephone
    {
        public Telephone()
        {

        }

        [XmlIgnore]
        [DataMember] 
        public bool VoiceListSpecified;

        private List<string> _VoiceList;

        [XmlElement(ElementName = "Voice", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public List<string> VoiceList
        {
            get
            {
                if (_VoiceList == null)
                {
                    _VoiceList = new List<string>();
                    VoiceListSpecified = true;
                }
                return _VoiceList;
            }
            set { _VoiceList = value; VoiceListSpecified = true;}
        }

        [XmlIgnore]
        [DataMember]
        public bool FascimileListSpecified;

        private List<string> _FascimileList;

        [XmlElement(ElementName = "Fascimile", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace, Type = typeof(string))]
        [DataMember]
        public List<string> FascimileList
        {
            get
            {
                if (_FascimileList == null)
                {
                    _FascimileList = new List<string>();
                    FascimileListSpecified = true;
                }
                return _FascimileList;
            }
            set { _FascimileList = value; FascimileListSpecified = true;}
        }

 

    }
}
