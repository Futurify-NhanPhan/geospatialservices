using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "ImageOutline", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class ImageOutline
    {
        [XmlIgnore]
        public bool LineSymbolizerSpecified;
        private LineSymbolizer m_LineSymbolizer;

        [XmlElement(Type = typeof(LineSymbolizer), ElementName = "LineSymbolizer", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public LineSymbolizer LineSymbolizer
        {
            get 
            { return m_LineSymbolizer; }
            set { m_LineSymbolizer = value; LineSymbolizerSpecified = true; }
        }

        [XmlIgnore]
        public bool PolygonSymbolizerSpecified;
        private PolygonSymbolizer m_PolygonSymbolizer;

        [XmlElement(Type = typeof(PolygonSymbolizer), ElementName = "PolygonSymbolizer", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public PolygonSymbolizer PolygonSymbolizer
        {
            get { return m_PolygonSymbolizer; }
            set { m_PolygonSymbolizer = value; PolygonSymbolizerSpecified = true; }
        }
    }
}
