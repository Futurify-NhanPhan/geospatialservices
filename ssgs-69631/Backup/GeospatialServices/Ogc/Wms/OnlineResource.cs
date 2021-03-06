﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms
{
    [DataContract]
    [XmlType(TypeName = "OnlineResource", Namespace = Declarations.XlinkNameSpace), Serializable]
    public partial class OnlineResource
    {

        private string _Type;

        [XmlAttribute(AttributeName = "type", DataType = "string", Form= XmlSchemaForm.Qualified, Namespace = Declarations.XlinkNameSpace)]
        [DataMember] public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _Href;

        [XmlAttribute(AttributeName = "href", DataType = "anyURI", Form = XmlSchemaForm.Qualified, Namespace = Declarations.XlinkNameSpace)]
        [DataMember] public string Href
        {
            get { return _Href; }
            set { _Href = value; }
        }
        private string _Role;

        [XmlAttribute(AttributeName = "role", DataType = "anyURI", Form = XmlSchemaForm.Qualified, Namespace = Declarations.XlinkNameSpace)]
        [DataMember] public string Role
        {
            get { return _Role; }
            set { _Role = value; }
        }
        private string _ArcRole;

        [XmlAttribute(AttributeName = "arcrole", DataType = "anyURI", Form = XmlSchemaForm.Qualified, Namespace = Declarations.XlinkNameSpace)]
        [DataMember] public string ArcRole
        {
            get { return _ArcRole; }
            set { _ArcRole = value; }
        }
        private string _Title;

        [XmlAttribute(AttributeName = "title", DataType = "string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.XlinkNameSpace)]
        [DataMember] public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        [XmlIgnore]
        [DataMember] public bool ShowSpecified;

        private ShowTypes _Show;

        [XmlAttribute(AttributeName = "show", Form = XmlSchemaForm.Qualified, Namespace = Declarations.XlinkNameSpace)]
        [DataMember] public ShowTypes Show
        {
            get { return _Show; }
            set { _Show = value; ShowSpecified = true; }
        }

        [XmlIgnore]
        [DataMember] public bool ActuateSpecified;
        private ActuateTypes _Actuate;


        [XmlAttribute(AttributeName = "actuate", Form = XmlSchemaForm.Qualified, Namespace = Declarations.XlinkNameSpace)]
        [DataMember] public ActuateTypes Actuate
        {
            get { return _Actuate; }
            set { _Actuate = value; ActuateSpecified = true; }
        }
    }
}
