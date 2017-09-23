using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs_1_0_0
{
    [DataContract]
    [XmlType(TypeName = "Spatial_Operators", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Spatial_Operators
    {

        private BBOX _BBOX;

        [XmlElement(ElementName = "BBOX", Type = typeof(BBOX), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace= Declarations.OgcNameSpace)]
        [DataMember]
        public BBOX BBOX
        {
            get { return _BBOX; }
            set { _BBOX = value; }
        }

        private Equals _Equals;

        [XmlElement(ElementName = "Equals", Type = typeof(Equals), IsNullable = false, Form = XmlSchemaForm.Qualified,  Namespace= Declarations.OgcNameSpace)]
        [DataMember]
        public Equals Equals
        {
            get { return _Equals; }
            set { _Equals = value; }
        }
        
        private Disjoint _Disjoint;

        [XmlElement(ElementName = "Disjoint", Type = typeof(Disjoint), IsNullable = false, Form = XmlSchemaForm.Qualified,  Namespace= Declarations.OgcNameSpace)]
        [DataMember]
        public Disjoint Disjoint
        {
            get { return _Disjoint; }
            set { _Disjoint = value; }
        }

        private Intersect _Intersect;

        [XmlElement(ElementName = "Intersect", Type = typeof(Intersect), IsNullable = false, Form = XmlSchemaForm.Qualified,  Namespace= Declarations.OgcNameSpace)]
        [DataMember]
        public Intersect Intersect
        {
            get { return _Intersect; }
            set { _Intersect = value; }
        }
        

        private Touches _Touches;

        [XmlElement(ElementName = "Touches", Type = typeof(Touches), IsNullable = false, Form = XmlSchemaForm.Qualified,  Namespace= Declarations.OgcNameSpace)]
        [DataMember]
        public Touches Touches
        {
            get { return _Touches; }
            set { _Touches = value; }
        }
        
        private Crosses _Crosses;

        [XmlElement(ElementName = "Crosses", Type = typeof(Crosses), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace= Declarations.OgcNameSpace)]
        [DataMember]
        public Crosses Crosses
        {
            get { return _Crosses; }
            set { _Crosses = value; }
        }


        private Within _Within;

        [XmlElement(ElementName = "Within", Type = typeof(Within), IsNullable = false, Form = XmlSchemaForm.Qualified,  Namespace= Declarations.OgcNameSpace)]
        [DataMember]
        public Within Within
        {
            get { return _Within; }
            set { _Within = value; }
        }


        private Contains _Contains;

        [XmlElement(ElementName = "Contains", Type = typeof(Contains), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace= Declarations.OgcNameSpace)]
        [DataMember]
        public Contains Contains
        {
            get { return _Contains; }
            set { _Contains = value; }
        }
        

        private Overlaps _Overlaps;

        [XmlElement(ElementName = "Overlaps", Type = typeof(Overlaps), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace= Declarations.OgcNameSpace)]
        [DataMember]
        public Overlaps Overlaps
        {
            get { return _Overlaps; }
            set { _Overlaps = value; }
        }

        private Beyond _Beyond;

        [XmlElement(ElementName = "Beyond", Type = typeof(Beyond), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace= Declarations.OgcNameSpace)]
        [DataMember]
        public Beyond Beyond
        {
            get { return _Beyond; }
            set { _Beyond = value; }
        }


        private DWithin _DWithin;

        [XmlElement(ElementName = "DWithin", Type = typeof(DWithin), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace= Declarations.OgcNameSpace)]
        [DataMember]
        public DWithin DWithin
        {
            get { return _DWithin; }
            set { _DWithin = value; }
        }


    }
}
