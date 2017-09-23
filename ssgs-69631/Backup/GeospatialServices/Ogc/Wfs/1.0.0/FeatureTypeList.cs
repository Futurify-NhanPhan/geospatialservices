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
    [XmlType(TypeName = "FeatureTypeList", Namespace = Declarations.Wfs110DefaultNameSpace), Serializable]
    public partial class FeatureTypeList
    {

        [XmlIgnore]
        [DataMember]
        private bool OperationsSpecified = false;

        private Operations _Operations;

        [XmlElement(Type = typeof(Operations), ElementName = "Operations", IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        [DataMember]
        public Operations Operations
        {
            get 
            { 
                if (_Operations == null)
                {
                    _Operations = new Operations(); 
                    OperationsSpecified = true;
                }
                return _Operations; 
            }
            set { _Operations = value; OperationsSpecified = true;}
        }



        private List<FeatureType> _FeatureTypesList;

        [XmlElement(Type = typeof(FeatureType), ElementName = "FeatureType", IsNullable = false, Form = XmlSchemaForm.Unqualified)]
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
