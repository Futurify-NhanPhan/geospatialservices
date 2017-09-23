using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms
{
    [DataContract]
    [XmlType(TypeName = "Dimension", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class Dimension
    {
        private string _Name;

        [XmlAttribute(AttributeName = "name", DataType = "string")]
        [DataMember] public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Units;

        [XmlAttribute(AttributeName = "units", DataType = "string")]
        [DataMember] public string Units
        {
            get { return _Units; }
            set { _Units = value; }
        }

        private string _UnitSymbol;

        [XmlAttribute(AttributeName = "unitSymbol", DataType = "string")]
        [DataMember] public string UnitSymbol
        {
            get { return _UnitSymbol; }
            set { _UnitSymbol = value; }
        }

        private string _UserValue;
        [XmlAttribute(AttributeName = "userValue", DataType = "string")]
        [DataMember] public string UserValue
        {
            get { return _UserValue; }
            set { _UserValue = value; }
        }

        private string _Default;
        [XmlAttribute(AttributeName = "default", DataType = "string")]
        [DataMember] public string Default
        {
            get { return _Default; }
            set { _Default = value; }
        }

        private int _MultipleValues;

        [XmlAttribute(AttributeName = "multipleValues", DataType = "int")]
        [DataMember] public int MultipleValues
        {
            get { return _MultipleValues; }
            set { _MultipleValues = value; }
        }

        private int _NearestValues;

        [XmlAttribute(AttributeName = "nearestValue", DataType = "int")]
        [DataMember] public int NearestValues
        {
            get { return _NearestValues; }
            set { _NearestValues = value; }
        }

        private int _Current;

        [XmlAttribute(AttributeName = "current", DataType = "int")]
        [DataMember] public int Current
        {
            get { return _Current; }
            set { _Current = value; }
        }

        private string _Value;

        [XmlText(DataType = "string")]
        [DataMember] 
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }


    }
}
