using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SqlServer.Types;
using GeospatialServices.Ogc.Wmc;
using System.Collections.Specialized;
using GeospatialServices.Ogc.Common;
using GeospatialServices.Ogc.Wms.GmlSf;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Reflection;

namespace TestGeospatialServices
{
    /// <summary>
    /// Summary description for UnitTestRuntime
    /// </summary>
    [TestClass]
    public class UnitTestRuntime
    {
        public UnitTestRuntime()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void FeatureCollectionDbQueryTest()
        {
            string conn = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Projects\GeospatialServices\TestGeospatialServices\Input\Runtime\TestGeospatialServicesDatabase.mdf;Integrated Security=True;User Instance=True";
            GeospatialServices.Ogc.Wmc.Layer data = new GeospatialServices.Ogc.Wmc.Layer("world_admin", conn, "world_admin", "shape", "fid");
            GeospatialServices.Runtime.FeatureDataSet fds = new GeospatialServices.Runtime.FeatureDataSet();
            //UK POLYGON ((-7.5191669464111328 49.955268859863281, 1.7424999475479126 49.955268859863281, 1.7424999475479126 60.631099700927734, -7.5191669464111328 60.631099700927734, -7.5191669464111328 49.955268859863281))
            //US POLYGON ((-178.21420288085938 18.924720764160156, 179.40299987792969 18.924720764160156, 179.40299987792969 71.406646728515625, -178.21420288085938 71.406646728515625, -178.21420288085938 18.924720764160156))
            string queryGeometryString = "POLYGON ((-176.84950256347656 -50.854450225830078, 178.5596923828125 -50.854450225830078, 178.5596923828125 -34.398349761962891, -176.84950256347656 -34.398349761962891, -176.84950256347656 -50.854450225830078))";
            SqlGeometry queryGeometry = SqlGeometry.STGeomFromText(new System.Data.SqlTypes.SqlChars(new System.Data.SqlTypes.SqlString(queryGeometryString)), 4326);
            data.ExecuteSpatialQuery(queryGeometry, fds);
            Assert.IsTrue(fds.Tables[0].Count == 7);
        }


        [TestMethod]
        public void FeatureCollectionActionsTest()
        {
            string conn = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Projects\GeospatialServices\TestGeospatialServices\Input\Runtime\TestGeospatialServicesDatabase.mdf;Integrated Security=True;User Instance=True";
            GeospatialServices.Ogc.Wmc.Layer data = new GeospatialServices.Ogc.Wmc.Layer("world_admin", conn, "world_admin", "shape", "fid");
            GeospatialServices.Runtime.FeatureDataSet fds = new GeospatialServices.Runtime.FeatureDataSet();
            string queryGeometryString = "POLYGON ((-176.84950256347656 -50.854450225830078, 178.5596923828125 -50.854450225830078, 178.5596923828125 -34.398349761962891, -176.84950256347656 -34.398349761962891, -176.84950256347656 -50.854450225830078))";
            SqlGeometry queryGeometry = SqlGeometry.STGeomFromText(new System.Data.SqlTypes.SqlChars(new System.Data.SqlTypes.SqlString(queryGeometryString)), 4326);
            data.ExecuteSpatialQuery(queryGeometry, fds);
            Assert.IsTrue(fds.Tables[0].Count == 7);
            fds.Tables[0].RemoveRow(fds.Tables[0][0]);
            Assert.IsTrue(fds.Tables[0].Count == 6);
            fds.Tables[0][0].Geometry = queryGeometry;
            Assert.IsTrue(fds.Tables[0][0].IsFeatureGeometryNull() == false);
            fds.Tables[0][0].SetFeatureGeometryNull();
            Assert.IsTrue(fds.Tables[0][0].IsFeatureGeometryNull() == true);
            fds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            string schema = fds.GetXmlSchema();
            string xml = fds.GetXml();

        }

