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
    [XmlType(TypeName = "LegendURL", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class LegendURL
    {

        [XmlIgnore]
        [DataMember] public bool WidthSpecified = false;
        private int _Width;

        [XmlAttribute(AttributeName = "width", DataType = "int")]
        [DataMember] public int Width
        {
            get { return _Width; }
            set { _Width = value; WidthSpecified = true; }
        }

        [XmlIgnore]
        [DataMember] public bool HeightSpecified = false;
        private int _Height;

        [XmlAttribute(AttributeName = "height", DataType = "int")]
        [DataMember] public int Height
        {
            get { return _Height; }
            set { _Height = value; HeightSpecified = true; }
        }


        [XmlIgnore]
        [DataMember] public bool FormatSpecified = false;
        private string _Format;

        [XmlElement(Type = typeof(string), ElementName = "Format", IsNullable = false)]
        [DataMember] public string Format
        {
            get { return _Format; }
            set { _Format = value; FormatSpecified = true; }
        }

        [XmlIgnore]
        [DataMember] public bool OnlineResourceSpecified;

        private OnlineResource _OnlineResource;

        [XmlElement(Type = typeof(OnlineResource), ElementName = "OnlineResource", IsNullable = false)]
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
