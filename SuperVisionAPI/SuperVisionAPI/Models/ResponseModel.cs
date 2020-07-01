using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperVisionAPI.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Envelope
    {

        private EnvelopeSender senderField;

        private EnvelopePacket packetField;

        private EnvelopeRecipient recipientField;

        private EnvelopeTransactInfo transactInfoField;

        private decimal versionField;

        /// <remarks/>
        public EnvelopeSender Sender
        {
            get
            {
                return this.senderField;
            }
            set
            {
                this.senderField = value;
            }
        }

        /// <remarks/>
        public EnvelopePacket Packet
        {
            get
            {
                return this.packetField;
            }
            set
            {
                this.packetField = value;
            }
        }

        /// <remarks/>
        public EnvelopeRecipient Recipient
        {
            get
            {
                return this.recipientField;
            }
            set
            {
                this.recipientField = value;
            }
        }

        /// <remarks/>
        public EnvelopeTransactInfo TransactInfo
        {
            get
            {
                return this.transactInfoField;
            }
            set
            {
                this.transactInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeSender
    {

        private string idField;

        private string credentialField;

        /// <remarks/>
        public string Id
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
        public string Credential
        {
            get
            {
                return this.credentialField;
            }
            set
            {
                this.credentialField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopePacket
    {

        private EnvelopePacketPacketInfo packetInfoField;

        private object payloadField;

        /// <remarks/>
        public EnvelopePacketPacketInfo PacketInfo
        {
            get
            {
                return this.packetInfoField;
            }
            set
            {
                this.packetInfoField = value;
            }
        }

        /// <remarks/>
        public object Payload
        {
            get
            {
                return this.payloadField;
            }
            set
            {
                this.payloadField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopePacketPacketInfo
    {

        private byte packetIdField;

        private string actionField;

        private string manifestField;

        private EnvelopePacketPacketInfoStatus statusField;

        private string packetTypeField;

        /// <remarks/>
        public byte PacketId
        {
            get
            {
                return this.packetIdField;
            }
            set
            {
                this.packetIdField = value;
            }
        }

        /// <remarks/>
        public string Action
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
        public string Manifest
        {
            get
            {
                return this.manifestField;
            }
            set
            {
                this.manifestField = value;
            }
        }

        /// <remarks/>
        public EnvelopePacketPacketInfoStatus Status
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string packetType
        {
            get
            {
                return this.packetTypeField;
            }
            set
            {
                this.packetTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopePacketPacketInfoStatus
    {

        private ushort codeField;

        private string shortDescriptionField;

        private string longDescriptionField;

        /// <remarks/>
        public ushort Code
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
        public string ShortDescription
        {
            get
            {
                return this.shortDescriptionField;
            }
            set
            {
                this.shortDescriptionField = value;
            }
        }

        /// <remarks/>
        public string LongDescription
        {
            get
            {
                return this.longDescriptionField;
            }
            set
            {
                this.longDescriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeRecipient
    {

        private object idField;

        /// <remarks/>
        public object Id
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeTransactInfo
    {

        private object transactIdField;

        private string timeStampField;

        private EnvelopeTransactInfoStatus statusField;

        private string transactTypeField;

        /// <remarks/>
        public object TransactId
        {
            get
            {
                return this.transactIdField;
            }
            set
            {
                this.transactIdField = value;
            }
        }

        /// <remarks/>
        public string TimeStamp
        {
            get
            {
                return this.timeStampField;
            }
            set
            {
                this.timeStampField = value;
            }
        }

        /// <remarks/>
        public EnvelopeTransactInfoStatus Status
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string transactType
        {
            get
            {
                return this.transactTypeField;
            }
            set
            {
                this.transactTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EnvelopeTransactInfoStatus
    {

        private ushort codeField;

        private string shortDescriptionField;

        private string longDescriptionField;

        /// <remarks/>
        public ushort Code
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
        public string ShortDescription
        {
            get
            {
                return this.shortDescriptionField;
            }
            set
            {
                this.shortDescriptionField = value;
            }
        }

        /// <remarks/>
        public string LongDescription
        {
            get
            {
                return this.longDescriptionField;
            }
            set
            {
                this.longDescriptionField = value;
            }
        }
    }


}