using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "FeatureTypeConstraint", Namespace = Declarations.SldNameSpace), Serializable]
    public partial class FeatureTypeConstraint
    {
        private string m_FeatureTypeName;

        [XmlElement(ElementName = "FeatureTypeName", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "string", Namespace = Declarations.SldNameSpace)]
        public string FeatureTypeName
        {
            get { return m_FeatureTypeName; }
            set { m_FeatureTypeName = value; }
        }

        [XmlIgnore]
        public bool FilterSpecified;
        private Filter m_Filter;

        [XmlElement(ElementName = "Filter", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public Filter Filter
        {
            get
            {
                if (m_Filter == null)
                {
                    m_Filter = new Filter();
                    FilterSpecified = true;
 
                }
                return m_Filter;
            }
            set { m_Filter = value; FilterSpecified = true; }
        }

        [XmlIgnore] 
        public bool ExtentSpecified;
        private List<Extent> m_Extent;

        [XmlElement(ElementName = "Extent", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public List<Extent> Extent
        {
            get 
            {
                if (m_Extent == null)
                {
                    m_Extent = new List<Extent>();
                    ExtentSpecified = true;
                }
                
                return m_Extent; 
            }
            set { m_Extent = value; ExtentSpecified = true;}
        }
    }
}
