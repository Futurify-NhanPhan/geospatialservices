using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlInclude(typeof(Polygon))]
    [XmlInclude(typeof(Surface))]
    [XmlType(TypeName = "AbstractSurface", Namespace = Declarations.GmlNameSpace  ), Serializable]
    [DataContract]
    public abstract partial class AbstractSurface : AbstractGeometricPrimitive
    {

    }

}
