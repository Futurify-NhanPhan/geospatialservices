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
    [XmlType(TypeName = "ResultFormat", Namespace = Declarations.Wfs100DefaultNameSpace), Serializable]
    public partial class ResultFormat
    {

        private List<EmptyType> _GML2List;

        [XmlElement(ElementName = "GML2", Type = typeof(EmptyType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public List<EmptyType> GML2List
        {
            get
            {
                if (_GML2List == null)
                {
                    _GML2List = new List<EmptyType>();
                }
                return _GML2List;
            }
            set { _GML2List = value; }
        }

    }
}
