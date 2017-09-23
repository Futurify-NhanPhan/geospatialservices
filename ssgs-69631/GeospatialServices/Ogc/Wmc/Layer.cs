using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlType(TypeName = "Layer", Namespace = Declarations.DefaultNameSpace), Serializable]
    public partial class Layer
    {
        private int m_Queryable;

        [XmlAttribute(AttributeName = "queryable", DataType = "int")]
        public int Queryable
        {
            get { return m_Queryable; }
            set { m_Queryable = value; }
        }

        private int m_Hidden;

        [XmlAttribute(AttributeName = "hidden", DataType = "int")]
        public int Hidden
        {
            get { return m_Hidden; }
            set { m_Hidden = value; }
        }

        private string m_Name;

        [XmlElement(ElementName = "Name", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        
        private string m_Title;

        [XmlElement(ElementName = "Title", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        [XmlIgnore]
        public bool AbstractSpecified;
        private string m_Abstract;

        [XmlElement(ElementName = "Abstract", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string Abstract
        {
            get { return m_Abstract; }
            set { m_Abstract = value; AbstractSpecified = true; }
        }


        private Server m_Server;

        [XmlElement(Type = typeof(Server), ElementName = "Server", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public Server Server
        {
            get { return m_Server = (m_Server == null) ? new Server() : m_Server; }
            set { m_Server = value; }
        }


        [XmlIgnore]
        public bool DataURLSpecified;
        private URL m_DataURL;
                
        public URL DataURL
        {
            get
            {
                if (m_DataURL == null)
                {
                    m_DataURL = new URL();
                    DataURLSpecified = true;
                }
                return m_DataURL;
            }
            set { m_DataURL = value; DataURLSpecified = true; }
        }

        [XmlIgnore] 
        public bool MetadataURLSpecified;
        private URL m_MetadataURL;

        [XmlElement(Type = typeof(URL), ElementName = "MetadataURL", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public URL MetadataURL
        {
            get 
            {
                    if (m_MetadataURL == null)
                    {
                        m_MetadataURL = new URL();
                        MetadataURLSpecified = true;
                    }
                    return m_MetadataURL; 
            }
            set { m_MetadataURL = value; MetadataURLSpecified = true; }
        }

        [XmlIgnore] 
        public bool MinScaleDenominatorSpecified;
        private double m_MinScaleDenominator;

        [XmlElement(ElementName = "MinScaleDenominator", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "double", Namespace = Declarations.SldNameSpace)]
        public double MinScaleDenominator
        {
            get { return m_MinScaleDenominator; }
            set { m_MinScaleDenominator = value; MinScaleDenominatorSpecified = true; }
        }


        [XmlIgnore]
        public bool MaxScaleDenominatorSpecified;
        private double m_MaxScaleDenominator;

        [XmlElement(ElementName = "MaxScaleDenominator", IsNullable = false, Form = XmlSchemaForm.Qualified, DataType = "double", Namespace = "http://www.opengis.net/sld")]
        public double MaxScaleDenominator
        {
            get { return m_MaxScaleDenominator; }
            set { m_MaxScaleDenominator = value; MaxScaleDenominatorSpecified = true; }
        }

        [XmlIgnore] 
        public bool SRSSpecified;
        private string m_SRS;

        [XmlElement(ElementName = "SRS", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public string SRS
        {
            get { return m_SRS; }
            set { m_SRS = value; SRSSpecified = true; }
        }

        [XmlIgnore]
        public bool FormatListSpecified;
        private List<Format> m_FormatList;

        [XmlArray(ElementName = "FormatList", Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem(ElementName = "Format", Form = XmlSchemaForm.Unqualified)] 
        public List<Format> FormatList
        {
            get 
            {
                    if (m_FormatList == null)
                    {
                        m_FormatList =  new List<Format>();
                        FormatListSpecified = true;
                    }
                    return  m_FormatList; 
            }

            set { m_FormatList = value; FormatListSpecified = true; }
        }

        [XmlIgnore]
        public bool StyleListSpecified;
        private List<Style> m_StyleList;

        [XmlArray(ElementName = "StyleList", Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem(ElementName = "Style", Form = XmlSchemaForm.Unqualified)]
        public List<Style> StyleList
        {
            get
            {
                if ((m_StyleList == null))
                {
                    m_StyleList = new List<Style>();
                    StyleListSpecified = true;
                }
                return m_StyleList;

            }
            set { m_StyleList = value; StyleListSpecified = true; }
        }


        [XmlIgnore]
        public bool DimensionListSpecified;
        private List<Dimension> m_DimensionList;

        [XmlArray(ElementName = "DimensionList", Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem(ElementName = "Dimension", Form = XmlSchemaForm.Unqualified)]
        public List<Dimension> DimensionList
        {
            get
            {
                if (m_DimensionList == null)
                {
                    m_DimensionList = new List<Dimension>();
                    DimensionListSpecified = true;
                }
                return m_DimensionList;
            }
            set { m_DimensionList = value; DimensionListSpecified = true; }
        }

        [XmlIgnore]
        public bool ExtensionSpecified;

        
        private Extension m_Extension;
        
        public Extension Extension
        {
            get
            {
                if (m_Extension == null)
                {
                    m_Extension = new Extension();
                    ExtensionSpecified = true;
                }
                return m_Extension;
            }
            set { m_Extension = value; ExtensionSpecified = true; }
        }
  
    }
}
