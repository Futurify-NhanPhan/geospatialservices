using GeospatialServices.GeoJSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SqlServer.Types;
using System.Configuration;
using System.Collections.Generic;

namespace TestGeospatialServices
{
    
    
    /// <summary>
    ///This is a test class for GeoJSONTest and is intended
    ///to contain all GeoJSONTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GeoJSONTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        /// Date encoding follows Microsoft JSON method see http://weblogs.asp.net/bleroy/archive/2008/01/18/dates-and-json.aspx
        /// </summary>
        [TestMethod()]
        public void JSONDecodeTest()
        {
            string json = "{\"type\":\"FeatureCollection\", \"features\":[{\"type\":\"Feature\", \"crs\":{\"type\":\"name\", \"properties\":{\"name\":\"epsg:101\"}}, \"geometry\":{\"type\":\"Polygon\", \"coordinates\":[[[52, 18], [66, 23], [73, 9], [48, 6], [52, 18], [59, 18], [67, 18], [67, 13], [59, 13], [59, 18]], [[52, 18], [66, 23], [73, 9], [48, 6], [52, 18], [59, 18], [67, 18], [67, 13], [59, 13], [59, 18]]]}, \"properties\":{\"fid\":101, \"name\":\"BLUE LAKE\", \"boating\":true, \"fishing\":false, \"temp\":null, \"season_starts\":\"/Date(1198908717056)/\", \"pollution_level\":\"\uFFFF\", \"volume\":0.4542e+34 }}]}";
            object actual;
            actual = JSON.JsonDecode(json);
            Dictionary<string, object> result = actual as Dictionary<string, object>;
            Assert.IsTrue(result.Count == 2);
        }


        /// <summary>
        ///A test for GeoJSONToGeometry
        ///</summary>
        [TestMethod()]
        public void GeoJSONToGeometryTest()
        {
            string json = "{\"type\":\"FeatureCollection\", \"features\":[{\"type\":\"Feature\", \"geometry\":{\"type\":\"Polygon\", \"coordinates\":[[[-41.2281722793271, 174.70763047448], [-41.1553878554989, 174.777668316277], [-41.1560745010067, 174.840839702996], [-41.2171859512021, 174.878605205926], [-41.2549514541317, 174.807880718621], [-41.2803573379208, 174.802387554559], [-41.2824172744442, 174.834659893426], [-41.3270492324521, 174.841526348504], [-41.3531417617489, 174.774921734246], [-41.3043899306942, 174.715870220574], [-41.2281722793271, 174.70763047448]]]}, \"properties\":{}}]}";
            System.Data.SqlTypes.SqlChars wkbGeometry = new System.Data.SqlTypes.SqlChars("POLYGON ((-41.2281722793271 174.70763047448, -41.1553878554989 174.777668316277, -41.1560745010067 174.840839702996, -41.2171859512021 174.878605205926, -41.2549514541317 174.807880718621, -41.2803573379208 174.802387554559, -41.2824172744442 174.834659893426, -41.3270492324521 174.841526348504, -41.3531417617489 174.774921734246, -41.3043899306942 174.715870220574, -41.2281722793271 174.70763047448))");
            SqlGeometry expected = SqlGeometry.STGeomFromText(wkbGeometry, 4326);
            SqlGeometry actual;
            actual = GeoJSON.JSONToGeometry(json);
            Assert.AreEqual(expected.ToString(), actual.ToString());       
        }

