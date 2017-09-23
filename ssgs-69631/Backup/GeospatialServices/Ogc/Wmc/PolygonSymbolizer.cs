using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "PolygonSymbolizer", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class PolygonSymbolizer: BaseSymbolizer 
    {

        [XmlIgnore]
        public bool GeometrySpecified;
        private Geometry m_Geometry;

        [XmlElement(Type = typeof(Geometry), ElementName = "Geometry", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Geometry Geometry
        {
            get
            {
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
        public bool FillSpecified;
        private Fill m_Fill;

        [XmlElement(Type = typeof(Fill), ElementName = "Fill", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Fill Fill
        {
            get
            {
                if (m_Fill == null)
                {
                    m_Fill = new Fill();
                    FillSpecified = true;
                }
                return m_Fill;
            }
            set { m_Fill = value; FillSpecified = true; }
        }

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
            set { m_Stroke = value;  StrokeSpecified = true;}
        }

        [XmlIgnore]
        public bool DisplacementSpecified;
        private Displacement m_Displacement;

        [XmlElement(Type = typeof(Displacement), ElementName = "Displacement", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Displacement Displacement
        {
            get
            {
                if (m_Displacement == null)
                {
                    m_Displacement = new Displacement();
                    DisplacementSpecified = true;
                }
                return m_Displacement; 
            }
            set { m_Displacement = value; DisplacementSpecified = true; }
        }

        [XmlIgnore]
        public bool PrependicularOffsetSpecified;
        private double m_PrependicularOffset;

        [XmlElement(ElementName = "PrependicularOffset", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double PrependicularOffset
        {
            get {return m_PrependicularOffset;}
            set { m_PrependicularOffset = value; PrependicularOffsetSpecified = true; }
        }
    }
}
