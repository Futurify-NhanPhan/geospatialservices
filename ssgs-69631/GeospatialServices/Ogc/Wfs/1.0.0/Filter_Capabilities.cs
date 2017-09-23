using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "Filter_Capabilities", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Filter_Capabilities
    {

        private Spatial_Capabilities _Spatial_Capabilities;

        [XmlElement(ElementName = "Spatial_Capabilities", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(Spatial_Capabilities))]
        [DataMember]
        public Spatial_Capabilities Spatial_Capabilities
        {
            get
            {
                if (_Spatial_Capabilities == null)
                {
                    _Spatial_Capabilities = new Spatial_Capabilities();
                }
                return _Spatial_Capabilities;
            }
            set { _Spatial_Capabilities = value; }
        }

        private Scalar_Capabilities _Scalar_Capabilities;

        [XmlElement(ElementName = "Scalar_Capabilities", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(Scalar_Capabilities))]
        [DataMember]
        public Scalar_Capabilities Scalar_Capabilities
        {
            get
            {
                if (_Scalar_Capabilities == null)
                {
                    _Scalar_Capabilities = new Scalar_Capabilities();
                }
                return _Scalar_Capabilities;
            }
            set { _Scalar_Capabilities = value; }
        }


    }
}
