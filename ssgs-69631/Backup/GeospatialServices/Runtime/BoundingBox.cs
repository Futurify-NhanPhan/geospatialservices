using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Types;


namespace GeospatialServices.Ogc.Wmc
{
    public partial class BoundingBox
    {
        public static System.Globalization.NumberFormatInfo numberFormat_EnUS = new System.Globalization.CultureInfo("en-US", false).NumberFormat;

        private SqlGeometry boundingBox = null;

        public BoundingBox(string strBBOX, int srid)
        {
            if (strBBOX == null)
                return;
            string[] strVals = strBBOX.Split(new char[] { ',' });
            if (strVals.Length != 4)
                throw new ArgumentException("four coordinates expected in bounding box string");
            if (!double.TryParse(strVals[0], System.Globalization.NumberStyles.Float, numberFormat_EnUS, out _MinX))
                throw new ArgumentException("Cannot parse values for bounding box");
            if (!double.TryParse(strVals[2], System.Globalization.NumberStyles.Float, numberFormat_EnUS, out _MaxX))
                throw new ArgumentException("Cannot parse values for bounding box");
            if (!double.TryParse(strVals[1], System.Globalization.NumberStyles.Float, numberFormat_EnUS, out _MinY))
                throw new ArgumentException("Cannot parse values for bounding box");
            if (!double.TryParse(strVals[3], System.Globalization.NumberStyles.Float, numberFormat_EnUS, out _MaxY))
                throw new ArgumentException("Cannot parse values for bounding box");
            string queryGeometryString = string.Format("POLYGON (({0} {1}, {2} {1}, {2} {3}, {0} {3}, {0} {1}))", _MinX, _MinY, _MaxX, _MaxY);
            boundingBox = SqlGeometry.STGeomFromText(new System.Data.SqlTypes.SqlChars(new System.Data.SqlTypes.SqlString(queryGeometryString)), srid);
        }

        public SqlGeometry ToSqlGeometry
        {
            get { return boundingBox; }
        }

        public double Width
        {
            get { return Math.Abs(_MaxX - _MinX); }
        }


        public double Height
        {
            get { return Math.Abs(_MaxY - _MinY); }
        }

        public double CenterX
        {
            get { return (_MinX + _MaxX) * .5f; }
        }

        public double CenterY
        {
            get { return (_MinY + _MaxY) * .5f; }
        }

    }
}
