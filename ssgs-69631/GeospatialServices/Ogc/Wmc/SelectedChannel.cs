using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "SelectedChannel", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class SelectedChannel
    {

        private string m_SourceChannelName;

        [XmlElement(ElementName = "SourceChannelName", IsNullable = false, DataType ="string", Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public string SourceChannelName
        {
            get { return m_SourceChannelName;}
            set { m_SourceChannelName = value;}
        }



        private ContrastEnhancement m_ContrastEnchancement;

        [XmlElement(Type = typeof(ContrastEnhancement), ElementName = "ContrastEnhancement", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public ContrastEnhancement ContrastEnhancement
        {
            get
            {
                if (m_ContrastEnchancement == null)
                {
                    m_ContrastEnchancement = new ContrastEnhancement();
                }
                return m_ContrastEnchancement;
            }
            set { m_ContrastEnchancement = value; }
        }


    }
}
