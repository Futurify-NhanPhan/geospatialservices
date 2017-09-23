using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "ChannelSelection", Namespace = Declarations.SeNameSpace), Serializable]
    public partial class ChannelSelection
    {

        [XmlIgnore]
        public bool RedChannelSpecified;
        private SelectedChannel m_RedChannel;

        [XmlElement(Type = typeof(SelectedChannel), ElementName = "RedChannel", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public SelectedChannel RedChannel
        {
            get
            {
                if (m_RedChannel == null)
                {
                    m_RedChannel = new SelectedChannel();
                    RedChannelSpecified = true;
                }
                return m_RedChannel; 
            }
            set { m_RedChannel = value; RedChannelSpecified = true; }
        }

        [XmlIgnore]
        public bool GreenChannelSpecified;
        private SelectedChannel m_GreenChannel;

        [XmlElement(Type = typeof(SelectedChannel), ElementName = "GreenChannel", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public SelectedChannel GreenChannel
        {
            get
            {
                if (m_GreenChannel == null)
                {
                    m_GreenChannel = new SelectedChannel();
                    GreenChannelSpecified = true;
                }
                return m_GreenChannel;
            }
            set { m_GreenChannel = value; GreenChannelSpecified = true; }
        }

        [XmlIgnore]
        public bool BlueChannelSpecified;
        private SelectedChannel m_BlueChannel;

        [XmlElement(Type = typeof(SelectedChannel), ElementName = "BlueChannel", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public SelectedChannel BlueChannel
        {
            get
            {
                if (m_BlueChannel == null)
                {
                    m_BlueChannel = new SelectedChannel();
                    BlueChannelSpecified = true;
                }
                return m_BlueChannel;
            }
            set { m_BlueChannel = value; BlueChannelSpecified = true; }
        }


        [XmlIgnore]
        public bool GrayChannelSpecified;
        private SelectedChannel m_GrayChannel;

        [XmlElement(Type = typeof(SelectedChannel), ElementName = "GrayChannel", IsNullable = false, Form = XmlSchemaForm.Qualified, Namespace = Declarations.SeNameSpace)]
        public SelectedChannel GrayChannel
        {
            get
            {
                if (m_GrayChannel == null)
                {
                    m_GrayChannel = new SelectedChannel();
                    GrayChannelSpecified = true;
                }
                return m_GrayChannel;
            }
            set { m_GrayChannel = value; GrayChannelSpecified = true; }
        }



    }
}
