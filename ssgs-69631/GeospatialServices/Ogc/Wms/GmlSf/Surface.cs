using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wms.GmlSf
{
    [XmlType(TypeName = "Surface", Namespace = Declarations.GmlNameSpace), Serializable]
    [DataContract]
    public partial class Surface : AbstractSurface
    {

        private List<AbstractSurfacePatch> _PatchesList;

        [XmlArray(ElementName = "patches", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        [XmlArrayItem("PolygonPatch", Type=typeof(PolygonPatch), IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.GmlNameSpace)]
        public List<AbstractSurfacePatch> patches
        {
            get 
            {
                if (_PatchesList == null)
                {
                    _PatchesList = new List<AbstractSurfacePatch>(); 
                }
                return _PatchesList; 
            }
            set { _PatchesList = value;}
        }


    }

}
