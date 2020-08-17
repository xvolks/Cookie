namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountEmoteIconUsedOkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5978;
        public override ushort MessageID => ProtocolId;
        public int MountId { get; set; }
        public byte ReactionType { get; set; }

        public MountEmoteIconUsedOkMessage(int mountId, byte reactionType)
        {
            MountId = mountId;
            ReactionType = reactionType;
        }

        public MountEmoteIconUsedOkMessage() { }

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
