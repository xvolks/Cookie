using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatSmileyRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 800;
        public override uint MessageID { get { return ProtocolId; } }

        public short SmileyId = 0;

        public ChatSmileyRequestMessage()
        {
        }

        public ChatSmileyRequestMessage(
            short smileyId
        )
        {
            SmileyId = smileyId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SmileyId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SmileyId = reader.ReadVarShort();
        }
    }
}