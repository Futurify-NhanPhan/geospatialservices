using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Rule", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class Rule
    {
        private string m_Name;

        [XmlElement(ElementName = "Name", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "string", Namespace = Declarations.SeNameSpace)]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        [XmlIgnore]
        public bool DescriptionSpecified;
        private Description m_Description;

        [XmlElement(Type = typeof(Description), ElementName = "Description", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Description Description
        {
            get
            {
                if (m_Description == null)
                {
                    m_Description = new Description();
                    DescriptionSpecified = true;
                }

                return m_Description;
            }
            set { m_Description = value; DescriptionSpecified = true; }
        }

        [XmlIgnore]
        public bool LegendGraphicSpecified;
        private Graphic m_LegendGraphic;

        [XmlElement(Type = typeof(Graphic), ElementName = "LegendGraphic", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Graphic LegendGraphic
        {
            get
            {
                if (m_LegendGraphic == null)
                {
                    m_LegendGraphic = new Graphic();
                    LegendGraphicSpecified = true;
                }

                return m_LegendGraphic;
            }
            set { m_LegendGraphic = value; LegendGraphicSpecified = true; }
        }


        [XmlIgnore]
        public bool FilterSpecified;
        private Filter m_Filter;
        
        [XmlElement(Type = typeof(Filter), ElementName = "Filter", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public Filter Filter
        {
            get 
            {
                if (m_Filter == null)
                {
                    m_Filter = new Filter();
                    FilterSpecified = true;
                }
                return m_Filter; 
            }
            set { m_Filter = value; }
        }

        [XmlIgnore]
        public bool ElseFilterSpecified;
        private ElseFilter m_ElseFilter;

        [XmlElement(Type = typeof(ElseFilter), ElementName = "ElseFilter", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public ElseFilter ElseFilter
        {
            get
            {
                if (m_ElseFilter == null)
                {
                    m_ElseFilter = new ElseFilter();
                    ElseFilterSpecified = true;
                }
                return m_ElseFilter;
            }
            set { m_ElseFilter = value; }
        }

        private double m_MinScaleDenominator;
        [XmlIgnore]
        public bool MinScaleDenominatorSpecified;

        [XmlElement(ElementName = "MinScaleDenominator", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double MinScaleDenominator
        {
            get { return m_MinScaleDenominator; }
            set { m_MinScaleDenominator = value; MinScaleDenominatorSpecified = true; }
        }
        
        private double m_MaxScaleDenominator;
        [XmlIgnore]
        public bool MaxScaleDenominatorSpecified;

        [XmlElement(ElementName = "MaxScaleDenominator", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double MaxScaleDenominator
        {
            get { return m_MaxScaleDenominator; }
            set { m_MaxScaleDenominator = value; MaxScaleDenominatorSpecified = true; }
        }


        [XmlIgnore]
        public bool SymbolizersSpecified;

        [XmlIgnore]
        public SymbolizerTypes[] SymbolizerSelections;

        private BaseSymbolizer[] m_Symbolizers;

        [XmlChoiceIdentifier(MemberName = "SymbolizerSelections")]
        [XmlElement(ElementName = "PointSymbolizer", Type = typeof(PointSymbolizer), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        [XmlElement(ElementName = "LineSymbolizer", Type = typeof(LineSymbolizer), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        [XmlElement(ElementName = "PolygonSymbolizer", Type = typeof(PolygonSymbolizer), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        [XmlElement(ElementName = "RasterSymbolizer", Type = typeof(RasterSymbolizer), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        [XmlElement(ElementName = "TextSymbolizer", Type = typeof(TextSymbolizer), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public BaseSymbolizer[] Symbolizers
        {
            get { return m_Symbolizers; }
            set { m_Symbolizers = value; SymbolizersSpecified = true; }
        }

        
    }
}
