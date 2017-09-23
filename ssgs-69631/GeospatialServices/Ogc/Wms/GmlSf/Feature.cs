using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlType(TypeName = "Feature", Namespace = Declarations.GmlNameSpace), Serializable]
    [DataContract]
    public partial class Feature : AbstractFeature
    {

        [XmlIgnore]
        [DataMember]
        public bool ElementListSpecified;

        private List<XmlElement> _ElementList;

        [XmlAnyElement()] 
        [DataMember]
        public List<XmlElement> ElementList
        {
            get
            {
                if (_ElementList == null)
                {
                    _ElementList = new List<XmlElement>();
                    ElementListSpecified = true;
                }

                return _ElementList;
            }
            set
            {
                _ElementList = value; ElementListSpecified = true;
            }
        }

    }

}
