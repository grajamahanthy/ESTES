using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLib.VendorClasses.SuperVision.MVR
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class MVRReports
    {

        private MVRReportsMVRReport mVRReportField;

        /// <remarks/>
        public MVRReportsMVRReport MVRReport
        {
            get
            {
                return this.mVRReportField;
            }
            set
            {
                this.mVRReportField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReport
    {

        private MVRReportsMVRReportClient clientField;

        private MVRReportsMVRReportDriver driverField;

        private MVRReportsMVRReportLicense licenseField;

        private MVRReportsMVRReportError errorField;

        private MVRReportsMVRReportClasses classesField;

        private MVRReportsMVRReportLicenseComments licenseCommentsField;

        private MVRReportsMVRReportAdditionalAlert[] additionalAlertsField;

        private MVRReportsMVRReportEmbeddedReports embeddedReportsField;

        private string quotebackField;

        private byte versionField;

        private string nameField;

        private System.DateTime abstractDateField;

        private string requestedByField;

        private ushort reportIDField;

        /// <remarks/>
        public MVRReportsMVRReportClient Client
        {
            get
            {
                return this.clientField;
            }
            set
            {
                this.clientField = value;
            }
        }

        /// <remarks/>
        public MVRReportsMVRReportDriver Driver
        {
            get
            {
                return this.driverField;
            }
            set
            {
                this.driverField = value;
            }
        }

        /// <remarks/>
        public MVRReportsMVRReportLicense License
        {
            get
            {
                return this.licenseField;
            }
            set
            {
                this.licenseField = value;
            }
        }

        /// <remarks/>
        public MVRReportsMVRReportError Error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }

        /// <remarks/>
        public MVRReportsMVRReportClasses Classes
        {
            get
            {
                return this.classesField;
            }
            set
            {
                this.classesField = value;
            }
        }

        /// <remarks/>
        public MVRReportsMVRReportLicenseComments LicenseComments
        {
            get
            {
                return this.licenseCommentsField;
            }
            set
            {
                this.licenseCommentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("AdditionalAlert", IsNullable = false)]
        public MVRReportsMVRReportAdditionalAlert[] AdditionalAlerts
        {
            get
            {
                return this.additionalAlertsField;
            }
            set
            {
                this.additionalAlertsField = value;
            }
        }

        /// <remarks/>
        public MVRReportsMVRReportEmbeddedReports EmbeddedReports
        {
            get
            {
                return this.embeddedReportsField;
            }
            set
            {
                this.embeddedReportsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Quoteback
        {
            get
            {
                return this.quotebackField;
            }
            set
            {
                this.quotebackField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime AbstractDate
        {
            get
            {
                return this.abstractDateField;
            }
            set
            {
                this.abstractDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RequestedBy
        {
            get
            {
                return this.requestedByField;
            }
            set
            {
                this.requestedByField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort ReportID
        {
            get
            {
                return this.reportIDField;
            }
            set
            {
                this.reportIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportClient
    {

        private uint clientIDField;

        private string clientNameField;

        private string divisionNameField;

        /// <remarks/>
        public uint ClientID
        {
            get
            {
                return this.clientIDField;
            }
            set
            {
                this.clientIDField = value;
            }
        }

        /// <remarks/>
        public string ClientName
        {
            get
            {
                return this.clientNameField;
            }
            set
            {
                this.clientNameField = value;
            }
        }

        /// <remarks/>
        public string DivisionName
        {
            get
            {
                return this.divisionNameField;
            }
            set
            {
                this.divisionNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportDriver
    {

        private byte driverReferenceNumberField;

        private string workStatusField;

        private string firstNameField;

        private string middleNameField;

        private string lastNameField;

        private System.DateTime birthDateField;

        private string genderField;

        /// <remarks/>
        public byte DriverReferenceNumber
        {
            get
            {
                return this.driverReferenceNumberField;
            }
            set
            {
                this.driverReferenceNumberField = value;
            }
        }

        /// <remarks/>
        public string WorkStatus
        {
            get
            {
                return this.workStatusField;
            }
            set
            {
                this.workStatusField = value;
            }
        }

        /// <remarks/>
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
        public string MiddleName
        {
            get
            {
                return this.middleNameField;
            }
            set
            {
                this.middleNameField = value;
            }
        }

        /// <remarks/>
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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime BirthDate
        {
            get
            {
                return this.birthDateField;
            }
            set
            {
                this.birthDateField = value;
            }
        }

        /// <remarks/>
        public string Gender
        {
            get
            {
                return this.genderField;
            }
            set
            {
                this.genderField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportLicense
    {

        private string licenseNumberField;

        private string licenseStateField;

        private string cDLStatusField;

        private byte clientRiskPointsField;

        /// <remarks/>
        public string LicenseNumber
        {
            get
            {
                return this.licenseNumberField;
            }
            set
            {
                this.licenseNumberField = value;
            }
        }

        /// <remarks/>
        public string LicenseState
        {
            get
            {
                return this.licenseStateField;
            }
            set
            {
                this.licenseStateField = value;
            }
        }

        /// <remarks/>
        public string CDLStatus
        {
            get
            {
                return this.cDLStatusField;
            }
            set
            {
                this.cDLStatusField = value;
            }
        }

        /// <remarks/>
        public byte ClientRiskPoints
        {
            get
            {
                return this.clientRiskPointsField;
            }
            set
            {
                this.clientRiskPointsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportError
    {

        private byte codeField;

        private string descriptionField;

        /// <remarks/>
        public byte Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportClasses
    {

        private MVRReportsMVRReportClassesClass classField;

        /// <remarks/>
        public MVRReportsMVRReportClassesClass Class
        {
            get
            {
                return this.classField;
            }
            set
            {
                this.classField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportClassesClass
    {

        private string codeField;

        private string descriptionField;

        private string typeField;

        private string statusField;

        private System.DateTime issueDateField;

        private System.DateTime expirationDateField;

        private object restrictionsField;

        private object endorsementsField;

        /// <remarks/>
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
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
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime IssueDate
        {
            get
            {
                return this.issueDateField;
            }
            set
            {
                this.issueDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime ExpirationDate
        {
            get
            {
                return this.expirationDateField;
            }
            set
            {
                this.expirationDateField = value;
            }
        }

        /// <remarks/>
        public object Restrictions
        {
            get
            {
                return this.restrictionsField;
            }
            set
            {
                this.restrictionsField = value;
            }
        }

        /// <remarks/>
        public object Endorsements
        {
            get
            {
                return this.endorsementsField;
            }
            set
            {
                this.endorsementsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportLicenseComments
    {

        private MVRReportsMVRReportLicenseCommentsLicenseComment licenseCommentField;

        /// <remarks/>
        public MVRReportsMVRReportLicenseCommentsLicenseComment LicenseComment
        {
            get
            {
                return this.licenseCommentField;
            }
            set
            {
                this.licenseCommentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportLicenseCommentsLicenseComment
    {

        private string textField;

        /// <remarks/>
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportAdditionalAlert
    {

        private System.DateTime dateField;

        private string descriptionField;

        private string acknowledgementStatusField;

        private ushort alertIDField;

        private MVRReportsMVRReportAdditionalAlertAttribute[] attributesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime Date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string AcknowledgementStatus
        {
            get
            {
                return this.acknowledgementStatusField;
            }
            set
            {
                this.acknowledgementStatusField = value;
            }
        }

        /// <remarks/>
        public ushort AlertID
        {
            get
            {
                return this.alertIDField;
            }
            set
            {
                this.alertIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Attribute", IsNullable = false)]
        public MVRReportsMVRReportAdditionalAlertAttribute[] Attributes
        {
            get
            {
                return this.attributesField;
            }
            set
            {
                this.attributesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportAdditionalAlertAttribute
    {

        private string typeField;

        private string textField;

        /// <remarks/>
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
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportEmbeddedReports
    {

        private MVRReportsMVRReportEmbeddedReportsEmbeddedReport embeddedReportField;

        /// <remarks/>
        public MVRReportsMVRReportEmbeddedReportsEmbeddedReport EmbeddedReport
        {
            get
            {
                return this.embeddedReportField;
            }
            set
            {
                this.embeddedReportField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MVRReportsMVRReportEmbeddedReportsEmbeddedReport
    {

        private string typeField;

        private string reportTypeField;

        private string dataField;

        /// <remarks/>
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
        public string ReportType
        {
            get
            {
                return this.reportTypeField;
            }
            set
            {
                this.reportTypeField = value;
            }
        }

        /// <remarks/>
        public string Data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }


}



