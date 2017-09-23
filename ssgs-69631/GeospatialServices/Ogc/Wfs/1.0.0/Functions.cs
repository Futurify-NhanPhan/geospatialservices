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
    [XmlType(TypeName = "Functions", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Functions
    {

        private FunctionNames _FunctionNames;

        [XmlElement(ElementName = "FunctionNames", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(FunctionNames))]
        [DataMember]
        public FunctionNames FunctionNames
        {
            get
            {
                if (_FunctionNames == null)
                {
                    _FunctionNames = new FunctionNames();
                }
                return _FunctionNames;
            }
            set { _FunctionNames = value; }
        }

    }
}
