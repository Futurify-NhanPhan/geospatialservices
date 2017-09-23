﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [DataContract]
    [XmlType(TypeName = "DirectPosition", Namespace = Declarations.GmlNameSpace), Serializable]
    public partial class DirectPosition
    {
        public DirectPosition()
        {

        }
        public DirectPosition(string value)
        {
            _Value = value; 
        }

        private string _Value;

        [XmlText(DataType="string")]
        [DataMember]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
}