using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Server", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class Server
    {

        private ServiceNames m_Service;

        [XmlAttribute(AttributeName = "service")]
        public ServiceNames Service
        {
            get { return m_Service; }
            set { m_Service = value; }
        }
        private string m_Version;

        [XmlAttribute(AttributeName = "version", DataType = "string")]
        public string Version
        {
            get { return m_Version; }
            set { m_Version = value; }
        }
        private string m_Title;

        [XmlAttribute(AttributeName = "title", DataType = "string")]
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }
        private OnlineResource m_OnlineResource;

        [XmlElement(Type = typeof(OnlineResource), ElementName = "OnlineResource", IsNullable = true, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public OnlineResource OnlineResource
        {
            get { return m_OnlineResource = (m_OnlineResource == null)? new OnlineResource() : m_OnlineResource;}
            set { m_OnlineResource = value; }
        }
    }
}
