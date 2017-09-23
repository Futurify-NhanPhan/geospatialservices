using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Dimension", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class Dimension
    {
        private string m_Name;

        [XmlAttribute(AttributeName = "name", DataType = "string")]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private string m_Units;

        [XmlAttribute(AttributeName = "units", DataType = "string")]
        public string Units
        {
            get { return m_Units; }
            set { m_Units = value; }
        }

        private string m_UnitSymbol;

        [XmlAttribute(AttributeName = "unitSymbol", DataType = "string")]
        public string UnitSymbol
        {
            get { return m_UnitSymbol; }
            set { m_UnitSymbol = value; }
        }

        private string m_UserValue;
        [XmlAttribute(AttributeName = "userValue", DataType = "string")]
        public string UserValue
        {
            get { return m_UserValue; }
            set { m_UserValue = value; }
        }

        private string m_Default;
        [XmlAttribute(AttributeName = "default", DataType = "string")]
        public string Default
        {
            get { return m_Default; }
            set { m_Default = value; }
        }

        [XmlAttribute(AttributeName = "multipleValues", DataType = "int")]
        private int m_MultipleValues;

        public int MultipleValues
        {
            get { return m_MultipleValues; }
            set { m_MultipleValues = value; }
        }

        private int m_NearestValues;

        [XmlAttribute(AttributeName = "nearestValue", DataType = "int")]
        public int NearestValues
        {
            get { return m_NearestValues; }
            set { m_NearestValues = value; }
        }

        private int m_Current;

        [XmlAttribute(AttributeName = "current", DataType = "int")]
        public int Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }

 
    }
}
