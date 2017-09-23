using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlInclude(typeof(AbstractFeatureBase))]
    [XmlInclude(typeof(AbstractFeature))]
    [XmlInclude(typeof(AbstractGeometry))]
    [XmlInclude(typeof(LinearRing))]
    [XmlInclude(typeof(AbstractGeometricPrimitive))]
    [XmlInclude(typeof(AbstractCurve))]
    [XmlInclude(typeof(LineString))]
    [XmlInclude(typeof(Curve))]
    [XmlInclude(typeof(Point))]
    [XmlInclude(typeof(AbstractSurface))]
    [XmlInclude(typeof(Polygon))]
    [XmlInclude(typeof(Surface))]
    [XmlInclude(typeof(AbstractGeometricAggregate))]
    [XmlInclude(typeof(MultiSurface))]
    [XmlInclude(typeof(MultiCurve))]
    [XmlInclude(typeof(MultiPoint))]
    [XmlInclude(typeof(MultiGeometry))]
    [DataContract]
    [XmlType(TypeName = "AbstractGML", Namespace = Declarations.GmlNameSpace), Serializable]
    public abstract partial class AbstractGML
    {

        private string _Description;

        [XmlElement(ElementName = "description", Type = typeof(string), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember] 
        public string description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        [XmlIgnore]
        [DataMember]
        public bool NameListSpecified;

        private List<Code> _NameList;

        [XmlElement(ElementName = "name", Type = typeof(Code), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace=Declarations.GmlNameSpace)]
        [DataMember] 
        public List<Code> name
        {
            get
            {
                if (_NameList == null)
                {
                    _NameList = new List<Code>();
                    NameListSpecified = true;
                }
                return _NameList;
            }
            set
            {
                _NameList = value; NameListSpecified = true;
            }
        }

        private string _Id;

        [XmlAttribute(AttributeName="id",Form =XmlSchemaForm.Qualified, Namespace= Declarations.GmlNameSpace, DataType = "ID")]
        [DataMember] 
        public string id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
    }

}
