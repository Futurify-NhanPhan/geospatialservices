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
    [XmlType(TypeName = "LineString", Namespace = Declarations.GmlNameSpace ), Serializable]
    public partial class LineString : AbstractCurve
    {

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
