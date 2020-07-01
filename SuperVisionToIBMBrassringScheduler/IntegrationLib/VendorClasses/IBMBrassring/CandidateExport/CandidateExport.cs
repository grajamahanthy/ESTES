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
    public partial class SUPERVISION_CANDIDATE
    {

        private uint cANDIDATEIDField;

        private object rEQUISITIONNUMBERField;

        private string bRREQNUMBERField;

        private string jOBCODEField;

        private string sTATUSField;

        private string lEGALFNAMEField;

        private string lEGALLNAMEField;

        private string lEGALMNAMEField;

        private string mVRDLNUMBERField;

        private string mVRSUPSTATEField;

        private string mVRREPORTTYPEField;

        private System.DateTime mVRDOBField;

        private ushort mVRSSN4Field;

        private string mVRSTATEField;

        /// <remarks/>
        public uint CANDIDATEID
        {
            get
            {
                return this.cANDIDATEIDField;
            }
            set
            {
                this.cANDIDATEIDField = value;
            }
        }

        /// <remarks/>
        public object REQUISITIONNUMBER
        {
            get
            {
                return this.rEQUISITIONNUMBERField;
            }
            set
            {
                this.rEQUISITIONNUMBERField = value;
            }
        }

        /// <remarks/>
        public string BRREQNUMBER
        {
            get
            {
                return this.bRREQNUMBERField;
            }
            set
            {
                this.bRREQNUMBERField = value;
            }
        }

        /// <remarks/>
        public string JOBCODE
        {
            get
            {
                return this.jOBCODEField;
            }
            set
            {
                this.jOBCODEField = value;
            }
        }

        /// <remarks/>
        public string STATUS
        {
            get
            {
                return this.sTATUSField;
            }
            set
            {
                this.sTATUSField = value;
            }
        }

        /// <remarks/>
        public string LEGALFNAME
        {
            get
            {
                return this.lEGALFNAMEField;
            }
            set
            {
                this.lEGALFNAMEField = value;
            }
        }

        /// <remarks/>
        public string LEGALLNAME
        {
            get
            {
                return this.lEGALLNAMEField;
            }
            set
            {
                this.lEGALLNAMEField = value;
            }
        }

        /// <remarks/>
        public string LEGALMNAME
        {
            get
            {
                return this.lEGALMNAMEField;
            }
            set
            {
                this.lEGALMNAMEField = value;
            }
        }

        /// <remarks/>
        public string MVRDLNUMBER
        {
            get
            {
                return this.mVRDLNUMBERField;
            }
            set
            {
                this.mVRDLNUMBERField = value;
            }
        }

        /// <remarks/>
        public string MVRSUPSTATE
        {
            get
            {
                return this.mVRSUPSTATEField;
            }
            set
            {
                this.mVRSUPSTATEField = value;
            }
        }

        /// <remarks/>
        public string MVRREPORTTYPE
        {
            get
            {
                return this.mVRREPORTTYPEField;
            }
            set
            {
                this.mVRREPORTTYPEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime MVRDOB
        {
            get
            {
                return this.mVRDOBField;
            }
            set
            {
                this.mVRDOBField = value;
            }
        }

        /// <remarks/>
        public ushort MVRSSN4
        {
            get
            {
                return this.mVRSSN4Field;
            }
            set
            {
                this.mVRSSN4Field = value;
            }
        }

        /// <remarks/>
        public string MVRSTATE
        {
            get
            {
                return this.mVRSTATEField;
            }
            set
            {
                this.mVRSTATEField = value;
            }
        }
    }
}
