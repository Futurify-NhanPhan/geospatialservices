using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [DataContract]
    [XmlType(TypeName = "MultiGeometry", Namespace = Declarations.GmlNameSpace), Serializable]
    public partial class MultiGeometry : AbstractGeometricAggregate
    {

        [XmlIgnore]
        [DataMember]
        public bool MultiGeometryMemberListSpecified;

        private List<MultiGeometryProperty> _MultiGeometryMemberList;

        [XmlElement(ElementName = "geometryMember", Type = typeof(MultiGeometryProperty), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember]
        public List<MultiGeometryProperty> MultiGeometryMemberList
        {
            get
            {
                if (_MultiGeometryMemberList == null)
                {
                    _MultiGeometryMemberList = new List<MultiGeometryProperty>();
                    MultiGeometryMemberListSpecified = true;
                }
                return _MultiGeometryMemberList;
            }
            set { _MultiGeometryMemberList = value; MultiGeometryMemberListSpecified = true; }
        }
    }
}
