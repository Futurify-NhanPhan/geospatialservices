using System;
using System.Collections.Generic;
using System.Text;
using System.Xml; 
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Extension", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class Extension
    {
        
		[XmlAnyElement()]
        private XmlElement m_Any;

        public XmlElement Any
        {
            get { return m_Any; }
            set { m_Any = value; }
        }

    }
}
