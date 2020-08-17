namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountReleasedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6308;
        public override ushort MessageID => ProtocolId;
        public int MountId { get; set; }

        public MountReleasedMessage(int mountId)
        {
            MountId = mountId;
        }

        public MountReleasedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountId = reader.ReadVarInt();
        }

    }
}
