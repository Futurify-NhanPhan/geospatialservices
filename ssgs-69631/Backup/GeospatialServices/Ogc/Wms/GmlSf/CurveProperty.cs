using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlType(TypeName = "CurveProperty", Namespace = Declarations.GmlNameSpace  ), Serializable]
    [DataContract]
    public partial class CurveProperty 
    {

        public CurveProperty()
        {
        }
        public CurveProperty(AbstractCurve item)
        {
            _Item = item;
        }
        private AbstractCurve _Item;

        [XmlElement("Curve", typeof(Curve))]
        [XmlElement("LineString", typeof(LineString))]
        public AbstractCurve Item
        {
            get {return _Item;}
            set {_Item = value;}
        }
    }

}
