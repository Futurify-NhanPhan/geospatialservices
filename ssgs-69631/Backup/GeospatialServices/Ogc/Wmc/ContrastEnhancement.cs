using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "ContrastEnhancement", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class ContrastEnhancement
    {
        [XmlIgnore] 
        public bool NormalizeSpecified;
        private XmlElement m_Normalize;

        [XmlAnyElement(Name = "Normalize", Namespace = Declarations.SeNameSpace)]
        public XmlElement Normalize
        {
            get { return m_Normalize; }
            set { m_Normalize = value; NormalizeSpecified = true; }
        }

        [XmlIgnore]
        public bool HistorgramSpecified;
        private XmlElement m_Histogram;

        [XmlAnyElement(Name="Histogram", Namespace = Declarations.SeNameSpace)]
        public XmlElement Histogram
        {
            get { return m_Histogram; }
            set { m_Histogram = value; }
        }

        [XmlIgnore]
        public bool GammaValueSpecified;
        private double m_GammaValue;
        [XmlElement(ElementName = "GammaValue", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double GammaValue
        {
            get { return m_GammaValue; }
            set { m_GammaValue = value; GammaValueSpecified = true; }
        }
    }
}
