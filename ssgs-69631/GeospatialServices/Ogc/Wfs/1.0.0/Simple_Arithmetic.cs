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
    [XmlType(TypeName = "Simple_Arithmetic", Namespace = Declarations.Wfs100DefaultNameSpace), Serializable]
    public partial class Simple_Arithmetic
    {
    }

}
