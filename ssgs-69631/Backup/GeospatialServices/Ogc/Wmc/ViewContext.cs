using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.ComponentModel;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{

    [XmlType(TypeName = "ViewContext", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class ViewContext
    {
        
        private string m_Version;

        [XmlAttribute(AttributeName = "version", DataType = "string")]
        public string Version
        {
            get { return m_Version; }
            set { m_Version = value; }
        }

        
        private String m_Id;

        [XmlAttribute(AttributeName = "id", DataType = "string")]
        public String Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        
        private General m_General;

        [XmlElement(Type = typeof(General), ElementName = "General", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public General General
        {
            get { return m_General = (m_General == null)? new General(): m_General ; }
            set { m_General = value; }
        }

        
        private List<Layer> m_Layers;

        [XmlArray(ElementName = "LayerList", Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem(ElementName = "Layer", Form = XmlSchemaForm.Unqualified)] 
        public List<Layer> Layers
        {
            get { return m_Layers = (m_Layers==null)? new List<Layer>(): m_Layers; }
            set { m_Layers = value; }
        }
    }
}
