using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatAdminServerMessage : ChatServerMessage
    {
        public new const uint ProtocolId = 6135;
        public override uint MessageID { get { return ProtocolId; } }

        public ChatAdminServerMessage(): base()
        {
        }

        public ChatAdminServerMessage(
            byte channel,
            string content,
            int timestamp,
            string fingerprint,
            double senderId,
            string senderName,
            string prefix,
            int senderAccountId
        ): base(
            channel,
            content,
            timestamp,
            fingerprint,
            senderId,
            senderName,
            prefix,
            senderAccountId
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}