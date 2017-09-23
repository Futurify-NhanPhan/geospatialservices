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
    [XmlType(TypeName = "LatLongBoundingBox", Namespace = Declarations.Wfs100NameSpace), Serializable]
    public partial class LatLongBoundingBox
    {

        private string _MinX;

        [XmlAttribute(AttributeName = "minx", DataType = "string", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string MinX
        {
            get { return _MinX; }
            set { _MinX = value; }
        }

        private string _MinY;

        [XmlAttribute(AttributeName = "miny", DataType = "string", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string MinY
        {
            get { return _MinY; }
            set { _MinY = value; }
        }

        private string _MaxX;

        [XmlAttribute(AttributeName = "maxx", DataType = "string", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string MaxX
        {
            get { return _MaxX; }
            set { _MaxX = value; }
        }

        private string _MaxY;

        [XmlAttribute(AttributeName = "maxy", DataType = "string", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public string MaxY
        {
            get { return _MaxY; }
            set { _MaxY = value; }
        }

    }
}
