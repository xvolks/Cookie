using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class MountEmoteIconUsedOkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5978;

        public MountEmoteIconUsedOkMessage(int mountId, byte reactionType)
        {
            MountId = mountId;
            ReactionType = reactionType;
        }

        public MountEmoteIconUsedOkMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int MountId { get; set; }
        public byte ReactionType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MountId);
            writer.WriteByte(ReactionType);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountId = reader.ReadVarInt();
            ReactionType = reader.ReadByte();
        }
    }
}