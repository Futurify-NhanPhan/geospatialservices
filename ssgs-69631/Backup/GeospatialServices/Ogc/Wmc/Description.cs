using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Description", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class Description
    {
        public Description()
        {

        }

        public Description(string title, string abstractForDescription)
        {
            m_Title = title;
            m_Abstract = abstractForDescription; 
        }

        private string m_Title;

        [XmlElement(ElementName = "Title", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }
        
        private string m_Abstract;

        [XmlElement(ElementName = "Abstract", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string Abstract
        {
            get { return m_Abstract; }
            set { m_Abstract = value; }
        }
    }
}