        [TestMethod]
        public void RenderViewContextTest()
        {
            StringDictionary parameters = new StringDictionary();
            parameters.Add("styles", "default");
            parameters.Add("width", "512");
            parameters.Add("height", "512");
            parameters.Add("crs", "EPSG:4326");
            parameters.Add("layers", "world_admin");
            parameters.Add("bgcolor", "0x0000FF");
            parameters.Add("version", "1.3.0");
            parameters.Add("format", "image/png");
            parameters.Add("request", "GetMap");
            parameters.Add("bbox", "-180,-85,180,85");

            ViewContext context = new ViewContext();

            // add context details inline for test, this is normally done by ViewContext(parameters) 
            // which applies details from configuration files etc.
            context.General.Window.Width = 512;
            context.General.Window.Height = 512;

            Layer layer = new Layer();
            layer.Title = "World Administration Boundaries";
            layer.Table = "world_admin";
            layer.Name = "world_admin";
            layer.GeometryColumn = "shape";
            layer.FeatureIdColumn = "fid";
            layer.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Projects\\GeospatialServices\\TestGeospatialServices\\Input\\Runtime\\TestGeospatialServicesDatabase.mdf;Integrated Security=True;User Instance=True";

            Style style = new Style();
            UserLayer userLayer = new UserLayer();
            userLayer.UserStyles = new List<UserStyle>();
            UserStyle userStyle = new UserStyle();
            FeatureTypeStyle featureTypeStyle = new FeatureTypeStyle();
            Rule rule = new Rule();
            PolygonSymbolizer polygon = new PolygonSymbolizer();

            style.Name = "default";
            userLayer.Name = "World in green";
            polygon.Fill.SvgParameters.Add(new SvgParameter("fill", "#2E8C7C"));

            BaseSymbolizer[] symbolizers = new BaseSymbolizer[] { polygon };
            rule.Symbolizers = symbolizers;
            featureTypeStyle.Rules.Add(rule);
            userStyle.FeatureTypeStyles.Add(featureTypeStyle);
            userLayer.UserStyles.Add(userStyle);
            style.SLD.StyledLayerDescriptor.UserLayers.Add(userLayer);
            layer.StyleList.Add(style);
            context.Layers.Add(layer);

            System.Drawing.Image mapImage = context.Render(parameters);

        }

