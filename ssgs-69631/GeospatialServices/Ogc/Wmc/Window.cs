using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Window", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class Window
    {
        private int m_Width;

        [XmlAttribute(AttributeName = "width", DataType = "int")]
        public int Width
        {
            get { return m_Width; }
            set { m_Width = value; }
        }
        private int m_Height;

        [XmlAttribute(AttributeName = "height", DataType = "int")]
        public int Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }
    }
}
