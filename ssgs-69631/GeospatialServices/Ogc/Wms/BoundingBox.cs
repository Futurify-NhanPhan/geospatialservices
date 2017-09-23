using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms
{
    [DataContract]
    [XmlType(TypeName = "BoundingBox", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class BoundingBox
    {
        public BoundingBox()
        {
        }

        public BoundingBox(string crs, decimal minX, decimal minY, decimal maxX, decimal maxY)
        {
            _CRS = crs;
            _MinX = minX;
            _MinY = minY;
            _MaxX = maxX;
            _MaxY = maxY;
        }


        private string _CRS;

        [DataMember]
        [XmlAttribute(AttributeName = "CRS", DataType = "string")]
        public string CRS
        {
            get { return _CRS; }
            set { _CRS = value; }
        }
        private decimal _MinX;

        [XmlAttribute(AttributeName = "minx", DataType = "decimal")]
        [DataMember]
        public decimal MinX
        {
            get { return _MinX; }
            set { _MinX = value; }
        }
        private decimal _MinY;

        [XmlAttribute(AttributeName = "miny", DataType = "decimal")]
        [DataMember]
        public decimal MinY
        {
            get { return _MinY; }
            set { _MinY = value; }
        }
        private decimal _MaxX;

        [XmlAttribute(AttributeName = "maxx", DataType = "decimal")]
        [DataMember]
        public decimal MaxX
        {
            get { return _MaxX; }
            set { _MaxX = value; }
        }
        private decimal _MaxY;

        [XmlAttribute(AttributeName = "maxy", DataType = "decimal")]
        [DataMember]
        public decimal MaxY
        {
            get { return _MaxY; }
            set { _MaxY = value; }
        }

        private decimal _ResX;

        [XmlAttribute(AttributeName = "resx", DataType = "decimal")]
        [DataMember]
        public decimal ResX
        {
            get { return _ResX; }
            set { _ResX = value; }
        }
        private decimal _ResY;

        [XmlAttribute(AttributeName = "resy", DataType = "decimal")]
        [DataMember]
        public decimal ResY
        {
            get { return _ResY; }
            set { _ResY = value; }
        }

    }
}
