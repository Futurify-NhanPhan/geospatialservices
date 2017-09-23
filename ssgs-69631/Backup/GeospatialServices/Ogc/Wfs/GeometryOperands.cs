using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{
    [DataContract]
    [XmlType(TypeName = "GeometryOperands", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class GeometryOperands
    {

        private List<XmlQualifiedName> _GeometryOperandList;

        [XmlElement(ElementName = "GeometryOperand", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(XmlQualifiedName))]
        [DataMember]
        public List<XmlQualifiedName> GeometryOperandList
        {
            get
            {
                if (_GeometryOperandList == null)
                {
                    _GeometryOperandList = new List<XmlQualifiedName>();
                }
                return _GeometryOperandList;
            }
            set { _GeometryOperandList = value; }
        }

    }
}
