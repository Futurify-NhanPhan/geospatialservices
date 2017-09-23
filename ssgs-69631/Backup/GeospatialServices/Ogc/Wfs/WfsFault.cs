using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GeospatialServices.Ogc.Wfs
{
    [DataContract]
    public class WfsFault : SystemException
    {
        [DataMember]
        public WfsExceptionCode WfsExceptionCode { get; private set; }
        
        public WfsFault(WfsExceptionCode code)
        {
            WfsExceptionCode = code;
        }
        
    }
}
