using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib.VendorClasses.IBMBrassring
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class form
    {

        private formFormInput[] formInputField;

        private ushort formTypeIdField;

        private string formNameField;

        private string formIdField;

        private string actionField;

        private uint resumeKeyField;

        private string firstNameField;

        private string lastNameField;

        private string emailField;

        private string homePhoneField;

        private string languageField;

        private string autoreqField;

        private string optionalreqField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FormInput")]
        public formFormInput[] FormInput
        {
            get
            {
                return this.formInputField;
            }
            set
            {
                this.formInputField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort formTypeId
        {
            get
            {
                return this.formTypeIdField;
            }
            set
            {
                this.formTypeIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string formName
        {
            get
            {
                return this.formNameField;
            }
            set
            {
                this.formNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string formId
        {
            get
            {
                return this.formIdField;
            }
            set
            {
                this.formIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint resumeKey
        {
            get
            {
                return this.resumeKeyField;
            }
            set
            {
                this.resumeKeyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string homePhone
        {
            get
            {
                return this.homePhoneField;
            }
            set
            {
                this.homePhoneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string autoreq
        {
            get
            {
                return this.autoreqField;
            }
            set
            {
                this.autoreqField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string optionalreq
        {
            get
            {
                return this.optionalreqField;
            }
            set
            {
                this.optionalreqField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class formFormInput
    {

        private uint nameField;

        private string titleField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint name
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
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }



}
