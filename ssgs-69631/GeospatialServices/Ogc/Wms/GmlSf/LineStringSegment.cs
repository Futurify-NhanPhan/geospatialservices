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
    [XmlType(TypeName = "LineStringSegment", Namespace = Declarations.GmlNameSpace  ), Serializable]
    public partial class LineStringSegment : AbstractCurveSegment
    {
        [XmlIgnore]
        [DataMember]
        public bool InterPolationSpecified;

        private CurveInterpolationType _Interpolation;

        [XmlAttribute(AttributeName = "interpolation", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public CurveInterpolationType Interpolation
        {
            get { return _Interpolation; }
            set { _Interpolation = value; InterPolationSpecified = true; }
        }


        private DirectPositionList _PosList;

        [XmlElement(ElementName = "posList", Type = typeof(DirectPositionList), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember]
        public DirectPositionList PosList
        {
            get
            {
                if (_PosList == null)
                {
                    _PosList = new DirectPositionList();
                }
                return _PosList;
            }
            set { _PosList = value; }
        }
    }
}