        [TestMethod()]
        public void SqlGeometryToJSONTest()
        {
            string expected = "{\"type\":\"FeatureCollection\", \"features\":[{\"type\":\"Feature\", \"geometry\":{\"type\":\"Polygon\", \"coordinates\":[[[-41.2281722793271, 174.70763047448], [-41.1553878554989, 174.777668316277], [-41.1560745010067, 174.840839702996], [-41.2171859512021, 174.878605205926], [-41.2549514541317, 174.807880718621], [-41.2803573379208, 174.802387554559], [-41.2824172744442, 174.834659893426], [-41.3270492324521, 174.841526348504], [-41.3531417617489, 174.774921734246], [-41.3043899306942, 174.715870220574], [-41.2281722793271, 174.70763047448]]]}, \"properties\":null, \"crs\":{\"type\":\"name\", \"properties\":{\"name\":\"epsg:4326\"}}}]}";
            System.Data.SqlTypes.SqlChars wkbGeometry = new System.Data.SqlTypes.SqlChars("POLYGON ((-41.2281722793271 174.70763047448, -41.1553878554989 174.777668316277, -41.1560745010067 174.840839702996, -41.2171859512021 174.878605205926, -41.2549514541317 174.807880718621, -41.2803573379208 174.802387554559, -41.2824172744442 174.834659893426, -41.3270492324521 174.841526348504, -41.3531417617489 174.774921734246, -41.3043899306942 174.715870220574, -41.2281722793271 174.70763047448))");
            SqlGeometry sqlGeometry = SqlGeometry.STGeomFromText(wkbGeometry, 4326);
            string actual;
            actual = GeoJSON.SqlGeometryToJSON(sqlGeometry);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GeoJSONToWkt
        ///</summary>
        [TestMethod()]
        public void GeoJSONPolygonToWktTest()
        {
            string json = "{\"type\":\"FeatureCollection\", \"features\":[{\"type\":\"Feature\", \"crs\" : { \"type\" : \"name\", \"properties\" : { \"name\" : \"epsg:4326\" } } \"geometry\":{\"type\":\"Polygon\", \"coordinates\":[[[-41.2281722793271, 174.70763047448], [-41.1553878554989, 174.777668316277], [-41.1560745010067, 174.840839702996], [-41.2171859512021, 174.878605205926], [-41.2549514541317, 174.807880718621], [-41.2803573379208, 174.802387554559], [-41.2824172744442, 174.834659893426], [-41.3270492324521, 174.841526348504], [-41.3531417617489, 174.774921734246], [-41.3043899306942, 174.715870220574], [-41.2281722793271, 174.70763047448]]]}, \"properties\":{}}]}";
            string expected = "POLYGON ((-41.2281722793271 174.70763047448, -41.1553878554989 174.777668316277, -41.1560745010067 174.840839702996, -41.2171859512021 174.878605205926, -41.2549514541317 174.807880718621, -41.2803573379208 174.802387554559, -41.2824172744442 174.834659893426, -41.3270492324521 174.841526348504, -41.3531417617489 174.774921734246, -41.3043899306942 174.715870220574, -41.2281722793271 174.70763047448) )";
            string actual;
            int srid = 0;
            actual = GeoJSON.GeoJSONToWkt(json, out srid);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(4326, srid);
        }

        [TestMethod()]
        public void GeoJSONPointToWktTest()
        {
            string json = "{\"type\":\"FeatureCollection\", \"features\":[{\"type\":\"Feature\", \"crs\" : { \"type\" : \"name\", \"properties\" : { \"name\" : \"epsg:4326\" } } \"geometry\":{\"type\":\"Point\", \"coordinates\":[-41.2281722793271, 174.70763047448]}, \"properties\":{}}]}";
            string expected = "POINT (-41.2281722793271 174.70763047448)";
            string actual;
            int srid = 0;
            actual = GeoJSON.GeoJSONToWkt(json, out srid);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(4326, srid);
        }

        [TestMethod()]
        public void GeoJSONLineStringToWktTest()
        {
            string json = "{\"type\":\"FeatureCollection\", \"features\":[{\"type\":\"Feature\", \"crs\" : { \"type\" : \"name\", \"properties\" : { \"name\" : \"epsg:4326\" } } \"geometry\":{\"type\":\"LineString\", \"coordinates\":[[-41.2281722793271, 174.70763047448], [-41.1553878554989, 174.777668316277], [-41.1560745010067, 174.840839702996], [-41.2171859512021, 174.878605205926], [-41.2549514541317, 174.807880718621], [-41.2803573379208, 174.802387554559], [-41.2824172744442, 174.834659893426], [-41.3270492324521, 174.841526348504], [-41.3531417617489, 174.774921734246]]}, \"properties\":{}}]}";
            string expected = "LINESTRING (-41.2281722793271 174.70763047448, -41.1553878554989 174.777668316277, -41.1560745010067 174.840839702996, -41.2171859512021 174.878605205926, -41.2549514541317 174.807880718621, -41.2803573379208 174.802387554559, -41.2824172744442 174.834659893426, -41.3270492324521 174.841526348504, -41.3531417617489 174.774921734246)";
            string actual;
            int srid = 0;
            actual = GeoJSON.GeoJSONToWkt(json, out srid);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(4326, srid);
        }

        /// <summary>
        ///A test for SqlToGeoJSON with no JSON input
        ///</summary>
        [TestMethod()]
        public void SqlToGeoJSONTest()
        {
            string connectionString = TestGeospatialServices.Properties.Settings.Default.TestDb;
            string providerInvariantName = "System.Data.SqlClient";
            string sql = "SELECT * FROM us_cities where FID = 1";
            string json = "{}";
            string expected = "{\"type\":\"FeatureCollection\", \"features\":[{\"type\":\"Feature\", \"crs\":{\"type\":\"name\", \"properties\":{\"name\":\"epsg:4326\"}}, \"geometry\":{\"type\":\"Point\", \"coordinates\":[-81.6717, 31.7528]}, \"properties\":{\"FID\":1, \"ST_FIPS\":\"13\", \"SFIPS\":\"13\", \"COUNTY_FIP\":\"179\", \"CFIPS\":\"179\", \"PL_FIPS\":\"80256\", \"ID\":\"348148\", \"ELEVATION\":\"71\", \"POP_1990\":2024, \"POPULATION\":\"4030\", \"NAME\":\"AIMAR\", \"ST\":\"GA\", \"STATE\":\"GEORGIA\", \"WARNGENLEV\":\"3\", \"WARNGENTYP\":\"\", \"WATCH_WARN\":\"3\", \"ZWATCH_WAR\":0, \"PROG_DISC\":230, \"ZPROG_DISC\":3640, \"COMBOFLAG\":0, \"LAND_WATER\":\"\", \"RECNUM\":0, \"LON\":-81.6717, \"LAT\":31.7528}}]}";
            string actual;
            actual = GeoJSONService.DatabaseRequest(json, connectionString, providerInvariantName, sql);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GeoJSONServiceWithGeometryTest()
        {
            string connectionString = TestGeospatialServices.Properties.Settings.Default.TestDb;
            string providerInvariantName = "System.Data.SqlClient";
            string sql = "SELECT count(*) as city_count, SUM(POP_1990) total_pop_1990, SUM(cast(POPULATION as float)) total_pop_2009 FROM us_cities where geom.STIntersects(Geometry::STGeomFromText(@wkt,@srid)) = 1 and WATCH_WARN = @WATCH_WARN";
            string json = "{\"type\":\"FeatureCollection\", \"features\":[{\"type\":\"Feature\", \"geometry\":{\"type\":\"Polygon\", \"coordinates\":[[[-88, 40], [-84, 40], [-84, 43], [-88, 40], [-88, 40]]]}, \"properties\":{\"WATCH_WARN\": 1}, \"crs\":{\"type\":\"name\", \"properties\":{\"name\":\"epsg:4326\"}}}]}";
            string expected = "{\"type\":\"FeatureCollection\", \"features\":[{\"type\":\"Feature\", \"geometry\":null, \"properties\":{\"city_count\":71, \"total_pop_1990\":1064299, \"total_pop_2009\":1139609}}]}";
            string actual;
            actual = GeoJSONService.DatabaseRequest(json, connectionString, providerInvariantName, sql);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void LakesToGeoJSONTest()
        {
            string connectionString = TestGeospatialServices.Properties.Settings.Default.TestDb;
            string providerInvariantName = "System.Data.SqlClient";
            string sql = "SELECT * FROM lakes";
            string json = "{}";
            string expected = "{\"type\":\"FeatureCollection\", \"features\":[{\"type\":\"Feature\", \"crs\":{\"type\":\"name\", \"properties\":{\"name\":\"epsg:101\"}}, \"geometry\":{\"type\":\"Polygon\", \"coordinates\":[[[52, 18], [66, 23], [73, 9], [48, 6], [52, 18], [59, 18], [67, 18], [67, 13], [59, 13], [59, 18]], [[52, 18], [66, 23], [73, 9], [48, 6], [52, 18], [59, 18], [67, 18], [67, 13], [59, 13], [59, 18]]]}, \"properties\":{\"fid\":101, \"name\":\"BLUE LAKE\"}}]}";
            string actual;
            actual = GeoJSONService.DatabaseRequest(json, connectionString, providerInvariantName, sql);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RoadSegmentsToGeoJSONTest()
        {
            string connectionString = TestGeospatialServices.Properties.Settings.Default.TestDb;
            string providerInvariantName = "System.Data.SqlClient";
            string sql = "SELECT * FROM road_segments";
            string json = "{}";
            string expected = "{\"type\":\"FeatureCollection\", \"features\":[{\"type\":\"Feature\", \"crs\":{\"type\":\"name\", \"properties\":{\"name\":\"epsg:101\"}}, \"geometry\":{\"type\":\"LineString\", \"coordinates\":[[0, 18], [10, 21], [16, 23], [28, 26], [44, 31]]}, \"properties\":{\"fid\":102, \"name\":\"Route 5\", \"aliases\":null, \"num_lanes\":2}}, {\"type\":\"Feature\", \"crs\":{\"type\":\"name\", \"properties\":{\"name\":\"epsg:101\"}}, \"geometry\":{\"type\":\"LineString\", \"coordinates\":[[44, 31], [56, 34], [70, 38]]}, \"properties\":{\"fid\":103, \"name\":\"Route 5\", \"aliases\":\"Main Street\", \"num_lanes\":4}}, {\"type\":\"Feature\", \"crs\":{\"type\":\"name\", \"properties\":{\"name\":\"epsg:101\"}}, \"geometry\":{\"type\":\"LineString\", \"coordinates\":[[70, 38], [72, 48]]}, \"properties\":{\"fid\":104, \"name\":\"Route 5\", \"aliases\":null, \"num_lanes\":2}}, {\"type\":\"Feature\", \"crs\":{\"type\":\"name\", \"properties\":{\"name\":\"epsg:101\"}}, \"geometry\":{\"type\":\"LineString\", \"coordinates\":[[70, 38], [84, 42]]}, \"properties\":{\"fid\":105, \"name\":\"Main Street\", \"aliases\":null, \"num_lanes\":4}}, {\"type\":\"Feature\", \"crs\":{\"type\":\"name\", \"properties\":{\"name\":\"epsg:101\"}}, \"geometry\":{\"type\":\"LineString\", \"coordinates\":[[28, 26], [28, 0]]}, \"properties\":{\"fid\":106, \"name\":\"Dirt Road by Green Forest\", \"aliases\":null, \"num_lanes\":1}}]}";
            string actual;
            actual = GeoJSONService.DatabaseRequest(json, connectionString, providerInvariantName, sql);
            Assert.AreEqual(expected, actual);
        }


    }
}
