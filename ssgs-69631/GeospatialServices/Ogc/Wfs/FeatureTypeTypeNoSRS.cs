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
    [XmlType(TypeName = "FeatureTypeNoSRS", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class FeatureTypeTypeNoSRS
    {

    }
}
