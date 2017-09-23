using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "LineSymbolizer", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class LineSymbolizer :BaseSymbolizer 
    {
        [XmlIgnore]
        public bool StrokeSpecified;
        private Stroke m_Stroke;

        [XmlElement(Type = typeof(Stroke), ElementName = "Stroke", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Stroke Stroke
        {
            get
            {
                if (m_Stroke == null)
                {
                    m_Stroke = new Stroke();
                    StrokeSpecified = true;
                }
                return m_Stroke;
            }
            set { m_Stroke = value; StrokeSpecified = true; }
        }

        [XmlIgnore]
        public bool GeometrySpecified; 
        private Geometry m_Geometry;

        [XmlElement(Type = typeof(Geometry), ElementName = "Geometry", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Geometry Geometry
        {
            get {
                if (m_Geometry == null)
                {
                    m_Geometry = new Geometry();
                    GeometrySpecified = true; 
                }
                return m_Geometry;
            }
            set { m_Geometry = value; GeometrySpecified = true; }
        }

        [XmlIgnore]
        public bool PrependicularOffsetSpecified;
        private double  m_PrependicularOffset;

        [XmlElement(ElementName = "PrependicularOffset", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]        
        public double PrependicularOffset
        {
            get { return m_PrependicularOffset; }
                set { m_PrependicularOffset = value; PrependicularOffsetSpecified = true; }
        }
    }
}