        [TestMethod]
        public void RenderSLDInParametersTest()
        {
            StringBuilder sld = new StringBuilder();
            sld.Append("<SLD>");
            sld.Append("<sld:StyledLayerDescriptor>");
            sld.Append("<sld:UserLayer>");
            sld.Append("<sld:Name>World</sld:Name>");
            sld.Append("<sld:UserStyles>");
            sld.Append("<sld:UserStyle>");
            sld.Append("<se:FeatureTypeStyle>");
            sld.Append("<se:Rule>");
            sld.Append("<se:PointSymbolizer>");
            sld.Append("<se:Graphic>");
            sld.Append("<se:Opacity>255</se:Opacity>");
            sld.Append("<se:Mark>");
            sld.Append("<se:WellKnownName>font://Webdings?CharIndex=114</se:WellKnownName>");
            sld.Append("<se:Fill>");
            sld.Append("<se:SvgParameter name=\"fill\">#000000</se:SvgParameter>");
            sld.Append("</se:Fill>");
            sld.Append("</se:Mark>");
            sld.Append("<se:Size>12</se:Size>");
            sld.Append("</se:Graphic>");
            sld.Append("</se:PointSymbolizer>");
            sld.Append("<se:PolygonSymbolizer>");
            sld.Append("<se:Fill>");
            sld.Append("<se:SvgParameter name=\"fill\">#2E8C7C</se:SvgParameter>");
            sld.Append("<se:SvgParameter name=\"fill-opacity\">255</se:SvgParameter>");
            sld.Append("</se:Fill>");
            sld.Append("<se:Stroke>");
            sld.Append("<se:SvgParameter name=\"stroke\">#206055</se:SvgParameter>");
            sld.Append("<se:SvgParameter name=\"stroke-opacity\">255</se:SvgParameter>");
            sld.Append("<se:SvgParameter name=\"stroke-width\">1</se:SvgParameter>");
            sld.Append("</se:Stroke>");
            sld.Append("</se:PolygonSymbolizer>");
            sld.Append("<se:LineSymbolizer>");
            sld.Append("<se:Stroke>");
            sld.Append("<se:SvgParameter name=\"stroke\">#000000</se:SvgParameter>");
            sld.Append("<se:SvgParameter name=\"stroke-width\">1</se:SvgParameter>");
            sld.Append("<se:SvgParameter name=\"stroke-opacity\">255</se:SvgParameter>");
            sld.Append("<se:SvgParameter name=\"stroke-dasharray\">Solid</se:SvgParameter>");
            sld.Append("<se:SvgParameter name=\"stroke-linecap\">Flat</se:SvgParameter>");
            sld.Append("<se:SvgParameter name=\"stroke-linejoin\">Miter</se:SvgParameter>");
            sld.Append("</se:Stroke>");
            sld.Append("</se:LineSymbolizer>");
            sld.Append("</se:Rule>");
            sld.Append("</se:FeatureTypeStyle>");
            sld.Append("</sld:UserStyle>");
            sld.Append("</sld:UserStyles>");
            sld.Append("</sld:UserLayer>");
            sld.Append("</sld:StyledLayerDescriptor>");
            sld.Append("</SLD>");

            StringDictionary parameters = new StringDictionary();
            parameters.Add(WmsParameters.Styles, "default");
            parameters.Add(WmsParameters.Width, "512");
            parameters.Add(WmsParameters.Height, "512");
            parameters.Add(WmsParameters.Crs, "EPSG:4326");
            parameters.Add(WmsParameters.Layers, "world_admin");
            parameters.Add(WmsParameters.BgColor, "0x0000FF");
            parameters.Add("version", "1.3.0");
            parameters.Add(WmsParameters.Format, "image/png");
            parameters.Add("request", "GetMap");
            parameters.Add(WmsParameters.Bbox, "-180,-85,180,85");
            parameters.Add(WmsParameters.SldBody, sld.ToString());

            ViewContext context = new ViewContext();

            // add context details inline for test, this is normally done by ViewContext(parameters) 
            // which applies details from configuration files etc.
            context.General.Window.Width = 512;
            context.General.Window.Height = 512;

            Layer layer = new Layer();
            layer.Title = "World Administration Boundaries";
            layer.Table = "world_admin";
            layer.Name = "world_admin";
            layer.GeometryColumn = "shape";
            layer.FeatureIdColumn = "fid";
            layer.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Projects\\GeospatialServices\\TestGeospatialServices\\Input\\Runtime\\TestGeospatialServicesDatabase.mdf;Integrated Security=True;User Instance=True";

            Style style = new Style();
            UserLayer userLayer = new UserLayer();
            userLayer.UserStyles = new List<UserStyle>();
            UserStyle userStyle = new UserStyle();
            FeatureTypeStyle featureTypeStyle = new FeatureTypeStyle();
            Rule rule = new Rule();
            PolygonSymbolizer polygon = new PolygonSymbolizer();

            style.Name = "default";
            userLayer.Name = "World in green";
            polygon.Fill.SvgParameters.Add(new SvgParameter("fill", "#2E8C7C"));

            BaseSymbolizer[] symbolizers = new BaseSymbolizer[] { polygon };
            rule.Symbolizers = symbolizers;
            featureTypeStyle.Rules.Add(rule);
            userStyle.FeatureTypeStyles.Add(featureTypeStyle);
            userLayer.UserStyles.Add(userStyle);
            style.SLD.StyledLayerDescriptor.UserLayers.Add(userLayer);
            layer.StyleList.Add(style);
            context.Layers.Add(layer);

            System.Drawing.Image mapImage = context.Render(parameters);
        }

        [TestMethod]
        public void GetFeatureSchemaTest()
        {
            ViewContext context = new ViewContext();
            Layer layer = new Layer();
            layer.Title = "World Administration Boundaries";
            layer.Table = "world_admin";
            layer.Name = "world_admin";
            layer.GeometryColumn = "shape";
            layer.FeatureIdColumn = "fid";
            layer.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Projects\\GeospatialServices\\TestGeospatialServices\\Input\\Runtime\\TestGeospatialServicesDatabase.mdf;Integrated Security=True;User Instance=True";
            context.Layers.Add(layer);
            XmlSchema schema = FeatureCollection.GetFeatureSchema(context, false);
        }

