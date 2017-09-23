using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "RasterSymbolizer", Namespace = Declarations.SeNameSpace), Serializable]
    public class RasterSymbolizer :BaseSymbolizer 
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
        public bool OpacitySpecified;
        private double m_Opacity;

        [XmlElement(ElementName = "Opacity", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double Opacity
        {
            get {return m_Opacity;}
            set { m_Opacity = value; OpacitySpecified = true; }
        }


        [XmlIgnore]
        public bool ChannelSelectionSpecified;
        private ChannelSelection m_ChannelSelection;

        [XmlElement(Type = typeof(ChannelSelection), ElementName = "ChannelSelection", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public ChannelSelection ChannelSelection
        {
            get
            {
                if (m_ChannelSelection == null)
                {
                    m_ChannelSelection = new ChannelSelection();
                    ChannelSelectionSpecified = true;
                }
                return m_ChannelSelection;
            }
            set { m_ChannelSelection = value; ChannelSelectionSpecified = true; }
        }

        [XmlIgnore]
        public bool OverlapBehaviourSpecified;
        private OverlapBehaviourTypes m_OverlapBehaviour;

        [XmlElement(ElementName = "OverlapBehaviour", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public OverlapBehaviourTypes OverlapBehaviour
        {
            get { return m_OverlapBehaviour; }
            set { m_OverlapBehaviour = value; OverlapBehaviourSpecified = true; }
        }

        [XmlIgnore]
        public bool ColourMapSpecified;
        private ColorMap m_ColourMap;

        [XmlElement(ElementName = "ColorMap", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public ColorMap ColourMap
        {
            get
            {
                if (m_ColourMap == null)
                {
                    m_ColourMap = new ColorMap();
                    ColourMapSpecified = true;
                }

                return m_ColourMap;
            }
            set { m_ColourMap = value; ColourMapSpecified = true; }
        }
        [XmlIgnore]
        public bool ContrastEnhancementSpecified;
        private ContrastEnhancement m_ContrastEnhancement;

        [XmlElement(ElementName = "ContrastEnhancement", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public ContrastEnhancement ContrastEnhancement
        {
            get
            {
                if (m_ContrastEnhancement == null)
                {
                    m_ContrastEnhancement = new ContrastEnhancement();
                    ContrastEnhancementSpecified = true;
                }
                return m_ContrastEnhancement;
            }
            set { m_ContrastEnhancement = value; ContrastEnhancementSpecified = true; }
        }

        [XmlIgnore]
        public bool ShadedReliefSpecified;
        private ShadedRelief m_ShadedRelief;

        [XmlElement(ElementName = "ShadedRelief", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public ShadedRelief ShadedRelief
        {
            get
            {
                if (m_ShadedRelief == null)
                {
                    m_ShadedRelief = new ShadedRelief();
                    ShadedReliefSpecified = true;
                }
                return m_ShadedRelief;
            }
            set { m_ShadedRelief = value; ShadedReliefSpecified = true; }
        }


        [XmlIgnore]
        public bool ImageOutlineSpecified;
        private ImageOutline m_ImageOutline;

        [XmlElement(ElementName = "ImageOutline", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public ImageOutline ImageOutline
        {
            get
            {
                if (m_ImageOutline == null)
                {
                    m_ImageOutline = new ImageOutline();
                    ImageOutlineSpecified = true;
                }
                return m_ImageOutline;
            }
            set { m_ImageOutline = value; ImageOutlineSpecified = true; }
        }
        
    }
}
