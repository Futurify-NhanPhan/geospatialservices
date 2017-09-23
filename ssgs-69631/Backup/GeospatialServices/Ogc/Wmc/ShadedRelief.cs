using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "ShadedRelief", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class ShadedRelief
    {
        private bool m_BrightnessOnly;

        [XmlElement(ElementName = "BrightnessOnly", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public bool BrightnessOnly
        {
            get { return m_BrightnessOnly; }
            set { m_BrightnessOnly = value; }
        }
        private double m_ReliefFactor;

        [XmlElement(ElementName = "ReliefFactor", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double ReliefFactor
        {
            get { return m_ReliefFactor; }
            set { m_ReliefFactor = value; }
        }
    }
}