        [TestMethod]
        public void SerializeFeatureCollectionTest()
        {
            StringDictionary parameters = new StringDictionary();
            parameters.Add("styles", "default");
            parameters.Add("width", "512");
            parameters.Add("height", "512");
            parameters.Add("crs", "EPSG:4326");
            parameters.Add("layers", "world_admin");
            parameters.Add("bgcolor", "0x0000FF");
            parameters.Add("version", "1.3.0");
            parameters.Add("format", "image/png");
            parameters.Add("request", "GetMap");
            parameters.Add("bbox", "-180,-85,180,85");

            ViewContext context = new ViewContext();

            // add context details inline for test, this is normally done by ViewContext(parameters) 
            // which applies details from configuration files etc.
            context.General.Window.Width = 512;
            context.General.Window.Height = 512;
            context.General.BoundingBox = new BoundingBox("-180,-85,180,85", 4326);

            Layer layer = new Layer();
            layer.Title = "World Administration Boundaries";
            layer.Table = "world_admin";
            layer.Name = "world_admin";
            layer.GeometryColumn = "shape";
            layer.FeatureIdColumn = "fid";
            layer.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Projects\\GeospatialServices\\TestGeospatialServices\\Input\\Runtime\\TestGeospatialServicesDatabase.mdf;Integrated Security=True;User Instance=True";

            context.Layers.Add(layer);

            FeatureCollection featureCollection = new FeatureCollection(context, parameters);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(Declarations.Wfs110DefaultPrefix, Declarations.Wfs110DefaultNameSpace);
            namespaces.Add(Declarations.DefaultPrefix, Declarations.DefaultNameSpace);
            namespaces.Add(Declarations.Wfs110Prefix, Declarations.Wfs110NameSpace);
            namespaces.Add(Declarations.OgcPrefix, Declarations.OgcNameSpace);
            namespaces.Add(Declarations.GmlPrefix, Declarations.GmlNameSpace);
            namespaces.Add(Declarations.GmlSfPrefix, Declarations.GmlSfNameSpace);
            namespaces.Add(Declarations.XlinkPrefix, Declarations.XlinkNameSpace);

            XmlSerializer serializer = new XmlSerializer(typeof(FeatureCollection));
            MemoryStream xmlMemoryStream = new MemoryStream();
            serializer.Serialize(xmlMemoryStream, featureCollection, namespaces);

            xmlMemoryStream.Position = 0;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlMemoryStream);

        }

