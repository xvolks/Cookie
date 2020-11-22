using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountEmoteIconUsedOkMessage : NetworkMessage
    {
        public const uint ProtocolId = 5978;
        public override uint MessageID { get { return ProtocolId; } }

        public int MountId = 0;
        public byte ReactionType = 0;

        public MountEmoteIconUsedOkMessage()
        {
        }

        public MountEmoteIconUsedOkMessage(
            int mountId,
            byte reactionType
        )
        {
            MountId = mountId;
            ReactionType = reactionType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(MountId);
            writer.WriteByte(ReactionType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MountId = reader.ReadVarInt();
            ReactionType = reader.ReadByte();
        }
    }
}