using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Interpolate", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class Interpolate
    {
        private string m_FallBackValue;

        [XmlAttribute(AttributeName = "fallbackValue", DataType = "string")]
        public string FallBackValue
        {
            get { return m_FallBackValue; }
            set { m_FallBackValue = value; }
        }

        private string m_Mode;

        [XmlAttribute(AttributeName = "mode", DataType = "string")]
        public string Mode
        {
            get { return m_Mode; }
            set { m_Mode = value; }
        }

        private string m_Method;

        [XmlAttribute(AttributeName = "method", DataType = "string")]
        public string Method
        {
            get { return m_Method; }
            set { m_Method = value; }
        }


        private string m_LookupValue;

        [XmlElement(ElementName = "LookupValue", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public string LookupValue
        {
            get{return m_LookupValue;}
            set { m_LookupValue = value; }
        }

        [XmlIgnore]
        public bool InterpolationPointsSpecified;
        private List<InterpolationPoint> m_InterpolationPoints;
        [XmlElement(Type = typeof(InterpolationPoint), ElementName = "InterpolationPoint", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<InterpolationPoint> InterpolationPoints
        {
            get
            {
                if (m_InterpolationPoints == null)
                {
                    m_InterpolationPoints = new List<InterpolationPoint>();
                    InterpolationPointsSpecified = true;
                }
                return m_InterpolationPoints;
            }
            set { m_InterpolationPoints = value; InterpolationPointsSpecified = true; }
        }

    }
}
