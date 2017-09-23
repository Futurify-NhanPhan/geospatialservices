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
    [XmlType(TypeName = "MultiPoint", Namespace = Declarations.GmlNameSpace), Serializable]
    public partial class MultiPoint : AbstractGeometricAggregate
    {

        [XmlIgnore]
        [DataMember] 
        public bool PointMemberListSpecified;

        private List<PointProperty> _PointMemberList;

        [XmlElement(ElementName = "pointMember", Type = typeof(PointProperty), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember]
        public List<PointProperty> PointMemberList
        {
            get
            {
                if (_PointMemberList == null)
                {
                    _PointMemberList = new List<PointProperty>();
                    PointMemberListSpecified = true;
                }
                return _PointMemberList;
            }
            set { _PointMemberList = value; PointMemberListSpecified = true; }
        }
    }
}
