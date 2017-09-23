using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "OnlineResource", Namespace = Declarations.XlinkNameSpace), Serializable]
    public partial class OnlineResource
    {

        private string m_Type;

        [XmlAttribute(AttributeName = "type", DataType = "string")]
        public string Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        private string m_Href;

        [XmlAttribute(AttributeName = "href", DataType = "anyURI")]
        public string Href
        {
            get { return m_Href; }
            set { m_Href = value; }
        }
        private string m_Role;

        [XmlAttribute(AttributeName = "role", DataType = "anyURI")]
        public string Role
        {
            get { return m_Role; }
            set { m_Role = value; }
        }
        private string m_ArcRole;

        [XmlAttribute(AttributeName = "arcrole", DataType = "anyURI")]
        public string ArcRole
        {
            get { return m_ArcRole; }
            set { m_ArcRole = value; }
        }
        private string m_Title;

        [XmlAttribute(AttributeName = "title", DataType = "string")]
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }
        
        [XmlIgnore]
        public bool ShowSpecified;

        private ShowTypes m_Show;

        [XmlAttribute(AttributeName = "show")]
        public ShowTypes Show
        {
            get { return m_Show; }
            set { m_Show = value; ShowSpecified = true; }
        }

        [XmlIgnore]
        public bool ActuateSpecified;
        private ActuateTypes m_Actuate;


        [XmlAttribute(AttributeName = "actuate")]
        public ActuateTypes Actuate
        {
            get { return m_Actuate; }
            set { m_Actuate = value; ActuateSpecified = true; }
        }
    }
}
