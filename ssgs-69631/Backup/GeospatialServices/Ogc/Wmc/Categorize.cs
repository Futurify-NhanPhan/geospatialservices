using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Categorize", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class Categorize
    {
        private string m_FallBackValue;

        [XmlAttribute(AttributeName = "fallbackValue", DataType = "string")]
        public string FallBackValue
        {
            get { return m_FallBackValue; }
            set { m_FallBackValue = value; }
        }

        private string m_ThresholdsBelongTo;

        [XmlAttribute(AttributeName = "thresholdsBelongTo", DataType = "string")]
        public string ThresholdsBelongTo
        {
            get { return m_ThresholdsBelongTo; }
            set { m_ThresholdsBelongTo = value; }
        }
        

        private string m_LookupValue;

        [XmlElement(ElementName = "LookupValue", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public string LookupValue
        {
            get {return m_LookupValue;}
            set { m_LookupValue = value; }
        }

        
        [XmlIgnore]
        public bool ThresholdsSpecified;
        private List<double> m_Thresholds;
        [XmlElement(Type = typeof(double), ElementName = "Threshold", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<double> Thresholds
        {
            get
            {
                if (m_Thresholds == null)
                {
                    m_Thresholds = new List<double>();
                    ThresholdsSpecified = true;
                }
                return m_Thresholds;
            }
            set { m_Thresholds = value; ThresholdsSpecified = true; }
        }

        [XmlIgnore]
        public bool ValuesSpecified;
        private List<string> m_Values;
        [XmlElement(Type = typeof(string), ElementName = "Value", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<string> Values
        {
            get
            {
                if (m_Values == null)
                {
                    m_Values = new List<string>();
                    ValuesSpecified = true;
                }
                return m_Values;
            }
            set { m_Values = value; ValuesSpecified = true; }
        }



    }
}
