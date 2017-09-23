using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms
{
    [DataContract]
    [XmlType(TypeName = "UserDefinedSymbolization", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class UserDefinedSymbolization
    {
        public UserDefinedSymbolization()
        {
        }

        private int _SupportSLD;

        [XmlAttribute(AttributeName = "SupportSLD", DataType = "int" )]
        [DataMember]
        public int SupportSLD
        {
            get { return _SupportSLD; }
            set { _SupportSLD = value; }
        }

        private int _UserLayer;

        [XmlAttribute(AttributeName = "UserLayer", DataType = "int")]
        [DataMember]
        public int UserLayer
        {
            get { return _UserLayer; }
            set { _UserLayer = value; }
        }

        private int _UserStyle;

        [XmlAttribute(AttributeName = "UserStyle", DataType = "int")]
        [DataMember]
        public int UserStyle
        {
            get { return _UserStyle; }
            set { _UserStyle = value; }
        }

        private int _RemoteWFS;

        [XmlAttribute(AttributeName = "RemoteWFS", DataType = "int")]
        [DataMember]
        public int RemoteWFS
        {
            get { return _RemoteWFS; }
            set { _RemoteWFS = value; }
        }

        private string _SupportedSLDVersion;

        [XmlElement(ElementName = "SupportedSLDVersion", DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public string SupportedSLDVersion
        {
            get { return _SupportedSLDVersion; }
            set { _SupportedSLDVersion = value; }
        }
        
    }
}
