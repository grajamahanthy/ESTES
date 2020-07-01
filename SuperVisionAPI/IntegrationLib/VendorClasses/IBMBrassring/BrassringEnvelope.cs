using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib.VendorClasses.IBMBrassring

{

    public class CandidateImportEnvelope
    {
        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://trm.brassring.com/brpartner")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://trm.brassring.com/brpartner", IsNullable = false)]
        public class Envelope
        {

            private Sender senderField;

            private Recipient recipientField;

            private TransactInfo transactInfoField;

            private Packet packetField;

            private decimal versionField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public Sender Sender
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
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public Recipient Recipient
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
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public TransactInfo TransactInfo
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
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public Packet Packet
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
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Sender
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
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Recipient
        {

            private RecipientID idField;

            /// <remarks/>
            public RecipientID id
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
        public partial class RecipientID
        {

            private string typeField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string type
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

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class TransactInfo
        {

            private string transactIdField;

            private string timeStampField;

            private string transactTypeField;

            /// <remarks/>
            public string transactId
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
            public string timeStamp
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
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Packet
        {

            private PacketPacketInfo packetInfoField;

            private string payloadField;

            /// <remarks/>
            public PacketPacketInfo PacketInfo
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
            public string Payload
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
        public partial class PacketPacketInfo
        {

            private byte packetIdField;

            private string actionField;

            private string manifestField;

            private string packetTypeField;

            /// <remarks/>
            public byte packetId
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
    }

    public class FormImportEnvelope
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

            private EnvelopeRecipient recipientField;

            private EnvelopeTransactInfo transactInfoField;

            private EnvelopePacket packetField;

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

            private ushort credentialField;

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
            public ushort Credential
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

            private ushort transactIdField;

            private string timeStampField;

            private string transactTypeField;

            /// <remarks/>
            public ushort TransactId
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


    }

}
