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
    [XmlType(TypeName = "Attribution", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class Attribution
    {

        private string _Title;

        [XmlElement(ElementName = "Title", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        [XmlIgnore]
        [DataMember] public bool OnlineResourceSpecified;
        private OnlineResource _OnlineResource;


        [XmlElement(Type = typeof(OnlineResource), ElementName = "OnlineResource", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public OnlineResource OnlineResource
        {
            get
            {

                if (_OnlineResource == null)
                {
                    _OnlineResource = new OnlineResource();
                    OnlineResourceSpecified = true;
                }

                return _OnlineResource;
            }

            set { _OnlineResource = value; OnlineResourceSpecified = true; }
        }



        private LogoURL _LogoURL;

        [XmlElement(ElementName = "LogoURL", IsNullable = false,  Type = typeof(LogoURL), Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public LogoURL LogoURL
        {
            get { return _LogoURL; }
            set { _LogoURL = value; }
        }
        
    }

}
