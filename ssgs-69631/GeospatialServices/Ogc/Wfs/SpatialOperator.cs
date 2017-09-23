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
    [XmlType(TypeName = "SpatialOperator", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class SpatialOperator
    {
        
        private string _Name;

        [XmlAttribute(AttributeName = "name", DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OwsNameSpace)]
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value;}
        }


        private GeometryOperands _GeometryOperands;

        [XmlElement(ElementName = "GeometryOperands", Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace, Type = typeof(GeometryOperands))]
        [DataMember]
        public GeometryOperands GeometryOperands
        {
            get
            {
                if (_GeometryOperands == null)
                {
                    _GeometryOperands = new GeometryOperands();
                }
                return _GeometryOperands;
            }
            set { _GeometryOperands = value; }
        }

    }
}
