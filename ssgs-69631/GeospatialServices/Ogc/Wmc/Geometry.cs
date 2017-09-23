using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Geometry", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Geometry
    {
        private string m_PropertyName;

        [XmlElement(ElementName = "PropertyName", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        public string PropertyName
        {
            get { return m_PropertyName; }
            set { m_PropertyName = value; }
        }
    }
}
