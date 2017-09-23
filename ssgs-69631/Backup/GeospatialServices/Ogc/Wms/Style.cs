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
    [XmlType(TypeName = "Style", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class Style
    {

        [XmlIgnore]
        [DataMember] public bool NameSpecified;
        private string _Name;

        [XmlElement(ElementName = "Name", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string Name
        {
            get { return _Name; }
            set { _Name = value; NameSpecified = true; }
        }

        [XmlIgnore]
        [DataMember] public bool TitleSpecified;
        private string _Title;

        [XmlElement(ElementName = "Title", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string Title
        {
            get { return _Title; }
            set { _Title = value; TitleSpecified = true; }
        }

        [XmlIgnore] 
        [DataMember] public bool AbstractSpecified = true;
        private string _Abstract;

        [XmlElement(ElementName = "Abstract", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string Abstract
        {
            get { return _Abstract; }
            set { _Abstract = value; AbstractSpecified = true; }
        }

        
        private LegendURL _LegendURL;
        [XmlElement(Type = typeof(LegendURL), ElementName = "LegendURL", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public LegendURL LegendURL
        {
            get {return _LegendURL;}
            set { _LegendURL = value;}
        }

        
        private StyleSheetURL _StyleSheetURL;

        [XmlElement(Type = typeof(StyleSheetURL), ElementName = "StyleSheetURL", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public StyleSheetURL StyleSheetURL
        {
            get {return _StyleSheetURL;}
            set { _StyleSheetURL = value;}
        }



        private StyleURL _StyleURL;

        [XmlElement(Type = typeof(StyleURL), ElementName = "StyleURL", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public StyleURL StyleURL
        {
            get { return _StyleURL;}
            set { _StyleURL = value;}
        }

        
    }
}
