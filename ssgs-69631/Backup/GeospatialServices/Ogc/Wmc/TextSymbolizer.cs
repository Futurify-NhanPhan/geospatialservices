using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "TextSymbolizer", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class TextSymbolizer : BaseSymbolizer 
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

        private string m_Label;
        [XmlElement( ElementName = "Label", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public string Label
        {
            get { return m_Label; }
            set { m_Label = value; }
        }

        [XmlIgnore]
        public bool FontSpecified;
        private Font m_Font;

        [XmlElement(Type = typeof(Font), ElementName = "Font", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Font Font
        {
            get 
            {
                if (m_Font == null)
                {
                    m_Font = new Font();
                    FontSpecified = true;
                }
                return m_Font; 
            }
            set { m_Font = value; FontSpecified = true; }
        }
        [XmlIgnore]
        public bool LabelPlacementSpecified;
        private LabelPlacement m_LabelPlacement;

        [XmlElement(Type = typeof(LabelPlacement), ElementName = "LabelPlacement", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public LabelPlacement LabelPlacement
        {
            get 
            {
                if (m_LabelPlacement == null)
                {
                    m_LabelPlacement = new LabelPlacement();
                    LabelPlacementSpecified = true;
                }
                return m_LabelPlacement; 
            }
            set { m_LabelPlacement = value; LabelPlacementSpecified = true; }
        }


        [XmlIgnore]
        public bool HaloSpecified;
        private Halo m_Halo;

        [XmlElement(Type = typeof(Halo), ElementName = "Halo", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Halo Halo
        {
            get 
            {
                if (m_Halo == null)
                {
                    m_Halo = new Halo();
                    HaloSpecified = true;
                }
                return m_Halo; 
            }
            set { m_Halo = value; HaloSpecified = true; }
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
        
    }
}
