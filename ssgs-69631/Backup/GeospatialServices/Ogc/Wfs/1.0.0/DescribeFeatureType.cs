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
    [XmlType(TypeName = "DescribeFeatureType", Namespace = Declarations.Wfs100NameSpace), Serializable]
    public partial class DescribeFeatureType
    {

        private SchemaDescriptionLanguage _SchemaDescriptionLanguage;

        [XmlElement(ElementName = "SchemaDescriptionLanguage", Type = typeof(SchemaDescriptionLanguage), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public SchemaDescriptionLanguage SchemaDescriptionLanguage
        {
            get
            {
                if (_SchemaDescriptionLanguage == null)
                {
                    _SchemaDescriptionLanguage = new SchemaDescriptionLanguage();
                }
                return _SchemaDescriptionLanguage;
            }
            set { _SchemaDescriptionLanguage = value; }
        }


        private List<DCPType> _DCPTypeList;

        [XmlElement(ElementName = "DCPType", Type = typeof(DCPType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public List<DCPType> DCPTypeList
        {
            get
            {
                if (_DCPTypeList == null)
                {
                    _DCPTypeList = new List<DCPType>();
                }
                return _DCPTypeList;
            }
            set { _DCPTypeList = value; }
        }


        

    }
}
