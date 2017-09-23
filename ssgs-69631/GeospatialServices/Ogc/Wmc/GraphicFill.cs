using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "GraphicFill", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class GraphicFill
    {

        [XmlIgnore]
        public bool GraphicSpecified;
        private Graphic m_Graphic;

        [XmlElement(Type = typeof(Graphic), ElementName = "Graphic", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public Graphic Graphic
        {
            get
            {
                if (m_Graphic == null)
                {
                    m_Graphic = new Graphic();
                    GraphicSpecified = true;
                }

                return m_Graphic;
            }
            set { m_Graphic = value; GraphicSpecified = true; }
        }

     
    }
}
