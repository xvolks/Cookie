using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatServerCopyMessage : ChatAbstractServerMessage
    {
        public new const uint ProtocolId = 882;
        public override uint MessageID { get { return ProtocolId; } }

        public long ReceiverId = 0;
        public string ReceiverName;

        public ChatServerCopyMessage(): base()
        {
        }

        public ChatServerCopyMessage(
            byte channel,
            string content,
            int timestamp,
            string fingerprint,
            long receiverId,
            string receiverName
        ): base(
            channel,
            content,
            timestamp,
            fingerprint
        )
        {
            ReceiverId = receiverId;
            ReceiverName = receiverName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(ReceiverId);
            writer.WriteUTF(ReceiverName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ReceiverId = reader.ReadVarLong();
            ReceiverName = reader.ReadUTF();
        }
    }
}