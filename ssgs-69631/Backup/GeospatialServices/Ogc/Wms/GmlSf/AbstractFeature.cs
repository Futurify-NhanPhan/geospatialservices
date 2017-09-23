using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlType(TypeName = "AbstractFeature", Namespace = Declarations.GmlNameSpace ), Serializable]
    [DataContract]
    public abstract partial class AbstractFeature : AbstractFeatureBase
    {

        [XmlIgnore]
        [DataMember] 
        public bool BoundedBySpecified;

        private BoundingShape _BoundedBy;

        [XmlElement(ElementName = "boundedBy", Type = typeof(BoundingShape), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember]
        public BoundingShape BoundedBy
        {
            get { return _BoundedBy; }
            set {_BoundedBy = value; BoundedBySpecified = true; }
        }

    }

}
