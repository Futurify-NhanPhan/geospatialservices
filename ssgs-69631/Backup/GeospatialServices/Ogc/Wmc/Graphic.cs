using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Graphic", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class Graphic

    {
        [XmlIgnore]
        public bool OpacitySpecified;
        private double m_Opacity;

        [XmlElement(ElementName = "Opacity", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double Opacity
        {
            get {return m_Opacity;}
            set { m_Opacity = value; OpacitySpecified = true; }
        }

        [XmlIgnore]
        public bool ExternalGraphicsSpecified;
        private List<ExternalGraphic> m_ExternalGraphics;

        [XmlElement(Type = typeof(ExternalGraphic), ElementName = "ExternalGraphic", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<ExternalGraphic> ExternalGraphics
        {
            get
            {
                if (m_ExternalGraphics == null)
                {
                    m_ExternalGraphics = new List<ExternalGraphic>();
                    ExternalGraphicsSpecified = true;
                }
                return m_ExternalGraphics;
            }
            set { m_ExternalGraphics = value; ExternalGraphicsSpecified = true; }
        }

        [XmlIgnore]
        public bool MarksSpecified;
        private List<Mark> m_Marks;
        
        [XmlElement(Type = typeof(Mark), ElementName = "Mark", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<Mark> Marks
        {
            get
            {
                if (m_Marks == null)
                {
                    m_Marks = new List<Mark>();
                    MarksSpecified = true;
                }
                return m_Marks;
            }
            set { m_Marks = value; MarksSpecified = true; }
        }
        [XmlIgnore]
        public bool SizeSpecified;
        private double m_Size;

        [XmlElement(ElementName = "Size", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double Size
        {
            get { return m_Size;  }
            set { m_Size = value; SizeSpecified = true; }
        }

        [XmlIgnore]
        public bool RotationSpecified;
        private double m_Rotation;
        
        [XmlElement(ElementName = "Rotation", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double Rotation
        {
            get{return m_Rotation;}
            set { m_Rotation = value; RotationSpecified = true; }
        }


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

            set { m_AnchorPoint = value; AnchorPointSpecified = true; }
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
                return m_Displacement; }
            set { m_Displacement = value; DisplacementSpecified = true; }
        }
    }
}
