using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "SchemaDescriptionLanguage", Namespace = Declarations.Wfs100NameSpace), Serializable]
    public partial class SchemaDescriptionLanguage
    {
        
        private List<EmptyType> _XMLSCHEMAList;

        [XmlElement(ElementName = "XMLSCHEMA", Type = typeof(EmptyType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public List<EmptyType> XMLSCHEMAList
        {
            get
            {
                if (_XMLSCHEMAList == null)
                {
                    _XMLSCHEMAList = new List<EmptyType>();
                }
                return _XMLSCHEMAList;
            }
            set { _XMLSCHEMAList = value; }
        }

    }
}
