using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "InterpolationPoint", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class InterpolationPoint
    {

        public InterpolationPoint()
        {
        }

        public InterpolationPoint(double data, string value)
        {
            m_Data = data;
            m_Value = value;
            ValueSpecified = true;
        }
        
        private double m_Data;

        [XmlElement(ElementName = "Data", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double Data
        {
            get { return m_Data; }
            set { m_Data = value; }
        }

        [XmlIgnore]
        public bool ValueSpecified;
        private string m_Value;

        [XmlElement(ElementName = "Value", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public string Value
        {
            get {return m_Value;}
            set { m_Value = value; ValueSpecified = true; }
        }

    }
}
