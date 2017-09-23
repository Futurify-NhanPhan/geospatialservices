using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Font", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class Font
    {
        [XmlIgnore]
        public bool SvgParametersSpecified;
        private List<SvgParameter> m_SvgParameters;

        [XmlElement(Type = typeof(SvgParameter), ElementName = "SvgParameter", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public List<SvgParameter> SvgParameters
        {
            get
            {
                if (m_SvgParameters == null)
                {
                    m_SvgParameters = new List<SvgParameter>();
                    SvgParametersSpecified = true;

                }
                return m_SvgParameters;
            }
            set { m_SvgParameters = value; SvgParametersSpecified = true; }
        }
    }
}
