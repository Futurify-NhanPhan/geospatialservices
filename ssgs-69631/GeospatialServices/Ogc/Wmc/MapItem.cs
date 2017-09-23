using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "MapItem", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class MapItem
    {

        public MapItem()
        {
        }

        public MapItem(double data, string value)
        {
            m_Data = data;
            m_Value = value;
        }

        private double m_Data;
        
        [XmlElement(ElementName = "Data", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double Data
        {
            get { return m_Data; }
            set { m_Data = value; }
        }

        [XmlIgnore]
        private string m_Value;

        [XmlElement(ElementName = "Value", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public string Value
        {
            get{ return m_Value;}
            set { m_Value = value;}
        }

    }
}
