using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Extent", Namespace = Declarations.SldNameSpace), Serializable]
    public partial class Extent
    {
        
        private string m_Name;
        [XmlElement(ElementName = "Name", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private string m_Value;
        [XmlElement(ElementName = "Value", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SldNameSpace)]
        public string Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

    }
}
