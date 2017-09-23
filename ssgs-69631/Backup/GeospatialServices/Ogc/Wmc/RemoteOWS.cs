using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "RemoteOWS", Namespace = Declarations.SldNameSpace), Serializable]
    public partial class RemoteOWS
    {
       
        private ServiceNames m_Service;
        
        [XmlElement(ElementName = "Service", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public ServiceNames Service
        {
            get { return m_Service; }
            set { m_Service = value; }
        }
        
        private OnlineResource m_OnlineResource;

        [XmlElement(Type = typeof(OnlineResource), ElementName = "OnlineResource", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public OnlineResource OnlineResource
        {
            get { return m_OnlineResource; }
            set { m_OnlineResource = value; }
        }
    }
}
