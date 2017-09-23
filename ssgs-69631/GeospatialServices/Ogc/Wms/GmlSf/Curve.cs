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
    [XmlType(TypeName = "Curve", Namespace = Declarations.GmlNameSpace), Serializable]
    public partial class Curve : AbstractCurve
    {

        private List<AbstractCurveSegment> _Segments;

        /// <remarks/>
        [XmlElement(ElementName = "_CurveSegment", Type = typeof(AbstractCurveSegment), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        public List<AbstractCurveSegment> segments
        {
            get 
            {
                if (_Segments == null)
                {
                    _Segments = new List<AbstractCurveSegment>();
                }
                return _Segments;
            }
            set { _Segments = value; }
        }
    }
}
