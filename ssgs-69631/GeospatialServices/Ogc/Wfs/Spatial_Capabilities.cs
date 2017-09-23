using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{
    [DataContract]
    [XmlType(TypeName = "Spatial_Capabilities", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Spatial_Capabilities
    {

        private GeometryOperands _GeometryOperands;

        [XmlElement(ElementName = "GeometryOperands", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(GeometryOperands))]
        [DataMember]
        public GeometryOperands GeometryOperands
        {
            get
            {
                if (_GeometryOperands == null)
                {
                    _GeometryOperands = new GeometryOperands();
                }
                return _GeometryOperands;
            }
            set { _GeometryOperands = value; }
        }


        private SpatialOperators _SpatialOperators;

        [XmlElement(ElementName = "SpatialOperators", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(SpatialOperators))]
        [DataMember]
        public SpatialOperators SpatialOperators
        {
            get
            {
                if (_SpatialOperators == null)
                {
                    _SpatialOperators = new SpatialOperators();
                }
                return _SpatialOperators;
            }
            set { _SpatialOperators = value; }
        }

    }
}
