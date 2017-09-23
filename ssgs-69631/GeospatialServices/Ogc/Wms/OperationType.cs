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
    [XmlType(TypeName = "OperationType", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class OperationType
    {

        [XmlIgnore]
        [DataMember] public bool FormatListSpecified;

        private List<string> _FormatList;

        [XmlElement(ElementName = "Format", Type = typeof(string), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
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


        [XmlIgnore]
        [DataMember] public bool DCPTypeListSpecified;

        private List<DCPType> _DCPTypeList;

        [XmlElement(ElementName = "DCPType", Type = typeof(DCPType), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public List<DCPType> DCPTypeList
        {
            get
            {
                if (_DCPTypeList == null)
                {
                    _DCPTypeList = new List<DCPType>();
                    DCPTypeListSpecified = true;
                }
                return _DCPTypeList;
            }
            set { _DCPTypeList = value; DCPTypeListSpecified = true; }
        }





        
    }
}
