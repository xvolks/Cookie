namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountSterilizedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5977;
        public override ushort MessageID => ProtocolId;
        public int MountId { get; set; }

        public MountSterilizedMessage(int mountId)
        {
            MountId = mountId;
        }

        public MountSterilizedMessage() { }

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
