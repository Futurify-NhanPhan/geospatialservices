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
    [XmlType(TypeName = "Spatial_Capabilities", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Spatial_Capabilities
    {

        private Spatial_Operators _Spatial_Operators;

        [XmlElement(ElementName = "Spatial_Operators", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(Spatial_Operators))]
        [DataMember]
        public Spatial_Operators Spatial_Operators
        {
            get
            {
                if (_Spatial_Operators == null)
                {
                    _Spatial_Operators = new Spatial_Operators();
                }
                return _Spatial_Operators;
            }
            set { _Spatial_Operators = value; }
        }

    }
}
