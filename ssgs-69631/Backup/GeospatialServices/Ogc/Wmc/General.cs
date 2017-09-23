using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using GeospatialServices.Ogc.Common;

namespace GeospatialServices.Ogc.Wmc
{
    [XmlRoot(ElementName = "General", IsNullable = false),Serializable ]
    [XmlType(TypeName = "General", Namespace = Declarations.DefaultNameSpace)]
    public partial class General
    {
        [XmlIgnore]
        public bool WindowSpecified;

        private Window m_Window;

        [XmlElement(Type = typeof(Window), ElementName = "Window", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public Window Window
        {
            get 
            {
                    if (m_Window == null)
                    {
                        m_Window =   new Window();
                        WindowSpecified = true;
                    }
                    return m_Window ; 
            }
            set { m_Window = value; WindowSpecified = true; }
        }

        private BoundingBox m_BoundingBox;

        [XmlElement(Type = typeof(BoundingBox), ElementName = "BoundingBox", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public BoundingBox BoundingBox
        {
            get { return m_BoundingBox = (m_BoundingBox == null) ? new BoundingBox() : m_BoundingBox; }
            set { m_BoundingBox = value; }
        }

        private string m_Title;

        [XmlElement(ElementName = "Title", IsNullable = false, Form = XmlSchemaForm.Unqualified, DataType = "string", Namespace = Declarations.DefaultNameSpace)]
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        [XmlIgnore]
        public bool KeyWordListSpecified;

        private List<string> m_KeywordList;

        [XmlArray(ElementName ="KeywordList", Form= XmlSchemaForm.Unqualified)]   
        [XmlArrayItem(ElementName ="Keyword", Form= XmlSchemaForm.Unqualified, DataType ="string")] 
        public List<string> KeywordList
        {
            get 
            { if (m_KeywordList == null )
                {
                    m_KeywordList = new List<string>();
                    KeyWordListSpecified = true;
                }
                return m_KeywordList;
            }
            set { m_KeywordList = value; KeyWordListSpecified = true; }
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

        [XmlIgnore]
        public bool LogoURLSpecified;
        private URL m_LogoURL;

        [XmlElement(Type = typeof(URL), ElementName = "LogoURL", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public URL LogoURL
        {
            get 
            {
                if (m_LogoURL == null)
                {
                    m_LogoURL =  new URL() ;
                    LogoURLSpecified = true;
                }

                return m_LogoURL;
            }
            set { m_LogoURL = value; LogoURLSpecified = true; }
        }

        [XmlIgnore]
        public bool DescriptionURLSpecified;
        private URL m_DescriptionURL;
        
        [XmlElement(Type = typeof(URL), ElementName = "DescriptionURL", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public URL DescriptionURL
        {
            get 
            {   if (m_DescriptionURL == null)
                {
                    m_DescriptionURL =  new URL();
                    DescriptionURLSpecified = true; 

                }
                return m_DescriptionURL;
            }

            set { m_DescriptionURL = value; DescriptionURLSpecified = true; }
        }

        [XmlIgnore]
        public bool ContactInformationSpecified;
        private ContactInformation m_ContactInformation;

        [XmlElement(Type = typeof(ContactInformation), ElementName = "ContactInformation", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public ContactInformation ContactInformation
        {
            get 
            { 
                if (m_ContactInformation == null)
                {
                    m_ContactInformation =  new ContactInformation();
                    ContactInformationSpecified = true;
                }
                return m_ContactInformation ;
            }
            set { m_ContactInformation = value; ContactInformationSpecified = true; }
        }

        [XmlIgnore]
        public bool ExtensionSpecified;

        private Extension m_Extension;

        [XmlElement(Type = typeof(Extension), ElementName = "Extension", IsNullable = false, Form = XmlSchemaForm.Unqualified, Namespace = Declarations.DefaultNameSpace)]
        public Extension Extension
        {
            get 
            { 
               if (m_Extension == null)
               {
                    m_Extension =   new Extension();
                    ExtensionSpecified = true;
               }
               return m_Extension;
            }
            set { m_Extension = value; ExtensionSpecified = true; }
        }
    }
}
