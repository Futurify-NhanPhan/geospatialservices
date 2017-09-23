using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "NamedStyle", Namespace = Declarations.SldNameSpace), Serializable]
    public partial class NamedStyle
    {

        public NamedStyle()
        {
        }

        public NamedStyle(string name)
        {
            m_Name = name;
        }

        private string m_Name;

        [XmlElement(ElementName = "Name", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "string", Namespace = Declarations.SldNameSpace)]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        [XmlIgnore]
        public bool DescriptionSpecified; 
        private Description m_Description;
        
        [XmlElement(Type = typeof(Description), ElementName = "Description", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public Description Description
        {
            get 
            {
                if (m_Description == null)
                {
                    m_Description = new Description();
                    DescriptionSpecified = true;
                }

                return m_Description; 
            }
            set { m_Description = value; DescriptionSpecified = true; }
        }
    }
}
