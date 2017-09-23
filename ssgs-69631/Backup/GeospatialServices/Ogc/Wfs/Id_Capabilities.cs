using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wfs
{
    [DataContract]
    [XmlType(TypeName = "Id_Capabilities", Namespace = Declarations.OgcNameSpace), Serializable]
    public partial class Id_Capabilities
    {

        [XmlIgnore]
        public IdTypes[] IdSelections;

        private object[] _Ids;

        [XmlChoiceIdentifier(MemberName = "IdSelections")]
        [XmlElement(ElementName = "EID", Type = typeof(EID), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]
        [XmlElement(ElementName = "FID", Type = typeof(FID), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.OgcNameSpace)]

        public object[] Ids
        {
            get { return _Ids; }
            set { _Ids = value;}
        }

      
    }
}
