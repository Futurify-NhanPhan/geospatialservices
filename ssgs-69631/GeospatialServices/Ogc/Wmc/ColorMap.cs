using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "ColorMap", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class ColorMap
    {
        [XmlIgnore]
        public bool CategorizeSpecified;
        private Categorize m_Categorize;

        [XmlElement(Type = typeof(Categorize), ElementName = "Categorize", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Categorize Categorize
        {
            get
            {
                if (m_Categorize == null)
                {
                    m_Categorize = new Categorize ();
                    CategorizeSpecified = true;
                }
                return m_Categorize;
            }
            set { m_Categorize = value; CategorizeSpecified = true; }
        }

        [XmlIgnore]
        public bool InterpolateSpecified;
        private Interpolate m_Interpolate;

        [XmlElement(Type = typeof(Interpolate), ElementName = "Interpolate", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Interpolate Interpolate
        {
            get
            {
                if (m_Interpolate == null)
                {
                    m_Interpolate = new Interpolate();
                    InterpolateSpecified = true;
                }
                return m_Interpolate;
            }
            set { m_Interpolate = value; InterpolateSpecified = true; }
        }

        
    }
}
