using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Recode", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class Recode
    {
        private string m_FallBackValue;

        [XmlAttribute(AttributeName = "fallbackValue", DataType = "string")]
        public string FallBackValue
        {
            get { return m_FallBackValue; }
            set { m_FallBackValue = value; }
        }

        
        
        private string m_LookupValue;

        [XmlElement(ElementName = "LookupValue", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public string LookupValue
        {
            get {return m_LookupValue;}
            set { m_LookupValue = value;}
        }

        [XmlIgnore]
        public bool MapItemsSpecified;
        private List<MapItem> m_MapItems;
        [XmlElement(Type = typeof(MapItem), ElementName = "MapItem", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<MapItem> MapItems
        {
            get
            {
                if (m_MapItems == null)
                {
                    m_MapItems = new List<MapItem>(); 
                    MapItemsSpecified = true;
                }
                return m_MapItems; 
            }
            set { m_MapItems = value; MapItemsSpecified = true; }
        }

        
    }
}
