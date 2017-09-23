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
    [XmlType(TypeName = "OutputFormatList", Namespace = Declarations.Wfs110NameSpace ), Serializable]
    public partial class OutputFormatList
    {
        public OutputFormatList()
        {

        }

        private List<string> _FormatList;

        [XmlElement(ElementName = "Format", Form = XmlSchemaForm.Unqualified, Type = typeof(string))]
        [DataMember]
        public List<string> FormatList
        {
            get
            {
                if (_FormatList == null)
                {
                    _FormatList = new List<string>();
                }
                return _FormatList;
            }
            set { _FormatList = value; }
        }

    }
}
