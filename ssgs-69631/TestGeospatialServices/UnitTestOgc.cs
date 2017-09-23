using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using GeospatialServices.Ogc.Wmc;
using System.Xml;
using System.Xml.Serialization;
using System.Net;
using GeospatialServices.Ogc.Wms;
using GeospatialServices.Ogc.Common;
using GeospatialServices.Ogc.Wfs;

namespace TestGeospatialServices
{
    /// <summary>
    /// Summary description for UnitTestOgc
    /// </summary>
    [TestClass]
    public class UnitTestOgc
    {
        private const string _wmsHandlerURL = "http://localhost:49241/service.wms";
        private const string _wfsHandlerURL = "http://localhost:49241/service.wfs";

        public UnitTestOgc()
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
        public void WmcSerialisationTest()
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
        public void GetWFSCapabilitiesTest()
        {
            string url = _wfsHandlerURL + "?SERVICE=WFS&REQUEST=GetCapabilities&VERSION=1.1.0";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Assert.AreEqual("text/xml", response.ContentType);

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Serialize
            XmlSerializer serializer = new XmlSerializer(typeof(WFS_Capabilities), string.Empty);

            WFS_Capabilities capabilities = (WFS_Capabilities)serializer.Deserialize(receiveStream);

            Assert.AreEqual(capabilities.Version, "1.1.0");
            Assert.AreEqual("WFS", capabilities.ServiceIdentification.Title);
        }

        [TestMethod]
        public void GetWMSCapabilitiesTest()
        {
            string url = _wmsHandlerURL + "?SERVICE=WMS&REQUEST=GetCapabilities&VERSION=1.3.0";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Assert.AreEqual("text/xml", response.ContentType);

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Serialize
            XmlSerializer serializer = new XmlSerializer(typeof(WMS_Capabilities), Declarations.WmsNameSpace);

            WMS_Capabilities capabilities = (WMS_Capabilities)serializer.Deserialize(receiveStream);

            Assert.AreEqual(capabilities.Version, "1.3.0");
            Assert.AreNotEqual(capabilities.Capability.Layer.LayerList.Count, 0);
            Assert.AreNotEqual(capabilities.Service.KeywordList.Count, 0);
            Assert.IsNotNull(capabilities.Service.ContactInformation);
            Assert.AreEqual("Web Map Service", capabilities.Service.Title);
        }

        [TestMethod]
        public void GetMapTest()
        {
            string url = _wmsHandlerURL + "?service.wms?VERSION=1.3.0&REQUEST=GetMap&LAYERS=world_admin&STYLES=&CRS=EPSG:4326&BBOX=-180,-85,180,85&WIDTH=512&HEIGHT=512&FORMAT=image/png&BGCOLOR=0x0000FF";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Assert.IsTrue(response.ContentLength > 100 && response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void GetFeatureLargeTest()
        {
            string url = _wfsHandlerURL + "?SERVICE=WFS&VERSION=1.1.0&REQUEST=GetFeature&TYPENAME=world_admin";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Assert.IsTrue(response.ContentLength > 3000000 && response.StatusCode == HttpStatusCode.OK);
            string responseString = GetResponseAsString(response);
            Assert.IsTrue(responseString.Contains("gmlsf:world_admin"));
        }

        [TestMethod]
        public void DescribeFeatureTypeTest()
        {
            string url = _wfsHandlerURL + "?SERVICE=WFS&VERSION=1.1.0&REQUEST=DescribeFeatureType&TYPENAME=world_admin";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Assert.IsTrue(response.ContentLength > 100 && response.StatusCode == HttpStatusCode.OK);
            string responseString = GetResponseAsString(response);
            Assert.IsTrue(responseString.Contains("world_adminType"));            

        }

        [TestMethod]
        public void GetMapInvalidRequestTest()
        {
            string url = _wmsHandlerURL + "?service.wms?VERSION=1.3.0&REQUEST=GetImage&LAYERS=world_admin&STYLES=&CRS=EPSG:4326&BBOX=-180,-85,180,85&WIDTH=512&HEIGHT=512&FORMAT=image/png&BGCOLOR=0x0000FF";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Assert.IsTrue(response.ContentLength > 100 && response.StatusCode == HttpStatusCode.OK);
            Assert.AreEqual("text/xml", response.ContentType);
            string responseString = GetResponseAsString(response);
            Assert.IsTrue(responseString.Contains("ServiceExceptionReport"));            
        }

        private string GetResponseAsString(HttpWebResponse response)
        {
            Stream receiveStream = response.GetResponseStream();
            string responseText = null;
            StringBuilder sb = new StringBuilder();
            byte[] buffer = new byte[8192];
            int count = 0;
            do
            {
                count = receiveStream.Read(buffer, 0, buffer.Length);
                if (count != 0)
                {
                    responseText = Encoding.ASCII.GetString(buffer, 0, count);
                    sb.Append(responseText);
                }
            }
            while (count > 0);

            return sb.ToString();
        }
    }
}
