using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlType(TypeName = "AbstractRingProperty", Namespace = Declarations.GmlNameSpace  ), Serializable]
    [DataContract]
    public partial class AbstractRingProperty 
    {
        public AbstractRingProperty()
        {
        }

        public AbstractRingProperty(LinearRing linearRing)
        {
            _LinearRing = linearRing;
        }

        private LinearRing _LinearRing;

        [XmlElement(ElementName = "LinearRing", Type = typeof(LinearRing), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [DataMember]
        public LinearRing LinearRing
        {
            get 
            {
                if (_LinearRing == null)
                {
                    _LinearRing = new LinearRing(); 
                }
            return _LinearRing; 
            }
            
            set {_LinearRing = value;}
            }
      }

  }


