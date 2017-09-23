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
    [XmlType(TypeName = "MultiCurve", Namespace = Declarations.GmlNameSpace ), Serializable]
    public partial class MultiCurve : AbstractGeometricAggregate
    {

        private List<CurveProperty> _CurveMemberList;

        [XmlElement(ElementName = "curveMember", Type = typeof(CurveProperty), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember]
        public List<CurveProperty> CurveMemberList
        {
            get
            {
                if (_CurveMemberList == null)
                {
                    _CurveMemberList = new List<CurveProperty>();
                }
                return _CurveMemberList;
            }
            set { _CurveMemberList = value; }
        }
    }
}
