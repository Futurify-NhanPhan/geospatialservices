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
    [XmlType(TypeName = "Service", Namespace = Declarations.WmsNameSpace), Serializable]
    public partial class Service
    {

        private ServiceNames _Name;

        [XmlElement(ElementName = "Name", Type = typeof(ServiceNames), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public ServiceNames Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Title;

        [XmlElement(ElementName = "Title", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Abstract;

        [XmlElement(ElementName = "Abstract", IsNullable = false, DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string Abstract
        {
            get { return _Abstract; }
            set { _Abstract = value; }
        }


        [XmlIgnore]
        [DataMember] public bool KeyWordListSpecified;

        private List<Keyword> _KeywordList;

        [XmlArray(ElementName = "KeywordList", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [XmlArrayItem(ElementName = "Keyword", Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public List<Keyword> KeywordList
        {
            get
            {
                if (_KeywordList == null)
                {
                    _KeywordList = new List<Keyword>();
                    KeyWordListSpecified = true;
                }
                return _KeywordList;
            }

            set { _KeywordList = value; KeyWordListSpecified = true; }
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


        [XmlIgnore]
        [DataMember] public bool ContactInformationSpecified;
        private ContactInformation _ContactInformation;

        [XmlElement(Type = typeof(ContactInformation), ElementName = "ContactInformation", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public ContactInformation ContactInformation
        {
            get
            {
                if (_ContactInformation == null)
                {
                    _ContactInformation = new ContactInformation();
                    ContactInformationSpecified = true;
                }
                return _ContactInformation;
            }
            set { _ContactInformation = value; ContactInformationSpecified = true; }
        }


        private string _Fees;

        [XmlElement(Type = typeof(string), ElementName = "Fees", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string Fees
        {
            get { return _Fees; }
            set
            {
                _Fees = value;
            }
        }

        private string _AccessConstraints;

        [XmlElement(Type = typeof(string), ElementName = "AccessConstraints", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public string AccessConstraints
        {
            get { return _AccessConstraints; }
            set { _AccessConstraints = value; }
        }

        private int _LayerLimit;

        [XmlElement(Type = typeof(int), ElementName = "LayerLimit", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public int LayerLimit
        {
            get { return _LayerLimit; }
            set { _LayerLimit = value; }
        }

        private int _MaxWidth;

        [XmlElement(Type = typeof(int), ElementName = "MaxWidth", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public int MaxWidth
        {
            get { return this._MaxWidth; }
            set { this._MaxWidth = value; }
        }

        private int _MaxHeight;

        [XmlElement(Type = typeof(int), ElementName = "MaxHeight", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.WmsNameSpace)]
        [DataMember] public int MaxHeight
        {
            get { return _MaxHeight; }
            set { _MaxHeight = value; }
        }
    }
    
}
