using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatServerMessage : ChatAbstractServerMessage
    {
        public new const uint ProtocolId = 881;
        public override uint MessageID { get { return ProtocolId; } }

        public double SenderId = 0;
        public string SenderName;
        public string Prefix;
        public int SenderAccountId = 0;

        public ChatServerMessage(): base()
        {
        }

        public ChatServerMessage(
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
            fingerprint
        )
        {
            SenderId = senderId;
            SenderName = senderName;
            Prefix = prefix;
            SenderAccountId = senderAccountId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(SenderId);
            writer.WriteUTF(SenderName);
            writer.WriteUTF(Prefix);
            writer.WriteInt(SenderAccountId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            SenderId = reader.ReadDouble();
            SenderName = reader.ReadUTF();
            Prefix = reader.ReadUTF();
            SenderAccountId = reader.ReadInt();
        }
    }
}