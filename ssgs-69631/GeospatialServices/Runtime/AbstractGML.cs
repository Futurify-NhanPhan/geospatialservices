using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Types;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    public abstract partial class AbstractGML
    {
        public static AbstractGML GetFromSqlGeometry(SqlGeometry geometry)
        {
            AbstractGML gmlGeometry = null;
            string geomType = (string)geometry.STGeometryType();
            switch (geomType)
            {
                case "Point":
                    {
                        GeospatialServices.Ogc.Wms.GmlSf.Point gmlPoint = GetGmlSfPoint(geometry);
                        gmlGeometry = gmlPoint;
                    }
                    break;
                case "LineString":
                    {
                        GeospatialServices.Ogc.Wms.GmlSf.Curve gmlCurve = GetGmlSfCurve(geometry);
                        gmlGeometry = gmlCurve;
                    }
                    break;
                case "Polygon":
                    {
                        GeospatialServices.Ogc.Wms.GmlSf.Surface gmlSurface = GetGmlSfSurface(geometry);
                        gmlGeometry = gmlSurface;
                    }
                    break;
                case "MultiPoint":
                    {
                        GeospatialServices.Ogc.Wms.GmlSf.MultiPoint gmlMultiPoint = GetGmlSfMultiPoint(geometry);
                        gmlGeometry = gmlMultiPoint;
                    }
                    break;
                case "MultiLineString":
                    {
                        GeospatialServices.Ogc.Wms.GmlSf.MultiCurve gmlMultiCurve = GetGmlSfMultiCurve(geometry);
                        gmlGeometry = gmlMultiCurve;
                    }
                    break;
                case "MultiPolygon":
                    {
                        GeospatialServices.Ogc.Wms.GmlSf.MultiSurface gmlMultiSurface = GetGmlSfMultiSurface(geometry);
                        gmlGeometry = gmlMultiSurface;
                    }
                    break;
                case "GeometryCollection":
                    {
                        GeospatialServices.Ogc.Wms.GmlSf.MultiGeometry gmlMultiGeometry = new GeospatialServices.Ogc.Wms.GmlSf.MultiGeometry();
                        GeospatialServices.Ogc.Wms.GmlSf.MultiSurface gmlMultiSurface = null;
                        GeospatialServices.Ogc.Wms.GmlSf.MultiPoint gmlMultiPoint = null;
                        GeospatialServices.Ogc.Wms.GmlSf.MultiCurve gmlMultiCurve = null;
                        GeospatialServices.Ogc.Wms.GmlSf.Surface gmlSurface = null;
                        GeospatialServices.Ogc.Wms.GmlSf.Point gmlPoint = null;
                        GeospatialServices.Ogc.Wms.GmlSf.Curve gmlCurve = null;
                        GeospatialServices.Ogc.Wms.GmlSf.AbstractGeometricAggregate gmlAbstractGeometricAggregate = null;

                        for (int i = 1; i <= geometry.STNumGeometries(); i++)
                        {
                            if (geometry.STGeometryN(i).STGeometryType() == "Point")
                            {
                                if (gmlMultiPoint == null)
                                {
                                    gmlMultiPoint = new GeospatialServices.Ogc.Wms.GmlSf.MultiPoint();
                                    gmlMultiGeometry.MultiGeometryMemberList.Add(new MultiGeometryProperty(gmlMultiPoint));
                                }
                                gmlPoint = GetGmlSfPoint(geometry.STGeometryN(i));
                                gmlMultiPoint.PointMemberList.Add(new PointProperty(gmlPoint));
                            }
                            if (geometry.STGeometryN(i).STGeometryType() == "LineString")
                            {
                                if (gmlMultiCurve == null)
                                {
                                    gmlMultiCurve = new GeospatialServices.Ogc.Wms.GmlSf.MultiCurve();
                                    gmlMultiGeometry.MultiGeometryMemberList.Add(new MultiGeometryProperty(gmlMultiCurve));
                                }
                                gmlCurve = GetGmlSfCurve(geometry.STGeometryN(i));
                                gmlMultiCurve.CurveMemberList.Add(new CurveProperty(gmlCurve));
                            }
                            else if (geometry.STGeometryN(i).STGeometryType() == "Polygon")
                            {
                                if (gmlMultiSurface == null)
                                {
                                    gmlMultiSurface = new GeospatialServices.Ogc.Wms.GmlSf.MultiSurface();
                                    gmlMultiGeometry.MultiGeometryMemberList.Add(new MultiGeometryProperty(gmlMultiSurface));
                                }
                                gmlSurface = GetGmlSfSurface(geometry.STGeometryN(i));
                                gmlMultiSurface.SurfaceMemberList.Add(new SurfaceProperty(gmlSurface));
                            }
                            else // MultiPoint, MultiLineString, Multipolygon, GeometricCollection
                            {
                                gmlAbstractGeometricAggregate = (GeospatialServices.Ogc.Wms.GmlSf.AbstractGeometricAggregate)GetFromSqlGeometry(geometry.STGeometryN(i));
                                gmlMultiGeometry.MultiGeometryMemberList.Add(new MultiGeometryProperty(gmlAbstractGeometricAggregate));
                            }
                        }
                        gmlGeometry = gmlMultiGeometry;
                    }
                    break;
            }
            return gmlGeometry;
        }

        /// <summary>
        /// Returns the Serializable GML SF0 Multi Surface Object for the Given MultiSurface
        /// </summary>
        /// <param name="geomertyType"></param>
        /// <returns></returns>
        private static GeospatialServices.Ogc.Wms.GmlSf.MultiSurface GetGmlSfMultiSurface(SqlGeometry geometry)
        {
            GeospatialServices.Ogc.Wms.GmlSf.MultiSurface gmlMultiSurface = new GeospatialServices.Ogc.Wms.GmlSf.MultiSurface();
            GeospatialServices.Ogc.Wms.GmlSf.Surface gmlSurface = null;

            for (int i = 1; i <= geometry.STNumGeometries(); i++)
            {
                SqlGeometry smPolygon = geometry.STGeometryN(i);
                gmlSurface = GetGmlSfSurface(smPolygon);
                gmlMultiSurface.SurfaceMemberList.Add(new SurfaceProperty(gmlSurface));
            }
            return gmlMultiSurface;
        }

        /// <summary>
        /// Returns the Serializable GML SF0 Multi Curve Object for the Given MultiCurve
        /// </summary>
        /// <param name="geomertyType"></param>
        /// <returns></returns>
        private static GeospatialServices.Ogc.Wms.GmlSf.MultiCurve GetGmlSfMultiCurve(SqlGeometry geometry)
        {
            GeospatialServices.Ogc.Wms.GmlSf.MultiCurve gmlMultiCurve = new GeospatialServices.Ogc.Wms.GmlSf.MultiCurve();
            GeospatialServices.Ogc.Wms.GmlSf.Curve gmlCurve = null;

            for (int i = 1; i <= geometry.STNumGeometries(); i++)
            {
                SqlGeometry smLineString = geometry.STGeometryN(i);
                gmlCurve = GetGmlSfCurve(smLineString);
                gmlMultiCurve.CurveMemberList.Add(new CurveProperty(gmlCurve));
            }
            return gmlMultiCurve;
        }

        /// <summary>
        /// Returns the Serializable GML SF0 Multi Point Object for the Given Multi Point
        /// </summary>
        /// <param name="geomertyType"></param>
        /// <returns></returns>
        private static GeospatialServices.Ogc.Wms.GmlSf.MultiPoint GetGmlSfMultiPoint(SqlGeometry geometry)
        {
            GeospatialServices.Ogc.Wms.GmlSf.MultiPoint gmlMultiPoint = new GeospatialServices.Ogc.Wms.GmlSf.MultiPoint();
            GeospatialServices.Ogc.Wms.GmlSf.Point gmlPoint = null;

            for (int i = 1; i <= geometry.STNumGeometries(); i++)
            {
                SqlGeometry smPoint = geometry.STGeometryN(i);
                gmlPoint = GetGmlSfPoint(smPoint);
                gmlMultiPoint.PointMemberList.Add(new PointProperty(gmlPoint));
            }
            return gmlMultiPoint;
        }

        /// <summary>
        /// Returns the Serializable GML SF0 Curve Object for the Given LineString
        /// </summary>
        /// <param name="geomertyType"></param>
        /// <returns></returns>
        private static GeospatialServices.Ogc.Wms.GmlSf.Curve GetGmlSfCurve(SqlGeometry geometry)
        {
            GeospatialServices.Ogc.Wms.GmlSf.Curve gmlCurve = new GeospatialServices.Ogc.Wms.GmlSf.Curve();
            gmlCurve.srsName = geometry.STSrid.ToString();
            LineStringSegment lineStringSegment = new LineStringSegment();
            gmlCurve.segments.Add(lineStringSegment);
            lineStringSegment.Interpolation = CurveInterpolationType.linear;
            StringBuilder sb = new StringBuilder();
            bool first = true;

            for (int i = 1; i <= geometry.STNumPoints(); i++)
            {
                if (first)
                    first = false;
                else
                    sb.Append(" ");

                sb.Append(geometry.STPointN(i).STX.ToString());
                sb.Append(" ");
                sb.Append(geometry.STPointN(i).STY.ToString());
            }
            lineStringSegment.PosList.Value = sb.ToString();
            return gmlCurve;
        }

        /// <summary>
        /// Returns the Serializable GML SF0 Point Object for the Given Point
        /// </summary>
        /// <param name="geomertyType"></param>
        /// <returns></returns>
        private static GeospatialServices.Ogc.Wms.GmlSf.Point GetGmlSfPoint(SqlGeometry geometry)
        {
            GeospatialServices.Ogc.Wms.GmlSf.Point gmlPoint = new GeospatialServices.Ogc.Wms.GmlSf.Point();

            gmlPoint.Pos.Value = geometry.STX.ToString() + " " + geometry.STY.ToString();
            gmlPoint.srsName = geometry.STSrid.ToString();
            return gmlPoint;
        }

        /// <summary>
        /// Returns the Serializable GML SF0 Surface Object for the Given Polygon
        /// </summary>
        /// <param name="geomertyType"></param>
        /// <returns></returns>
        private static GeospatialServices.Ogc.Wms.GmlSf.Surface GetGmlSfSurface(SqlGeometry geometry)
        {
            GeospatialServices.Ogc.Wms.GmlSf.Surface gmlSurface = new GeospatialServices.Ogc.Wms.GmlSf.Surface();            
            gmlSurface.srsName = geometry.STSrid.ToString();
            
            // Exterior Ring
            PolygonPatch polygonPatch = new PolygonPatch();
            gmlSurface.patches.Add(polygonPatch);
            GeospatialServices.Ogc.Wms.GmlSf.LinearRing linearRing = new GeospatialServices.Ogc.Wms.GmlSf.LinearRing();
            polygonPatch.Exterior = new AbstractRingProperty(linearRing);
            StringBuilder sb = new StringBuilder();
            bool first = true;

            for (int i = 1; i <= geometry.STExteriorRing().STNumPoints(); i++)
            {
                if (first)
                    first = false;
                else
                    sb.Append(" ");

                sb.Append(geometry.STExteriorRing().STPointN(i).STX.ToString());
                sb.Append(" ");
                sb.Append(geometry.STExteriorRing().STPointN(i).STY.ToString());
            }
            linearRing.PosList.Value = sb.ToString();

            // Interior Rings
            for (int i = 1; i <= geometry.STNumInteriorRing(); i++)
            {
                polygonPatch = new PolygonPatch();
                gmlSurface.patches.Add(polygonPatch);
                linearRing = new GeospatialServices.Ogc.Wms.GmlSf.LinearRing();
                polygonPatch.InteriorList.Add(new AbstractRingProperty(linearRing));
                sb = new StringBuilder();
                first = true;

                for (int j = 1; i <= geometry.STInteriorRingN(i).STNumPoints(); i++)
                {
                    if (first)
                        first = false;
                    else
                        sb.Append(" ");

                    sb.Append(geometry.STInteriorRingN(i).STPointN(j).STX.ToString());
                    sb.Append(" ");
                    sb.Append(geometry.STInteriorRingN(i).STPointN(j).STY.ToString());
                }
                linearRing.PosList.Value = sb.ToString();
            }
            return gmlSurface;
        }
    }
}
