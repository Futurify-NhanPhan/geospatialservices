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
    [XmlType(TypeName = "FeatureTypeList", Namespace = Declarations.Wfs110NameSpace), Serializable]
    public partial class FeatureTypeList
    {
        public FeatureTypeList()
        {

        }

        [XmlIgnore]
        [DataMember]
        public bool OperationListSpecified;


        private List<OperationType> _OperationList;

        [XmlElement(ElementName = "Operation", Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public List<OperationType> OperationList
        {
            get
            {
                if (_OperationList == null)
                {
                    _OperationList = new List<OperationType>();
                    OperationListSpecified = true;
                }
                return _OperationList;
            }
            set { _OperationList = value; OperationListSpecified = true; }
        }


        private List<FeatureType> _FeatureTypesList;

        [XmlElement(ElementName = "FeatureType", Form = XmlSchemaForm.Unqualified, Type = typeof(FeatureType))]
        [DataMember]
        public List<FeatureType> FeatureTypesList
        {
            get
            {
                if (_FeatureTypesList == null)
                {
                    _FeatureTypesList = new List<FeatureType>();
                }
                return _FeatureTypesList;
            }
            set { _FeatureTypesList = value; }
        }





    }
}