        [TestMethod]
        public void ExerciseWmcSerializationTest()
        {
            string file = "TestGeospatialServices.Input.Ogc.Wmc.wmc.xml";
            ViewContext viewContext;

            using (TextReader textReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(file)))
            using (XmlReader xmlReader = XmlReader.Create(textReader))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ViewContext));
                viewContext = (ViewContext)serializer.Deserialize(xmlReader);
            }
        }

        [TestMethod]
        public void ExerciseWmcFromCodeTest()
        {
            ViewContext context = new ViewContext();

            // Context -> General
            context.General.Window.Width = 500;
            context.General.Window.Height = 300;
            context.General.BoundingBox.SRS = "EPSG:4326";
            context.General.BoundingBox.MinX = -180;
            context.General.BoundingBox.MinY = -90;
            context.General.BoundingBox.MaxX = 180;
            context.General.BoundingBox.MaxY = 90;
            context.General.Title = "EOS Data Gateways";
            context.General.KeywordList.Add("EOS");
            context.General.KeywordList.Add("EOSDIS");
            context.General.KeywordList.Add("NASA");
            context.General.KeywordList.Add("CCRS");
            context.General.KeywordList.Add("CEOS");
            context.General.KeywordList.Add("OGC");
            context.General.Abstract = "Map View of EOSDIS partners locations";
            context.General.LogoURL.Width = 130;
            context.General.LogoURL.Height = 74;
            context.General.LogoURL.Format = "image/gif";
            context.General.LogoURL.OnlineResource.Type = "simple";
            context.General.LogoURL.OnlineResource.Href = "http://redhook.gsfc.nasa.gov/~imswww/pub/icons/logo.gif";
            context.General.DescriptionURL.Format = "text/html";
            context.General.DescriptionURL.OnlineResource.Type = "simple";
            context.General.DescriptionURL.OnlineResource.Href = "http://eos.nasa.gov/imswelcome";
            context.General.ContactInformation.ContactPersonPrimary.ContactPerson = "Tom Kralidis";
            context.General.ContactInformation.ContactPersonPrimary.ContactOrganisation = "Canada Centre for Remote Sensing";
            context.General.ContactInformation.ContactPosition = "Systems Scientist";
            context.General.ContactInformation.ContactAddress.AddressType = "postal";
            context.General.ContactInformation.ContactAddress.Address = "615 Booth Street, room 650";
            context.General.ContactInformation.ContactAddress.City = "Ottawa";
            context.General.ContactInformation.ContactAddress.StateOrProvince = "Ontario";
            context.General.ContactInformation.ContactAddress.Country = "Canada";
            context.General.ContactInformation.ContactVoiceTelephone = "+01 613 947 1828";
            context.General.ContactInformation.ContactFacsimileTelephone = "+01 613 947 2410";
            context.General.ContactInformation.ContactElectronicMailAddress = "tom.kralidis@ccrs.nrcan.gc.ca";

            context.Version = "1.0";
            context.Id = "TEST";

            // Context -> Layer
            Layer layer = new Layer();
            layer.Queryable = 1;
            layer.Hidden = 0;
            layer.Server.Service = GeospatialServices.Ogc.Common.ServiceNames.WMS;
            layer.Server.Version = "1.0.7";
            layer.Title = "The GLOBE Program Visualization Server";
            layer.Server.OnlineResource.Type = "simple";
            layer.Server.OnlineResource.Href = "http://globe.digitalearth.gov/viz-bin/wmt.cgi";
            layer.Name = "NATIONAL";
            layer.Title = "National Boundaries";
            layer.Abstract = "Context layer: National Boundaries";
            layer.SRS = "EPSG:4326";

            // Context -> Layer -> Format
            layer.FormatList.Add(new Format("GIF", 1));

            // Context -> Layer -> Style 
            Style style1 = new Style();
            style1.Current = 1;
            style1.Name = "default";
            style1.LegendURL.Width = 16;
            style1.LegendURL.Height = 16;
            style1.LegendURL.Format = "image/gif";
            style1.LegendURL.OnlineResource.Type = "simple";
            style1.LegendURL.OnlineResource.Href = "http://mapserv2.esrin.esa.it/cubestor/cubeserv.cgi?VERSION=1.1.0&REQUEST=GetLegendIcon&LAYER=WORLD_MODIS_1KM:MapAdmin&SPATIAL_TYPE=RASTER&STYLE=default&FORMAT=image//gif";


            // Context  -> Layer -> Style -> Named Layer
            NamedLayer namedLayer = new NamedLayer();
            namedLayer.Name = "Roads";

            //  Context  -> Layer -> Style -> Named Layer ->  Named Styles
            namedLayer.NamedStyles.Add(new NamedStyle("Casing"));
            namedLayer.NamedStyles.Add(new NamedStyle("Centerline"));

            //  Context  -> Layer -> Style -> Named Layer ->  User Style
            UserStyle userStyle1 = new UserStyle();

            //  Context  -> Layer -> Style -> Named Layer ->  User Style -> FeatureTypeStyle
            FeatureTypeStyle featureTypeStyle1 = new FeatureTypeStyle();
            Rule rule1 = new Rule();

            // Context  -> Layer -> Style -> Named Layer ->  User Style -> FeatureTypeStyle -> Rule -> Symbolizers
            BaseSymbolizer[] symbolizers = new BaseSymbolizer[6];
            SymbolizerTypes[] symbolizerSelections = new SymbolizerTypes[6];

            // Line Symbolizer
            LineSymbolizer lineSymbolizer = new LineSymbolizer();
            lineSymbolizer.Geometry.PropertyName = "center-line";
            lineSymbolizer.Stroke.SvgParameters.Add(new SvgParameter("stroke", "#0000ff"));
            lineSymbolizer.Stroke.SvgParameters.Add(new SvgParameter("stroke-width", "2"));

            symbolizers[0] = lineSymbolizer;
            symbolizerSelections[0] = SymbolizerTypes.LineSymbolizer;


            // Polygon Symbolizer
            PolygonSymbolizer polygonSymbolizer = new PolygonSymbolizer();
            polygonSymbolizer.Geometry.PropertyName = "the_area";
            polygonSymbolizer.Fill.SvgParameters.Add(new SvgParameter("fill", "#aaaaff"));
            polygonSymbolizer.Stroke.SvgParameters.Add(new SvgParameter("stroke", "#0000aa"));

            symbolizers[1] = polygonSymbolizer;
            symbolizerSelections[1] = SymbolizerTypes.PolygonSymbolizer;


            // Point Symbolizer
            PointSymbolizer pointSymbolizer = new PointSymbolizer();

            // Point Symbolizer - > External Graphic 1
            ExternalGraphic externalGraphic1 = new ExternalGraphic();
            externalGraphic1.OnlineResource.Type = "simple";
            externalGraphic1.OnlineResource.Href = "http://www.vendor.com/geosym/2267.svg";
            externalGraphic1.Format = "image/svg+xml";
            pointSymbolizer.Graphic.ExternalGraphics.Add(externalGraphic1);

            // Point Symbolizer - > External Graphic 2
            ExternalGraphic externalGraphic2 = new ExternalGraphic();
            externalGraphic2.OnlineResource.Type = "simple";
            externalGraphic2.OnlineResource.Href = "http://www.vendor.com/geosym/2267.png";
            externalGraphic2.Format = "image/png";

            pointSymbolizer.Graphic.ExternalGraphics.Add(externalGraphic2);
            pointSymbolizer.Graphic.Size = 15.0;

            symbolizers[2] = pointSymbolizer;
            symbolizerSelections[2] = SymbolizerTypes.PointSymbolizer;

            // Text Symbolizer
            TextSymbolizer textSymbolizer = new TextSymbolizer();
            textSymbolizer.Geometry.PropertyName = "locatedAt";
            textSymbolizer.Label = @"ogc:PropertyName[hospitalName]";
            textSymbolizer.Font.SvgParameters.Add(new SvgParameter("font-family", "Arial"));
            textSymbolizer.Font.SvgParameters.Add(new SvgParameter("font-family", "Sans-Serif"));
            textSymbolizer.Font.SvgParameters.Add(new SvgParameter("font-style", "italic"));
            textSymbolizer.Font.SvgParameters.Add(new SvgParameter("font-size", "10"));
            textSymbolizer.Fill.SvgParameters.Add(new SvgParameter("fill", "#000000"));
            textSymbolizer.LabelPlacement.PointPlacement = new PointPlacement();
            textSymbolizer.LabelPlacement.PointPlacement.AnchorPoint.AnchorPointX = 456;
            textSymbolizer.LabelPlacement.PointPlacement.AnchorPoint.AnchorPointY = 123;
            textSymbolizer.LabelPlacement.PointPlacement.Rotation = 180;
            textSymbolizer.LabelPlacement.PointPlacement.Displacement.DisplacementX = 111;
            textSymbolizer.LabelPlacement.PointPlacement.Displacement.DisplacementY = 222;
            textSymbolizer.LabelPlacement.LinePlacement = new LinePlacement();
            textSymbolizer.LabelPlacement.LinePlacement.Gap = 12;
            textSymbolizer.LabelPlacement.LinePlacement.GeneraliseLine = 3;
            textSymbolizer.LabelPlacement.LinePlacement.InitialGap = 3;
            textSymbolizer.LabelPlacement.LinePlacement.IsAligned = 0;
            textSymbolizer.LabelPlacement.LinePlacement.IsRepeated = 1;
            textSymbolizer.LabelPlacement.LinePlacement.PerpendicularOffset = 5;
            textSymbolizer.Halo.Fill = new Fill();
            textSymbolizer.Halo.Fill.SvgParameters.Add(new SvgParameter("fill", "#000000"));
            textSymbolizer.Halo.Radius = 3;

            symbolizers[3] = textSymbolizer;
            symbolizerSelections[3] = SymbolizerTypes.TextSymbolizer;

            // Raster Symbolizer 1
            RasterSymbolizer rasterSymbolizer1 = new RasterSymbolizer();
            rasterSymbolizer1.Opacity = 1.0;
            rasterSymbolizer1.OverlapBehaviour = OverlapBehaviourTypes.Average;
            rasterSymbolizer1.ColourMap.Categorize.LookupValue = "Rasterdata";
            rasterSymbolizer1.ColourMap.Categorize.Values.Add("#00ff00");
            rasterSymbolizer1.ColourMap.Categorize.Thresholds.Add(-417);
            rasterSymbolizer1.ColourMap.Categorize.Values.Add("#00fa00");
            rasterSymbolizer1.ColourMap.Categorize.Thresholds.Add(-333);

            symbolizers[4] = rasterSymbolizer1;
            symbolizerSelections[4] = SymbolizerTypes.RasterSymbolizer;

            // Raster Symbolizer 2
            RasterSymbolizer rasterSymbolizer2 = new RasterSymbolizer();
            rasterSymbolizer2.Opacity = 1.0;
            rasterSymbolizer2.OverlapBehaviour = OverlapBehaviourTypes.LatestOnTop;
            rasterSymbolizer2.ChannelSelection.RedChannel.SourceChannelName = "1";
            rasterSymbolizer2.ChannelSelection.GreenChannel.SourceChannelName = "2";
            rasterSymbolizer2.ChannelSelection.GreenChannel.ContrastEnhancement.GammaValue = 2.5;
            rasterSymbolizer2.ChannelSelection.BlueChannel.SourceChannelName = "3";
            rasterSymbolizer2.ColourMap.Interpolate.FallBackValue = "#dddddd";
            rasterSymbolizer2.ColourMap.Interpolate.LookupValue = "Rasterdata";
            rasterSymbolizer2.ColourMap.Interpolate.InterpolationPoints.Add(new InterpolationPoint(0, "#000000"));
            rasterSymbolizer2.ColourMap.Interpolate.InterpolationPoints.Add(new InterpolationPoint(255, "#ffffff"));
            rasterSymbolizer2.ContrastEnhancement.GammaValue = 1;
            rasterSymbolizer2.Geometry.PropertyName = "Coastlines";

            symbolizers[5] = rasterSymbolizer2;
            symbolizerSelections[5] = SymbolizerTypes.RasterSymbolizer;

            rule1.SymbolizerSelections = symbolizerSelections;
            rule1.Symbolizers = symbolizers;

            featureTypeStyle1.Rules.Add(rule1);

            Rule rule2 = new Rule();
            rule2.ElseFilter = new ElseFilter();
            featureTypeStyle1.Rules.Add(rule2);


            Rule rule3 = new Rule();
            GeospatialServices.Ogc.Wmc.PropertyIsEqualTo propEqualTo = new PropertyIsEqualTo();
            propEqualTo.Literal.Value = "NEW YORK";
            propEqualTo.PropertyName = "SALES_AREA";

            //BaseComparisonOps ComparisonOps[] = new BaseComparisonOps[2];

            rule3.Filter.FilterExpression = propEqualTo;
            featureTypeStyle1.Rules.Add(rule3);

            userStyle1.FeatureTypeStyles.Add(featureTypeStyle1);
            namedLayer.UserStyles.Add(userStyle1);

            // Context - > Layer -> Style -> User Layer
            UserLayer userLayer = new UserLayer();
            userLayer.Name = "Lakes and Rivers";

            UserStyle userStyle = new UserStyle("Default");
            userStyle.FeatureTypeStyles.Add(featureTypeStyle1);
            userLayer.UserStyles = new List<UserStyle>();
            userLayer.UserStyles.Add(userStyle);

            style1.SLD.StyledLayerDescriptor.NamedLayers.Add(namedLayer);
            style1.SLD.StyledLayerDescriptor.UserLayers.Add(userLayer);

            layer.StyleList.Add(style1);
            context.Layers.Add(layer);

        }

    }
}
