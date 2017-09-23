using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Displacement", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class Displacement
    {
        [XmlIgnore]
        public bool DisplacementXSpecified;
        private double m_DisplacementX;

        [XmlElement(ElementName = "DisplacementX", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double DisplacementX
        {
            get{return m_DisplacementX;}
            set { m_DisplacementX = value; DisplacementXSpecified = true; }
        }

        [XmlIgnore]
        public bool DisplacementYSpecified;
        private double m_DisplacementY;

        [XmlElement(ElementName = "DisplacementY", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public double DisplacementY
        {
            get{return m_DisplacementY;}
            set { m_DisplacementY = value; DisplacementYSpecified = true; }
        }
    }
}
