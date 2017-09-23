using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace  GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Stroke", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class Stroke
    {
        [XmlIgnore]
        public bool GraphicFillSpecified;
        private GraphicFill m_GraphicFill;

        [XmlElement(Type = typeof(GraphicFill), ElementName = "GraphicFill", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public GraphicFill GraphicFill
        {
            get
            {
                if (m_GraphicFill == null)
                {
                    m_GraphicFill = new GraphicFill();
                    GraphicFillSpecified = true; 
                }
                return m_GraphicFill; }
            set { m_GraphicFill = value; GraphicFillSpecified = true; }
        }

        [XmlIgnore]
        public bool GraphicStrokeSpecified;
        private GraphicStroke m_GraphicStroke;
        
        [XmlElement(Type = typeof(GraphicStroke), ElementName = "GraphicStroke", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public GraphicStroke GraphicStroke
        {
            get
            {
                if (m_GraphicStroke == null)
                {
                    m_GraphicStroke = new GraphicStroke();
                    GraphicStrokeSpecified = true; 
                }
                return m_GraphicStroke; 
            }
            set { m_GraphicStroke = value; GraphicStrokeSpecified = true; }
        }

        [XmlIgnore]
        public bool SvgParametersSpecified;
        private List<SvgParameter> m_SvgParameters;

        [XmlElement(Type = typeof(SvgParameter), ElementName = "SvgParameter", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<SvgParameter> SvgParameters
        {
            get 
            {
                if (m_SvgParameters == null)
                {
                    m_SvgParameters = new List<SvgParameter>();
                    SvgParametersSpecified = true;
 
                }
                return m_SvgParameters; 
            }
            set { m_SvgParameters = value; SvgParametersSpecified = true;}
        }



    }
}
