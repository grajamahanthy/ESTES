using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLib.VendorClasses.IBMBrassring
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Candidate
    {

        private CandidateCandidateRecordInfo candidateRecordInfoField;

        private CandidateCandidateSupplier candidateSupplierField;

        private CandidateCandidateProfile candidateProfileField;

        /// <remarks/>
        public CandidateCandidateRecordInfo CandidateRecordInfo
        {
            get
            {
                return this.candidateRecordInfoField;
            }
            set
            {
                this.candidateRecordInfoField = value;
            }
        }

        /// <remarks/>
        public CandidateCandidateSupplier CandidateSupplier
        {
            get
            {
                return this.candidateSupplierField;
            }
            set
            {
                this.candidateSupplierField = value;
            }
        }

        /// <remarks/>
        public CandidateCandidateProfile CandidateProfile
        {
            get
            {
                return this.candidateProfileField;
            }
            set
            {
                this.candidateProfileField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CandidateCandidateRecordInfo
    {

        private CandidateCandidateRecordInfoID idField;

        private string statusField;

        /// <remarks/>
        public CandidateCandidateRecordInfoID Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CandidateCandidateRecordInfoID
    {

        private int idValueField;

        private string idOwnerField;

        /// <remarks/>
        public int IdValue
        {
            get
            {
                return this.idValueField;
            }
            set
            {
                this.idValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string idOwner
        {
            get
            {
                return this.idOwnerField;
            }
            set
            {
                this.idOwnerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CandidateCandidateSupplier
    {

        private CandidateCandidateSupplierSupplierId supplierIdField;

        private object entityNameField;

        private string relationshipField;

        /// <remarks/>
        public CandidateCandidateSupplierSupplierId SupplierId
        {
            get
            {
                return this.supplierIdField;
            }
            set
            {
                this.supplierIdField = value;
            }
        }

        /// <remarks/>
        public object EntityName
        {
            get
            {
                return this.entityNameField;
            }
            set
            {
                this.entityNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string relationship
        {
            get
            {
                return this.relationshipField;
            }
            set
            {
                this.relationshipField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CandidateCandidateSupplierSupplierId
    {

        private string idValueField;

        /// <remarks/>
        public string IdValue
        {
            get
            {
                return this.idValueField;
            }
            set
            {
                this.idValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CandidateCandidateProfile
    {

        private CandidateCandidateProfilePersonalData personalDataField;

        private CandidateCandidateProfileUserArea userAreaField;

        private string langField;

        /// <remarks/>
        public CandidateCandidateProfilePersonalData PersonalData
        {
            get
            {
                return this.personalDataField;
            }
            set
            {
                this.personalDataField = value;
            }
        }

        /// <remarks/>
        public CandidateCandidateProfileUserArea UserArea
        {
            get
            {
                return this.userAreaField;
            }
            set
            {
                this.userAreaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CandidateCandidateProfilePersonalData
    {

        private CandidateCandidateProfilePersonalDataPersonName personNameField;

        private CandidateCandidateProfilePersonalDataContactMethod contactMethodField;

        /// <remarks/>
        public CandidateCandidateProfilePersonalDataPersonName PersonName
        {
            get
            {
                return this.personNameField;
            }
            set
            {
                this.personNameField = value;
            }
        }

        /// <remarks/>
        public CandidateCandidateProfilePersonalDataContactMethod ContactMethod
        {
            get
            {
                return this.contactMethodField;
            }
            set
            {
                this.contactMethodField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CandidateCandidateProfilePersonalDataPersonName
    {

        private string givenNameField;

        private object middleNameField;

        private string familyNameField;

        /// <remarks/>
        public string GivenName
        {
            get
            {
                return this.givenNameField;
            }
            set
            {
                this.givenNameField = value;
            }
        }

        /// <remarks/>
        public object MiddleName
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
        public string FamilyName
        {
            get
            {
                return this.familyNameField;
            }
            set
            {
                this.familyNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CandidateCandidateProfilePersonalDataContactMethod
    {

        private string locationField;

        private CandidateCandidateProfilePersonalDataContactMethodPostalAddress postalAddressField;

        /// <remarks/>
        public string Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        public CandidateCandidateProfilePersonalDataContactMethodPostalAddress PostalAddress
        {
            get
            {
                return this.postalAddressField;
            }
            set
            {
                this.postalAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CandidateCandidateProfilePersonalDataContactMethodPostalAddress
    {

        private string countryCodeField;

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CandidateCandidateProfileUserArea
    {

        private string[] codesField;

        private string candidatetypeField;

        private attachments attachmentsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://trm.brassring.com/brpartner")]
        [System.Xml.Serialization.XmlArrayItemAttribute("code", IsNullable = false)]
        public string[] codes
        {
            get
            {
                return this.codesField;
            }
            set
            {
                this.codesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://trm.brassring.com/brpartner")]
        public string candidatetype
        {
            get
            {
                return this.candidatetypeField;
            }
            set
            {
                this.candidatetypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://trm.brassring.com/brpartner")]
        public attachments attachments
        {
            get
            {
                return this.attachmentsField;
            }
            set
            {
                this.attachmentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://trm.brassring.com/brpartner")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://trm.brassring.com/brpartner", IsNullable = false)]
    public partial class attachments
    {

        private attachmentsAttachment attachmentField;

        /// <remarks/>
        public attachmentsAttachment attachment
        {
            get
            {
                return this.attachmentField;
            }
            set
            {
                this.attachmentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://trm.brassring.com/brpartner")]
    public partial class attachmentsAttachment
    {

        private string documentguidField;

        private string filenameField;

        private string fileextnField;

        private ushort acategoryidField;

        private string fileField;

        private attachmentsAttachmentReqs reqsField;

        private string attachtoreqsField;

        /// <remarks/>
        public string documentguid
        {
            get
            {
                return this.documentguidField;
            }
            set
            {
                this.documentguidField = value;
            }
        }

        /// <remarks/>
        public string filename
        {
            get
            {
                return this.filenameField;
            }
            set
            {
                this.filenameField = value;
            }
        }

        /// <remarks/>
        public string fileextn
        {
            get
            {
                return this.fileextnField;
            }
            set
            {
                this.fileextnField = value;
            }
        }

        /// <remarks/>
        public ushort acategoryid
        {
            get
            {
                return this.acategoryidField;
            }
            set
            {
                this.acategoryidField = value;
            }
        }

        /// <remarks/>
        public string file
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
        public attachmentsAttachmentReqs reqs
        {
            get
            {
                return this.reqsField;
            }
            set
            {
                this.reqsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string attachtoreqs
        {
            get
            {
                return this.attachtoreqsField;
            }
            set
            {
                this.attachtoreqsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://trm.brassring.com/brpartner")]
    public partial class attachmentsAttachmentReqs
    {

        private string reqcodeField;

        /// <remarks/>
        public string reqcode
        {
            get
            {
                return this.reqcodeField;
            }
            set
            {
                this.reqcodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://trm.brassring.com/brpartner")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://trm.brassring.com/brpartner", IsNullable = false)]
    public partial class codes
    {

        private string[] codeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("code")]
        public string[] code
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
    }


}
