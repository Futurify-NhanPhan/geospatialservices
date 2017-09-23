using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "BoundingBox", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class BoundingBox
    {
        public BoundingBox()
        {
        }

        //public BoundingBox(string WmsBoundingBox)
        //{
        //    if (WmsBoundingBox == null)
        //        return;
        //    string[] boundingBoxVals = WmsBoundingBox.Split(new char[] { ',' });
        //    if (boundingBoxVals.Length != 4)
        //        throw new System.IndexOutOfRangeException("Incorrect number of parameters for Bounding Box");
        //    double minX = 0; double minY = 0;
        //    double maxX = 0; double maxY = 0;
        //    if (!double.TryParse(boundingBoxVals[0], out minX))
        //        throw new System.InvalidCastException("Invalid Format for the Bounding Box parameter");
        //    if (!double.TryParse(boundingBoxVals[2], out maxX))
        //        throw new System.InvalidCastException("Invalid Format for the Bounding Box parameter");
        //    if (!double.TryParse(boundingBoxVals[1], out minY))
        //        throw new System.InvalidCastException("Invalid Format for the Bounding Box parameter");
        //    if (!double.TryParse(boundingBoxVals[3], out maxY))
        //        throw new System.InvalidCastException("Invalid Format for the Bounding Box parameter");

        //    _MinX = minX;
        //    _MinY = minY;
        //    _MaxX = maxX;
        //    _MaxY = maxY;
        //}

        public BoundingBox(string srs, double minX, double minY, double maxX, double maxY)
        {
            _SRS = srs;
            _MinX = minX;
            _MinY = minY;
            _MaxX = maxX;
            _MaxY = maxY;
        }


        private string _SRS;

        [XmlAttribute(AttributeName = "SRS")]
        public string SRS
        {
            get { return _SRS; }
            set { _SRS = value; }
        }
        private double _MinX;

        [XmlAttribute(AttributeName = "minx")]
        public double MinX
        {
            get { return _MinX; }
            set { _MinX = value; }
        }
        private double _MinY;

        [XmlAttribute(AttributeName = "miny")]
        public double MinY
        {
            get { return _MinY; }
            set { _MinY = value; }
        }
        private double _MaxX;

        [XmlAttribute(AttributeName = "maxx")]
        public double MaxX
        {
            get { return _MaxX; }
            set { _MaxX = value; }
        }
        private double _MaxY;

        [XmlAttribute(AttributeName = "maxy")]
        public double MaxY
        {
            get { return _MaxY; }
            set { _MaxY = value; }
        }
    }
}