using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServer.Types;
using GeospatialServices.Runtime;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GeospatialServices.Ogc.Wmc
{
    /// <summary>
    /// Runtime implementation for layer properties and feature data access
    /// </summary>
    public partial class Layer
    {
        #region Properties
        private string _ConnectionString;

        /// <summary>   
        /// Connectionstring   
        /// </summary>   
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        private string _Table;

        /// <summary>   
        /// Data table name   
        /// </summary>   
        public string Table
        {
            get { return _Table; }
            set { _Table = value; }
        }

        private string _GeometryColumn;

        /// <summary>   
        /// Name of geometry column   
        /// </summary>   
        public string GeometryColumn
        {
            get { return _GeometryColumn; }
            set { _GeometryColumn = value; }
        }

        private string _FeatureIdColumn;

        /// <summary>   
        /// Name of column that uniquely identifies the spatial feature   
        /// </summary>   
        public string FeatureIdColumn
        {
            get { return _FeatureIdColumn; }
            set { _FeatureIdColumn = value; }
        }
        #endregion


        public Layer()
        {

        }

        public Layer(string name, string connectionString, string table, string geometryColumn, string featureIdColumn)
        {
            this.Name = name;
            this.ConnectionString = connectionString;
            this.Table = table;
            this.GeometryColumn = geometryColumn;
            this.FeatureIdColumn = featureIdColumn;
        }

        /// <summary>   
        /// Returns a GeospatialServices.Runtime.FeatureDataRow based on a RowID   
        /// </summary>   
        /// <param name="RowID"></param>   
        /// <returns>datarow</returns>   
        public GeospatialServices.Runtime.FeatureDataRow GetFeatureDataRow(uint RowID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string strSQL = String.Format("SELECT * FROM {0}", this.Table);
                using (SqlDataAdapter adapter = new SqlDataAdapter(strSQL, conn))
                {
                    conn.Open();
                    System.Data.DataSet ds = new System.Data.DataSet();
                    adapter.Fill(ds);
                    conn.Close();
                    if (ds.Tables.Count > 0)
                    {
                        FeatureDataTable fdt = new FeatureDataTable(ds.Tables[0]);
                        foreach (System.Data.DataColumn col in ds.Tables[0].Columns)
                            if (col.ColumnName != this.GeometryColumn && col.ColumnName != this.GeometryColumn)
                                fdt.Columns.Add(col.ColumnName, col.DataType, col.Expression);

                        if(ds.Tables[0].Rows.Count > (int)RowID)
                        {
                            System.Data.DataRow dr = ds.Tables[0].Rows[(int)RowID];
                        
                            GeospatialServices.Runtime.FeatureDataRow fdr = fdt.NewRow();
                            foreach (System.Data.DataColumn col in ds.Tables[0].Columns)
                                if (col.ColumnName != this.GeometryColumn && col.ColumnName != this.GeometryColumn)
                                    fdr[col.ColumnName] = dr[col];
                            fdr.Geometry = (SqlGeometry)dr[this.GeometryColumn];
                            return fdr;
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
            }
        }

        /// <summary>
        /// Creates a new FeatureDataSet for the layer with all features that intersect the supplied query feature geometry
        /// </summary>
        /// <param name="queryFeature"></param>
        /// <param name="fds"></param>
        public void ExecuteSpatialQuery(SqlGeometry queryFeature, GeospatialServices.Runtime.FeatureDataSet fds)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string strSQL = String.Format("SELECT * FROM {0} WHERE {1}.STIntersects(Geometry::STGeomFromText('{2}',4326)) = 1", this.Table, this.GeometryColumn, queryFeature.ToString());
                using (SqlDataAdapter adapter = new SqlDataAdapter(strSQL, conn))
                {
                    conn.Open();
                    System.Data.DataSet ds = new System.Data.DataSet();
                    adapter.Fill(ds);
                    conn.Close();
                    if (ds.Tables.Count > 0)
                    {
                        FeatureDataTable fdt = new FeatureDataTable(ds.Tables[0]);
                        foreach (System.Data.DataColumn col in ds.Tables[0].Columns)
                            if (col.ColumnName != this.GeometryColumn && col.ColumnName != this.GeometryColumn)
                                fdt.Columns.Add(col.ColumnName, col.DataType, col.Expression);
                        foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                        {
                            GeospatialServices.Runtime.FeatureDataRow fdr = fdt.NewRow();
                            foreach (System.Data.DataColumn col in ds.Tables[0].Columns)
                                if (col.ColumnName != this.GeometryColumn && col.ColumnName != this.GeometryColumn)
                                    fdr[col.ColumnName] = dr[col];
                            fdr.Geometry = (SqlGeometry)dr[this.GeometryColumn];
                            fdt.AddRow(fdr);
                        }
                        fds.Tables.Add(fdt);
                    }
                }
            }
        }

        /// <summary>
        /// Create a minimal copy of a layer object
        /// </summary>
        /// <returns></returns>
        public Layer Clone()
        {
            Layer result = new Layer();
            result.Title = this.Title;
            result.Name = this.Name;

            result.ConnectionString = this.ConnectionString;
            result.Table = this.Table;
            result.GeometryColumn = this.GeometryColumn;
            result.FeatureIdColumn = this.FeatureIdColumn;
            return result;
        }

        public void Render(System.Drawing.Graphics g, GeospatialServices.Runtime.FeatureDataSet featureDataSet, ViewContext context)
        {
            int totalFeatures = featureDataSet.Tables[0].Count;
            for (int i = 0; i < totalFeatures; i++)
            {
                FeatureDataRow featureDataRow = featureDataSet.Tables[0][i];
                string geomType = (string)featureDataRow.Geometry.STGeometryType();
                switch (geomType)
                {
                    case "Point":
                        {
                   //         GeospatialServices.Ogc.Wms.GmlSf.Point gmlPoint = GetGmlSfPoint(geometry);
                   //         gmlGeometry = gmlPoint;
                        }
                        break;
                    case "LineString":
                        {
                   //         GeospatialServices.Ogc.Wms.GmlSf.Curve gmlCurve = GetGmlSfCurve(geometry);
                   //         gmlGeometry = gmlCurve;
                        }
                        break;
                    case "Polygon":
                        {
                            System.Drawing.Pen pen;
                            System.Drawing.Brush brush;
                            EvaluatePolygonStyle(featureDataRow, context, out brush, out pen);
                            DrawPolygon(g, featureDataRow.Geometry, context, brush, pen);          
                        }
                        break;
                    case "MultiPoint":
                        {
                   //         GeospatialServices.Ogc.Wms.GmlSf.MultiPoint gmlMultiPoint = GetGmlSfMultiPoint(geometry);
                   //         gmlGeometry = gmlMultiPoint;
                        }
                        break;
                    case "MultiLineString":
                        {
                   //         GeospatialServices.Ogc.Wms.GmlSf.MultiCurve gmlMultiCurve = GetGmlSfMultiCurve(geometry);
                   //         gmlGeometry = gmlMultiCurve;
                        }
                        break;
                    case "MultiPolygon":
                        {
                            for (int j = 1; j <= (int)featureDataRow.Geometry.STNumGeometries(); j++)
                            {
                                System.Drawing.Pen pen;
                                System.Drawing.Brush brush;
                                EvaluatePolygonStyle(featureDataRow, context, out brush, out pen);
                                DrawPolygon(g, featureDataRow.Geometry.STGeometryN(j), context, brush, pen);
                            }
                        }
                        break;
                    case "GeometryCollection":
                        {
                 //           gmlGeometry = gmlMultiGeometry;
                        }
                        break;
                }
            }
        }

        public static void DrawPolygon(System.Drawing.Graphics g, SqlGeometry geometry, ViewContext context, System.Drawing.Brush brush, System.Drawing.Pen pen)
        {
            if (geometry.STExteriorRing() == null)
                return;

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

            System.Drawing.PointF[] exterior = new System.Drawing.PointF[(int)geometry.STExteriorRing().STNumPoints()];
            for (int i = 1; i <= (int)geometry.STExteriorRing().STNumPoints(); i++)
			{
			    exterior[i-1] = WorldtoMap((double)geometry.STExteriorRing().STPointN(i).STX, (double)geometry.STExteriorRing().STPointN(i).STY, context); 
            }
            gp.AddPolygon(exterior);

            //TODO: Add interior rings

            if (brush != null && brush != System.Drawing.Brushes.Transparent)
                g.FillPath(brush, gp);

            if (pen != null)
                g.DrawPath(pen, gp);
        }

        public static System.Drawing.PointF WorldtoMap(double x, double y, ViewContext context)
        {
            System.Drawing.PointF result = new System.Drawing.Point();
            double Height = (context.Zoom * context.General.Window.Height) / context.General.Window.Width;
            double left = context.CenterX - context.Zoom * 0.5;
            double top = context.CenterY + Height * 0.5 * context.PixelAspectRatio;
            result.X = (float)((x - left) / context.PixelWidth);
            result.Y = (float)((top - y) / context.PixelHeight);
            return result;
        }


        private void EvaluatePolygonStyle(FeatureDataRow featureDataRow, ViewContext context, out System.Drawing.Brush brush, out System.Drawing.Pen pen)
        {
            brush = null;
            pen = null;

            FeatureTypeStyle featureTypeStyle = this.StyleList[0].SLD.StyledLayerDescriptor.UserLayers[0].UserStyles[0].FeatureTypeStyles[0];
            FeatureTypeStyle filtered = FilterFeatureTypeStyle(featureDataRow, featureTypeStyle);

            foreach (Rule rule in filtered.Rules)
            {
                foreach (BaseSymbolizer symbolizer in rule.Symbolizers)
                {
                    if (symbolizer.GetType().FullName == "GeospatialServices.Ogc.Wmc.PolygonSymbolizer")
                    {
                        if (((PolygonSymbolizer)symbolizer).Fill.SvgParameters.Count > 0)
                        {
                            PolygonSymbolizer polygonSymbolizer = symbolizer as PolygonSymbolizer;

                            if (polygonSymbolizer != null)
                            {
                                // Polygon Fill applies to brush
                                if (polygonSymbolizer.Fill.GraphicFillSpecified)
                                {
                                    Color c = Color.Black;
                                    int opacity = 255;
                                    foreach (GeospatialServices.Ogc.Wmc.SvgParameter svgParm in polygonSymbolizer.Fill.SvgParameters)
                                    {
                                        switch (svgParm.Name)
                                        {
                                            case "fill":
                                                c = System.Drawing.ColorTranslator.FromHtml(svgParm.Expression);
                                                break;
                                            case "fill-opacity":
                                                opacity = ConvertOpacityToStyle(svgParm.Expression);
                                                break;
                                        }
                                    }

                                    string hatchStyleString = polygonSymbolizer.Fill.GraphicFill.Graphic.ExternalGraphics[0].OnlineResource.Href;
                                    HatchStyle hatchStyle = (HatchStyle)Enum.Parse(typeof(HatchStyle), hatchStyleString, true);
                                    brush = new HatchBrush(hatchStyle, Color.FromArgb(opacity, c.R, c.G, c.B), Color.Transparent);
                                }
                                else
                                {
                                    Color c = Color.Black;
                                    int opacity = 255;
                                    foreach (GeospatialServices.Ogc.Wmc.SvgParameter svgParm in polygonSymbolizer.Fill.SvgParameters)
                                    {
                                        switch (svgParm.Name)
                                        {
                                            case "fill":
                                                c = System.Drawing.ColorTranslator.FromHtml(svgParm.Expression);
                                                break;
                                            case "fill-opacity":
                                                opacity = ConvertOpacityToStyle(svgParm.Expression);
                                                break;
                                        }
                                    }
                                    brush = new SolidBrush(Color.FromArgb(opacity, c.R, c.G, c.B));
                                }

                                // Polygon Stroke applies to pen
                                if (polygonSymbolizer.StrokeSpecified)
                                {
                                    Color c = Color.Gray;
                                    int opacity = 255;
                                    int width = 1;
                                    foreach (GeospatialServices.Ogc.Wmc.SvgParameter svgParm in polygonSymbolizer.Stroke.SvgParameters)
                                    {
                                        switch (svgParm.Name)
                                        {
                                            case "stroke":
                                                c = System.Drawing.ColorTranslator.FromHtml(svgParm.Expression);
                                                break;
                                            case "stroke-opacity":
                                                opacity = ConvertOpacityToStyle(svgParm.Expression);
                                                break;
                                            case "stroke-width":
                                                width = int.Parse(svgParm.Expression);
                                                break;
                                        }
                                    }
                                    pen = new Pen(Color.FromArgb(opacity, c.R, c.G, c.B), width);
                                }
                                else
                                {
                                    pen = null;
                                }
                            }
                        }
                    }
                }
            }
        }

        public int ConvertOpacityToStyle(string opacity)
        {
            //evaluate values either 0-1 or 0-255 range
            if (double.Parse(opacity) > 1)
                return int.Parse(opacity);
            else
                return (int)(double.Parse(opacity) * 255);
        }

        /// <summary>
        /// Return a list of Styles within Rules contained in a FeatureTypeStyle that match the filter criteria
        /// for this row
        /// </summary>
        /// <param name="row"></param>
        /// <param name="featureTypeStyle"></param>
        /// <returns></returns>
        public FeatureTypeStyle FilterFeatureTypeStyle(FeatureDataRow row, FeatureTypeStyle featureTypeStyle)
        {

            int result = 0;
            bool ruleConditionMet = false;
            bool atLeastOneRuleConditionMet = false;

            Type type = null;
            object a, b;
            FeatureTypeStyle filtered = new FeatureTypeStyle();
            filtered.Rules = new List<Rule>();
            Rule _ElseFilterRule = null;

            foreach (Rule thisRule in featureTypeStyle.Rules)
            {
                //Check that layer will be rendered for rule
                //TODO: implement scale
                //if (thisRule.MinScaleDenominatorSpecified && _mapScale < thisRule.MinScaleDenominator)
                //    continue;

                //if (thisRule.MaxScaleDenominatorSpecified && _mapScale >= thisRule.MaxScaleDenominator)
                //    continue;

                ruleConditionMet = false;

                if (thisRule.ElseFilterSpecified)
                {
                    _ElseFilterRule = thisRule;
                    break;
                }

                if (thisRule.FilterSpecified && thisRule.Filter.FilterExpressionSpecified)
                {
                    switch (thisRule.Filter.FilterSelection)
                    {
                        case Ogc.Common.FilterTypes.PropertyIsEqualTo:
                            {
                                PropertyIsEqualTo filter = thisRule.Filter.FilterExpression as PropertyIsEqualTo;

                                if (filter != null)
                                {
                                    type = row.Table.Columns[filter.PropertyName].DataType;

                                    a = Convert.ChangeType(row[filter.PropertyName].ToString().Trim(), type);
                                    b = Convert.ChangeType(filter.Literal.Value, type);
                                    result = Comparer.Default.Compare(a, b);
                                    ruleConditionMet = (result == 0);
                                }
                            }
                            break;
                        case Ogc.Common.FilterTypes.PropertyIsGreaterThan:
                            {
                                PropertyIsGreaterThan filter = thisRule.Filter.FilterExpression as PropertyIsGreaterThan;

                                if (filter != null)
                                {
                                    type = row.Table.Columns[filter.PropertyName].DataType;

                                    a = Convert.ChangeType(row[filter.PropertyName].ToString().Trim(), type);
                                    b = Convert.ChangeType(filter.Literal.Value, type);
                                    result = Comparer.Default.Compare(a, b);
                                    ruleConditionMet = (result > 0);

                                }
                            }
                            break;
                        case Ogc.Common.FilterTypes.PropertyIsGreaterThanOrEqualTo:
                            {
                                PropertyIsGreaterThanOrEqualTo filter = thisRule.Filter.FilterExpression as PropertyIsGreaterThanOrEqualTo;

                                if (filter != null)
                                {
                                    type = row.Table.Columns[filter.PropertyName].DataType;

                                    a = Convert.ChangeType(row[filter.PropertyName].ToString().Trim(), type);
                                    b = Convert.ChangeType(filter.Literal.Value, type);
                                    result = Comparer.Default.Compare(a, b);
                                    ruleConditionMet = (result >= 0);

                                }
                            }
                            break;
                        case Ogc.Common.FilterTypes.PropertyIsLessThan:
                            {
                                PropertyIsLessThan filter = thisRule.Filter.FilterExpression as PropertyIsLessThan;

                                if (filter != null)
                                {
                                    type = row.Table.Columns[filter.PropertyName].DataType;

                                    a = Convert.ChangeType(row[filter.PropertyName].ToString().Trim(), type);
                                    b = Convert.ChangeType(filter.Literal.Value, type);
                                    result = Comparer.Default.Compare(a, b);
                                    ruleConditionMet = (result < 0);
                                }
                            }
                            break;
                        case Ogc.Common.FilterTypes.PropertyIsLessThanOrEqualTo:
                            {
                                PropertyIsLessThanOrEqualTo filter = thisRule.Filter.FilterExpression as PropertyIsLessThanOrEqualTo;

                                if (filter != null)
                                {
                                    type = row.Table.Columns[filter.PropertyName].DataType;

                                    a = Convert.ChangeType(row[filter.PropertyName].ToString().Trim(), type);
                                    b = Convert.ChangeType(filter.Literal.Value, type);
                                    result = Comparer.Default.Compare(a, b);
                                    ruleConditionMet = (result <= 0);
                                }
                            }
                            break;

                        case Ogc.Common.FilterTypes.PropertyIsBetween:
                            {
                                PropertyIsBetween filter = thisRule.Filter.FilterExpression as PropertyIsBetween;

                                if (filter != null)
                                {
                                    type = row.Table.Columns[filter.PropertyName].DataType;

                                    a = Convert.ChangeType(row[filter.PropertyName].ToString().Trim(), type);
                                    if (filter.LowerBoundarySpecified)
                                    {
                                        object lowerBound = Convert.ChangeType(filter.LowerBoundary.Value, type);
                                        result = Comparer.Default.Compare(a, lowerBound);
                                        ruleConditionMet = (result >= 0);
                                    }

                                    if (filter.UpperBoundarySpecified)
                                    {
                                        object upperBound = Convert.ChangeType(filter.UpperBoundary.Value, type);
                                        result = Comparer.Default.Compare(a, upperBound);
                                        ruleConditionMet &= (result <= 0);
                                    }

                                }
                            }
                            break;

                        case Ogc.Common.FilterTypes.PropertyIsLike:
                            {
                                PropertyIsLike filter = thisRule.Filter.FilterExpression as PropertyIsLike;

                                if (filter != null)
                                {
                                    type = row.Table.Columns[filter.PropertyName].DataType;
                                    if (type == typeof(String))
                                    {

                                        string lookIn = row[filter.PropertyName].ToString().Trim();
                                        string originalLookFor = filter.Literal.Value;
                                        string lookFor = originalLookFor.Replace("%", string.Empty);
                                        bool likeResult = false;

                                        if (originalLookFor.StartsWith("%") && originalLookFor.EndsWith("%"))
                                        {
                                            likeResult = lookIn.Contains(lookFor);
                                        }
                                        else if (originalLookFor.StartsWith("%"))
                                        {
                                            likeResult = lookIn.EndsWith(lookFor);
                                        }
                                        else if (originalLookFor.EndsWith("%"))
                                        {
                                            likeResult = lookIn.StartsWith(lookFor);
                                        }

                                        ruleConditionMet = likeResult;
                                    }
                                }
                            }
                            break;
                        case Ogc.Common.FilterTypes.PropertyIsNotEqualTo:
                            {
                                PropertyIsNotEqualTo filter = thisRule.Filter.FilterExpression as PropertyIsNotEqualTo;

                                if (filter != null)
                                {
                                    type = row.Table.Columns[filter.PropertyName].DataType;

                                    a = Convert.ChangeType(row[filter.PropertyName].ToString().Trim(), type);
                                    b = Convert.ChangeType(filter.Literal.Value, type);
                                    result = Comparer.Default.Compare(a, b);
                                    ruleConditionMet = (result != 0);
                                }
                            }
                            break;
                        case Ogc.Common.FilterTypes.PropertyIsNull:
                            {
                                PropertyIsNull filter = thisRule.Filter.FilterExpression as PropertyIsNull;

                                if (filter != null)
                                {
                                    ruleConditionMet = (row[filter.PropertyName] == null);
                                }
                            }
                            break;
                    }

                }
                else if (thisRule.ElseFilterSpecified == false)
                {
                    // No filter
                    ruleConditionMet = true;
                }

                if (ruleConditionMet)
                {
                    atLeastOneRuleConditionMet = true;
                    filtered.Rules.Add(thisRule);
                }

            } // foreach Rule

            // None of the Rule Conditions have been met, apply the Else Filter
            if (!atLeastOneRuleConditionMet && _ElseFilterRule != null)
            {
                atLeastOneRuleConditionMet = true;
                filtered.Rules.Add(_ElseFilterRule);
            }

            return filtered;
        }

    }
}
