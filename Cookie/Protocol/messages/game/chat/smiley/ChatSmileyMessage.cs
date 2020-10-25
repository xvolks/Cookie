using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatSmileyMessage : NetworkMessage
    {
        public const uint ProtocolId = 801;
        public override uint MessageID { get { return ProtocolId; } }

        public double EntityId = 0;
        public short SmileyId = 0;
        public int AccountId = 0;

        public ChatSmileyMessage()
        {
        }

        public ChatSmileyMessage(
            double entityId,
            short smileyId,
            int accountId
        )
        {
            EntityId = entityId;
            SmileyId = smileyId;
            AccountId = accountId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(EntityId);
            writer.WriteVarShort(SmileyId);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            EntityId = reader.ReadDouble();
            SmileyId = reader.ReadVarShort();
            AccountId = reader.ReadInt();
        }
    }
}