using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeospatialServices.Ogc.Wms;
using System.Runtime.Serialization;

namespace GeospatialServices.Ogc.Wms
{
    public class WmsFault : System.Exception
    {
        public WmsExceptionCode WmsExceptionCode {get; private set;}
        private string _Message;

        public WmsFault(WmsExceptionCode code, string message)
        {            
            WmsExceptionCode = code;
            _Message = message;
        }

        public override string Message
        {
            get
            {
                return _Message;
            }
        }
    }
}
