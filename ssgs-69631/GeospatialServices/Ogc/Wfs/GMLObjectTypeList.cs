using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{
    [DataContract]
    [XmlType(TypeName = "GMLObjectTypeList", Namespace = Declarations.Wfs110NameSpace), Serializable]
    public partial class GMLObjectTypeList
    {

        private List<GMLObjectType>  _GMLObjectTypesList;

        [XmlElement(ElementName = "GMLObjectType", Form = XmlSchemaForm.Unqualified, Type = typeof(GMLObjectType))]
        [DataMember]
        public List<GMLObjectType> GMLObjectTypesList
        {
            get
            {
                if (_GMLObjectTypesList == null)
                {
                    _GMLObjectTypesList = new List<GMLObjectType>() ;
                }
                return _GMLObjectTypesList;
            }
            set { _GMLObjectTypesList = value; }
        }

    }
}
