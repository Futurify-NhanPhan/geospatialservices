using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "AnchorPoint", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class AnchorPoint
    {
        public AnchorPoint()
        {
        }

        public AnchorPoint(double x, double y)
        {
            m_AnchorPointX = x;
            m_AnchorPointY = y;
        }

        [XmlIgnore]
        public bool AnchorPointXSpecified;
        private double m_AnchorPointX;

        [XmlElement(ElementName = "AnchorPointX", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double AnchorPointX
        {
            get{return m_AnchorPointX;}
            set { m_AnchorPointX = value; AnchorPointXSpecified = true; }
        }

        [XmlIgnore]
        public bool AnchorPointYSpecified;
        private double m_AnchorPointY;

        [XmlElement(ElementName = "AnchorPointY", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double AnchorPointY
        {
            get{return m_AnchorPointY;}
            set { m_AnchorPointY = value; AnchorPointYSpecified = true; }
        }
    }
}
