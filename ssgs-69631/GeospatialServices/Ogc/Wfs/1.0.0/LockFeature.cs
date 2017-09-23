using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "LockFeatureType", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class LockFeatureType
    {

        private List<DCPType> _DCPTypeList;

        [XmlElement(Type = typeof(DCPType), ElementName = "DCPType", IsNullable = false, Form = XmlSchemaForm.Unqualified)]
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
