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
    [XmlType(TypeName = "WGS84BoundingBox", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class WGS84BoundingBox
    {

        private string _CRS;

        [XmlAttribute(AttributeName = "crs", DataType = "string", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string CRS
        {
            get { return _CRS; }
            set { _CRS = value; }
        }

        private string _Dimensions;

        [XmlAttribute(AttributeName = "dimensions", DataType = "string", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string Dimensions
        {
            get { return _Dimensions; }
            set { _Dimensions = value; }
        }


        private string _LowerCorner;

        [XmlElement(Type = typeof(string), ElementName = "LowerCorner", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        [DataMember]
        public string LowerCorner
        {
            get { return _LowerCorner; }
            set { _LowerCorner = value; }
        }

        private string _UpperCorner;

        [XmlElement(Type = typeof(string), ElementName = "UpperCorner", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        [DataMember]
        public string UpperCorner
        {
            get { return _UpperCorner; }
            set { _UpperCorner = value; }
        }

    }
}
