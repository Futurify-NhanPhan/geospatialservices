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
    [XmlType(TypeName = "Request", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class Request
    {

        private OperationType _GetCapabilities;

        [XmlElement(ElementName = "GetCapabilities", Type = typeof(OperationType), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public OperationType GetCapabilities
        {
            get{return _GetCapabilities;}
            set {_GetCapabilities = value;}
        }


        private OperationType _GetMap;

        [XmlElement(ElementName = "GetMap", Type = typeof(OperationType), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public OperationType GetMap
        {
            get { return _GetMap; }
            set { _GetMap = value; }
        }


        [XmlIgnore]
        [DataMember] public bool GetFeatureInfoSpecified;

        private OperationType _GetFeatureInfo;

        [XmlElement(ElementName = "GetFeatureInfo", Type = typeof(OperationType), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public OperationType GetFeatureInfo
        {
            get
            {
                if (_GetFeatureInfo == null)
                {
                    _GetFeatureInfo = new OperationType() ;
                    GetFeatureInfoSpecified = true;
                }
                return _GetFeatureInfo;
            }
            set { _GetFeatureInfo = value; GetFeatureInfoSpecified = true; }
        }

        [XmlIgnore]
        [DataMember] public bool ExtendedOperationListSpecified;

        private List<OperationType> _ExtendedOperationList;

        [XmlElement(ElementName = "_ExtendedOperation", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public List<OperationType> ExtendedOperationList
        {
            get
            {
                if (_ExtendedOperationList == null)
                {
                    _ExtendedOperationList = new List<OperationType>();
                    ExtendedOperationListSpecified = true;
                }
                return _ExtendedOperationList;
            }

            set { _ExtendedOperationList = value; ExtendedOperationListSpecified = true; }
        }





    }
}
