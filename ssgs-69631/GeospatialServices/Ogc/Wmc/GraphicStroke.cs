using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "GraphicStroke", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class GraphicStroke
    {
        [XmlIgnore] 
        public bool GraphicSpecified;
        private Graphic m_Graphic;

        [XmlElement(Type= typeof(Graphic), ElementName = "Graphic", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Graphic Graphic
        {
            get 
            {
                if (m_Graphic == null)
                {
                    m_Graphic = new Graphic();
                    GraphicSpecified = true; 
                }
                return m_Graphic; 
            }
            set { m_Graphic = value; GraphicSpecified = true; }
        }

        [XmlIgnore]
        public bool InitialGapSpecified;
        private double m_InitialGap;

        [XmlElement(ElementName = "InitialGap", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double InitialGap
        {
            get { return m_InitialGap; }
            set { m_InitialGap = value; InitialGapSpecified = true;}
        }

        [XmlIgnore]
        public bool GapSpecified;
        private double m_Gap;

        [XmlElement(ElementName = "Gap", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double Gap
        {
            get{return m_Gap;}
            set { m_Gap = value; GapSpecified = true; }
        }
    }
}
