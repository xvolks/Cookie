using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class NpcDialogReplyMessage : NetworkMessage
    {
        public const uint ProtocolId = 5616;
        public override uint MessageID { get { return ProtocolId; } }

        public int ReplyId = 0;

        public NpcDialogReplyMessage()
        {
        }

        public NpcDialogReplyMessage(
            int replyId
        )
        {
            ReplyId = replyId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ReplyId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ReplyId = reader.ReadVarInt();
        }
    }
}