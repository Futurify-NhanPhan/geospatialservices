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
    [XmlType(TypeName = "MultiSurface", Namespace = Declarations.GmlNameSpace), Serializable]
    public partial class MultiSurface : AbstractGeometricAggregate
    {

        [XmlIgnore]
        [DataMember]
        public bool SurfaceMemberListSpecified;

        private List<SurfaceProperty> _SurfaceMemberList;

        [XmlElement(ElementName = "surfaceMember", Type = typeof(SurfaceProperty), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember]
        public List<SurfaceProperty> SurfaceMemberList
        {
            get
            {
                if (_SurfaceMemberList == null)
                {
                    _SurfaceMemberList = new List<SurfaceProperty>();
                    SurfaceMemberListSpecified = true;
                }
                return _SurfaceMemberList;
            }
            set { _SurfaceMemberList = value; SurfaceMemberListSpecified = true; }
        }
    }
}
