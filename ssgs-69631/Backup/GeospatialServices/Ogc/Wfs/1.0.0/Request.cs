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
    [XmlType(TypeName = "Request", Namespace = Declarations.OwsNameSpace), Serializable]
    public partial class Request
    {

        private GetCapabilities _GetCapabilities;

        [XmlElement(ElementName = "GetCapabilities", Type = typeof(GetCapabilities), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        public GetCapabilities GetCapabilities
        {
            get { return _GetCapabilities; }
            set { _GetCapabilities = value; }
        }

        private DescribeFeatureType _DescribeFeatureType;

        [XmlElement(ElementName = "DescribeFeatureType", Type = typeof(DescribeFeatureType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        public DescribeFeatureType DescribeFeatureType
        {
            get { return _DescribeFeatureType; }
            set { _DescribeFeatureType = value; }
        }

        private GetFeatureType _GetFeature;

        [XmlElement(ElementName = "GetFeature", Type = typeof(GetFeatureType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        public GetFeatureType GetFeature
        {
            get { return _GetFeature; }
            set { _GetFeature = value; }
        }


        private LockFeatureType _LockFeatureType;

        [XmlElement(ElementName = "LockFeatureType", Type = typeof(LockFeatureType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        public LockFeatureType LockFeatureType
        {
            get { return _LockFeatureType; }
            set { _LockFeatureType = value; }
        }


        private GetFeatureType _GetFeatureWithLock;

        [XmlElement(ElementName = "GetFeatureWithLock", Type = typeof(GetFeatureType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        public GetFeatureType GetFeatureWithLock
        {
            get { return _GetFeatureWithLock; }
            set { _GetFeatureWithLock = value; }
        }
        
        private Transaction _Transaction;

        [XmlElement(ElementName = "Transaction", Type = typeof(Transaction), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        public Transaction Transaction
        {
            get { return _Transaction; }
            set { _Transaction = value; }
        }

    }
}
