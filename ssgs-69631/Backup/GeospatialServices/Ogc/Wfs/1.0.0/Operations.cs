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
    [XmlType(TypeName = "Operations", Namespace = Declarations.Wfs100NameSpace), Serializable]
    public partial class Operations
    {
        
        private EmptyType _Insert;

        [XmlElement(ElementName = "Insert", Type = typeof(EmptyType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        public EmptyType Insert
        {
            get { return _Insert; }
            set { _Insert = value; }
        }

        private EmptyType _Update;

        [XmlElement(ElementName = "Update", Type = typeof(EmptyType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        public EmptyType Update
        {
            get { return _Update; }
            set { _Update = value; }
        }

        private EmptyType _Delete;

        [XmlElement(ElementName = "Delete", Type = typeof(EmptyType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        public EmptyType Delete
        {
            get { return _Delete; }
            set { _Delete = value; }
        }
        
        
        private EmptyType _Query;

        [XmlElement(ElementName = "Query", Type = typeof(EmptyType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        public EmptyType Query
        {
            get { return _Query; }
            set { _Query = value; }
        }


        private EmptyType _Lock;

        [XmlElement(ElementName = "Lock", Type = typeof(EmptyType), IsNullable = false, Form = XmlSchemaForm.Unqualified)]
        public EmptyType Lock
        {
            get { return _Lock; }
            set { _Lock = value; }
        }


    }
}
