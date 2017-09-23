using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlType(TypeName = "Polygon", Namespace = Declarations.GmlNameSpace), Serializable]
    [DataContract]
    public partial class Polygon : AbstractSurface
    {
        [XmlIgnore]
        [DataMember]
        public bool ExteriorSpecified;

        private AbstractRingProperty _Exterior;

        [XmlElement(ElementName = "exterior", Type = typeof(AbstractRingProperty), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        public AbstractRingProperty Exterior
        {
            get { return _Exterior; }
            set { _Exterior = value; ExteriorSpecified = true; }
        }

        [XmlIgnore]
        [DataMember]
        public bool InteriorListSpecified;

        private List<AbstractRingProperty> _InteriorList;

        [XmlElement(ElementName = "interior", Type = typeof(AbstractRingProperty), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        public List<AbstractRingProperty> InteriorList
        {
            get { return _InteriorList; }
            set { _InteriorList = value; InteriorListSpecified = true; }
        }

        
    }

}
