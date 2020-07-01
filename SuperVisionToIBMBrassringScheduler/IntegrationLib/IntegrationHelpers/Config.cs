using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib.IntegrationHelpers
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Config
    {

        private ConfigResource[] resourcesField;

        private ConfigSmtp smtpField;

        private ConfigIntegration[] integrationsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Resource", IsNullable = false)]
        public ConfigResource[] Resources
        {
            get
            {
                return this.resourcesField;
            }
            set
            {
                this.resourcesField = value;
            }
        }

        /// <remarks/>
        public ConfigSmtp Smtp
        {
            get
            {
                return this.smtpField;
            }
            set
            {
                this.smtpField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Integration", IsNullable = false)]
        public ConfigIntegration[] Integrations
        {
            get
            {
                return this.integrationsField;
            }
            set
            {
                this.integrationsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigResource
    {

        private ConfigResourceFtp ftpField;

        private ConfigResourceFile fileField;

        private string nameField;

        private string resourceTypeField;

        private string locationTypeField;

        /// <remarks/>
        public ConfigResourceFtp Ftp
        {
            get
            {
                return this.ftpField;
            }
            set
            {
                this.ftpField = value;
            }
        }

        /// <remarks/>
        public ConfigResourceFile File
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ResourceType
        {
            get
            {
                return this.resourceTypeField;
            }
            set
            {
                this.resourceTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LocationType
        {
            get
            {
                return this.locationTypeField;
            }
            set
            {
                this.locationTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigResourceFtp
    {

        private string hostField;

        private string userNameField;

        private string passwordField;

        private string keyFilePathField;

        private string ftpFolderPathField;

        private string successFolderPathField;

        private string errorFolderPathField;

        private string localTempProcDirectoryField;

        /// <remarks/>
        public string Host
        {
            get
            {
                return this.hostField;
            }
            set
            {
                this.hostField = value;
            }
        }

        /// <remarks/>
        public string UserName
        {
            get
            {
                return this.userNameField;
            }
            set
            {
                this.userNameField = value;
            }
        }

        /// <remarks/>
        public string Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        /// <remarks/>
        public string KeyFilePath
        {
            get
            {
                return this.keyFilePathField;
            }
            set
            {
                this.keyFilePathField = value;
            }
        }

        /// <remarks/>
        public string FtpFolderPath
        {
            get
            {
                return this.ftpFolderPathField;
            }
            set
            {
                this.ftpFolderPathField = value;
            }
        }

        /// <remarks/>
        public string SuccessFolderPath
        {
            get
            {
                return this.successFolderPathField;
            }
            set
            {
                this.successFolderPathField = value;
            }
        }

        /// <remarks/>
        public string ErrorFolderPath
        {
            get
            {
                return this.errorFolderPathField;
            }
            set
            {
                this.errorFolderPathField = value;
            }
        }

        /// <remarks/>
        public string LocalTempProcDirectory
        {
            get
            {
                return this.localTempProcDirectoryField;
            }
            set
            {
                this.localTempProcDirectoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigResourceFile
    {

        private string pathField;

        /// <remarks/>
        public string Path
        {
            get
            {
                return this.pathField;
            }
            set
            {
                this.pathField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigSmtp
    {

        private byte portField;

        private string hostField;

        private bool enableSslField;

        private bool useDefaultCredentialsField;

        private string userNameField;

        private string passwordField;

        private ConfigSmtpMail mailField;

        /// <remarks/>
        public byte Port
        {
            get
            {
                return this.portField;
            }
            set
            {
                this.portField = value;
            }
        }

        /// <remarks/>
        public string Host
        {
            get
            {
                return this.hostField;
            }
            set
            {
                this.hostField = value;
            }
        }

        /// <remarks/>
        public bool EnableSsl
        {
            get
            {
                return this.enableSslField;
            }
            set
            {
                this.enableSslField = value;
            }
        }

        /// <remarks/>
        public bool UseDefaultCredentials
        {
            get
            {
                return this.useDefaultCredentialsField;
            }
            set
            {
                this.useDefaultCredentialsField = value;
            }
        }

        /// <remarks/>
        public string UserName
        {
            get
            {
                return this.userNameField;
            }
            set
            {
                this.userNameField = value;
            }
        }

        /// <remarks/>
        public string Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        /// <remarks/>
        public ConfigSmtpMail Mail
        {
            get
            {
                return this.mailField;
            }
            set
            {
                this.mailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigSmtpMail
    {

        private string fromField;

        private string toField;

        private string subjectField;

        private byte isHtmlField;

        private string bodyField;

        /// <remarks/>
        public string From
        {
            get
            {
                return this.fromField;
            }
            set
            {
                this.fromField = value;
            }
        }

        /// <remarks/>
        public string To
        {
            get
            {
                return this.toField;
            }
            set
            {
                this.toField = value;
            }
        }

        /// <remarks/>
        public string Subject
        {
            get
            {
                return this.subjectField;
            }
            set
            {
                this.subjectField = value;
            }
        }

        /// <remarks/>
        public byte IsHtml
        {
            get
            {
                return this.isHtmlField;
            }
            set
            {
                this.isHtmlField = value;
            }
        }

        /// <remarks/>
        public string Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigIntegration
    {

        private ConfigIntegrationRequest requestField;

        private string typeField;

        /// <remarks/>
        public ConfigIntegrationRequest Request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigIntegrationRequest
    {

        private ConfigIntegrationRequestRequestData requestDataField;

        private string typeField;

        private string urlField;

        /// <remarks/>
        public ConfigIntegrationRequestRequestData RequestData
        {
            get
            {
                return this.requestDataField;
            }
            set
            {
                this.requestDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigIntegrationRequestRequestData
    {

        private string envelopeField;

        private string payLoadField;

        /// <remarks/>
        public string Envelope
        {
            get
            {
                return this.envelopeField;
            }
            set
            {
                this.envelopeField = value;
            }
        }

        /// <remarks/>
        public string PayLoad
        {
            get
            {
                return this.payLoadField;
            }
            set
            {
                this.payLoadField = value;
            }
        }
    }


}
