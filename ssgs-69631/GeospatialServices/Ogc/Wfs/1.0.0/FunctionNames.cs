using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "FunctionNames", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class FunctionNames
    {

        private List<FunctionName> _FunctionNameList;

        [XmlElement(ElementName = "FunctionName", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(FunctionName))]
        [DataMember]
        public List<FunctionName> FunctionNameList
        {
            get
            {
                if (_FunctionNameList == null)
                {
                    _FunctionNameList = new List<FunctionName>();
                }
                return _FunctionNameList;
            }
            set { _FunctionNameList = value; }
        }

    }
}
