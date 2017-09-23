using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Runtime.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms
{
    [DataContract]
    [XmlType(TypeName = "EX_GeographicBoundingBox", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class EX_GeographicBoundingBox
    {
        public EX_GeographicBoundingBox()
        {
        }

        private double _WestBoundLongitude;

        [XmlElement(ElementName = "westBoundLongitude", IsNullable = false,  Type = typeof(double), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public double WestBoundLongitude
        {
            get { return _WestBoundLongitude; }
            set { _WestBoundLongitude = value; }
        }

        private double _EastBoundLongitude;

        [XmlElement(ElementName = "eastBoundLongitude", IsNullable = false, Type = typeof(double), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public double EastBoundLongitude
        {
            get { return _EastBoundLongitude; }
            set { _EastBoundLongitude = value; }
        }

        private double _SouthBoundLatitude;

        [XmlElement(ElementName = "southBoundLatitude", IsNullable = false, Type = typeof(double), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public double SouthBoundLatitude
        {
            get { return _SouthBoundLatitude; }
            set { _SouthBoundLatitude = value; }
        }

        private double _NorthBoundLatitude;

        [XmlElement(ElementName = "northBoundLatitude", IsNullable = false, Type = typeof(double), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember]
        public double NorthBoundLatitude
        {
            get { return _NorthBoundLatitude; }
            set { _NorthBoundLatitude = value; }
        }
        
    }
}
