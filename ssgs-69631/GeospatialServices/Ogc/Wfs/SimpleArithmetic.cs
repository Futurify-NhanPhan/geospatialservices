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
    [XmlType(TypeName = "SimpleArithmetic", Namespace = Declarations.Wfs110DefaultNameSpace), Serializable]
    public partial class SimpleArithmetic
    {
    }

}
