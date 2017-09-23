using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "LabelPlacement", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class LabelPlacement
    {
        [XmlIgnore]
        public bool PointPlacementSpecified;
        private PointPlacement m_PointPlacement;

        [XmlElement(Type = typeof(PointPlacement), ElementName = "PointPlacement", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public PointPlacement PointPlacement
        {
            get { return m_PointPlacement; }
            set { m_PointPlacement = value; PointPlacementSpecified = true; }
        }

        [XmlIgnore]
        public bool LinePlacementSpecified;
        private LinePlacement m_LinePlacement;

        [XmlElement(Type = typeof(LinePlacement), ElementName = "LinePlacement", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public LinePlacement LinePlacement
        {
            get { return m_LinePlacement; }
            set { m_LinePlacement = value; LinePlacementSpecified = true; }
        }
    }
}
