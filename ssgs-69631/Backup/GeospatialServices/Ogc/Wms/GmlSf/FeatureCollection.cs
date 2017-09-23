using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlRootAttribute(ElementName = "FeatureCollection", Namespace=Declarations.DefaultNameSpace )]   
    [XmlType(TypeName = "FeatureCollection", Namespace = Declarations.DefaultNameSpace ), Serializable]
    [DataContract]
    public partial class FeatureCollection : AbstractFeature 
    {
        [XmlIgnore]
        [DataMember] 
        public bool FeatureMemberListSpecified;

        private List<Feature> _FeatureMemberList;

        [XmlElement(ElementName = "featureMember", Type = typeof(Feature), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace= Declarations.DefaultNameSpace)]
        [DataMember] 
        public List<Feature> FeatureMemberList
        {
            get 
            {
                if (_FeatureMemberList == null)
                {
                    _FeatureMemberList = new List<Feature>();
                    FeatureMemberListSpecified = true;
                }
                return _FeatureMemberList; 
            }
            set { _FeatureMemberList = value; FeatureMemberListSpecified = true; }
        }



    }
}
