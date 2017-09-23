using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "LinePlacement", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class LinePlacement
    {

        [XmlIgnore]
        public bool PerpendicularOffsetSpecified;
        private double m_PerpendicularOffset;

        [XmlElement(ElementName = "PerpendicularOffset", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double PerpendicularOffset
        {
            get { return m_PerpendicularOffset; }
            set { m_PerpendicularOffset = value; PerpendicularOffsetSpecified = true; }
        }

        private int m_IsRepeated;

        [XmlElement(ElementName = "IsRepeated", DataType = "int", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public int IsRepeated
        {
            get { return m_IsRepeated; }
            set { m_IsRepeated = value; }
        }

        [XmlIgnore]
        public bool InitialGapSpecified;
        private double m_InitialGap;

        [XmlElement(ElementName = "InitialGap", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double InitialGap
        {
            get { return m_InitialGap; }
            set { m_InitialGap = value; InitialGapSpecified = true; }
        }

        [XmlIgnore]
        public bool GapSpecified;
        private double m_Gap;

        [XmlElement(ElementName = "Gap", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double Gap
        {
            get { return m_Gap; }
            set { m_Gap = value; GapSpecified = true; }
        }

        private int m_IsAligned;

        [XmlElement(ElementName = "IsAligned", DataType = "int", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public int IsAligned
        {
            get { return m_IsAligned; }
            set { m_IsAligned = value; }
        }

        private int m_GeneraliseLine;

        [XmlElement(ElementName = "GeneralizeLine", DataType = "int", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public int GeneraliseLine
        {
            get { return m_GeneraliseLine; }
            set { m_GeneraliseLine = value; }
        }
    }
}
