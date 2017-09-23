using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms
{
    [DataContract]
    [XmlType(TypeName = "Exception", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class Exception
    {
        [XmlIgnore]
        [DataMember] public bool FormatListSpecified;

        private List<string> _FormatList;

        [XmlElement(ElementName = "Format", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public List<string> FormatList
        {
            get
            {
                if (_FormatList == null)
                {
                    _FormatList = new List<string>();
                    FormatListSpecified = true;
                }
                return _FormatList;
            }
            set { _FormatList = value; FormatListSpecified = true; }
        }
        


    }
}
