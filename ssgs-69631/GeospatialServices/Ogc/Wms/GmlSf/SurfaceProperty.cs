using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlType(TypeName = "SurfaceProperty", Namespace = Declarations.GmlNameSpace), Serializable]
    [DataContract]
    public partial class SurfaceProperty
    {
        public SurfaceProperty()
        {
        }
        public SurfaceProperty(AbstractSurface item)
        {
            _Item = item;
        }

        private AbstractSurface _Item;

        [XmlElement("Polygon", typeof(Polygon))]
        [XmlElement("Surface", typeof(Surface))]
        public AbstractSurface Item
        {
            get { return _Item; }
            set { _Item = value; }
        }
    }

}
