using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "PointPlacement", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class PointPlacement
    {
        [XmlIgnore]
        public bool AnchorPointSpecified;
        private AnchorPoint m_AnchorPoint;

        [XmlElement(Type = typeof(AnchorPoint), ElementName = "AnchorPoint", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public AnchorPoint AnchorPoint
        {
            get
            {
                if (m_AnchorPoint == null)
                {
                    m_AnchorPoint = new AnchorPoint();
                    AnchorPointSpecified = true;
                }
                return m_AnchorPoint;
            }

            set { m_AnchorPoint = value; AnchorPointSpecified = true;  }
        }

        [XmlIgnore]
        public bool DisplacementSpecified;
        private Displacement m_Displacement;

        [XmlElement(Type = typeof(Displacement), ElementName = "Displacement", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Displacement Displacement
        {
            get
            {
                if (m_Displacement == null)
                {
                    m_Displacement = new Displacement();
                    DisplacementSpecified = true;
                }
                return m_Displacement;
            }
            set { m_Displacement = value; DisplacementSpecified = true; }
        }

        [XmlIgnore]
        public bool RotationSpecified;
        private double m_Rotation;

        [XmlElement(ElementName = "Rotation", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double Rotation
        {
            get {return m_Rotation; }
            set { m_Rotation = value; RotationSpecified = true; }
        }

        

    }
}
