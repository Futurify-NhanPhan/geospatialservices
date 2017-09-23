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
    [XmlType(TypeName = "PolygonPatch", Namespace = Declarations.GmlNameSpace), Serializable]
    public partial class PolygonPatch : AbstractSurfacePatch
    {

        public PolygonPatch()
        {
            _Interpolation = SurfaceInterpolationType.planar;

        }

        private AbstractRingProperty _Exterior;

        [DataMember]
        [XmlElement(ElementName = "exterior", Type = typeof(AbstractRingProperty), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        public AbstractRingProperty Exterior
        {
            get { return _Exterior; }
            set { _Exterior = value; }
        }

        private List<AbstractRingProperty> _InteriorList;

        [XmlElement(ElementName = "interior", Type = typeof(AbstractRingProperty), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember]
        public List<AbstractRingProperty> InteriorList
        {
            get 
            {
                if (_InteriorList == null)
                {
                    _InteriorList = new List<AbstractRingProperty>();  
                }
                return _InteriorList; 
            }
            set { _InteriorList = value; }
        }

        [XmlIgnore]
        [DataMember] 
        public bool InterpolationSpecified;

        private SurfaceInterpolationType _Interpolation;

        [XmlAttribute(AttributeName = "interpolation")]
        public SurfaceInterpolationType Interpolation
        {
            get { return _Interpolation; }
            set { _Interpolation = value; }
        }
    }
}
