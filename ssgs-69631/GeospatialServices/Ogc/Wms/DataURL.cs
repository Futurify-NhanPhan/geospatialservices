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
    [XmlType(TypeName = "DataURL", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class DataURL
    {

        [XmlIgnore]
        [DataMember] public bool FormatSpecified = false;
        private string _Format;

        [XmlElement(Type = typeof(string), ElementName = "Format", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string Format
        {
            get { return _Format; }
            set { _Format = value; FormatSpecified = true; }
        }

        [XmlIgnore]
        [DataMember] public bool OnlineResourceSpecified;

        private OnlineResource _OnlineResource;

        [XmlElement(Type = typeof(OnlineResource), ElementName = "OnlineResource", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public OnlineResource OnlineResource
        {
            get
            {
                if (_OnlineResource == null)
                {
                    _OnlineResource = new OnlineResource();
                    OnlineResourceSpecified = true;
                }

                return _OnlineResource;
            }
            set { _OnlineResource = value; OnlineResourceSpecified = true; }
        }
    }
}
