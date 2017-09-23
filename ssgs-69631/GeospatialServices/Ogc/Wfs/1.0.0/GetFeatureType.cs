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
    [XmlType(TypeName = "GetFeatureType", Namespace = Declarations.Wfs100NameSpace), Serializable]
    public partial class GetFeatureType
    {
        private ResultFormat _ResultFormat;

        [XmlElement(ElementName = "ResultFormat", Type = typeof(ResultFormat), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public ResultFormat ResultFormat
        {
            get
            {
                if (_ResultFormat == null)
                {
                    _ResultFormat = new ResultFormat();
                }
                return _ResultFormat;
            }
            set { _ResultFormat = value; }
        }


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
