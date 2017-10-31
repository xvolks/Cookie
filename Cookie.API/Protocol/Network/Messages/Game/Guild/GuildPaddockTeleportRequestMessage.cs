namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildPaddockTeleportRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5957;
        public override ushort MessageID => ProtocolId;
        public double PaddockId { get; set; }

        public GuildPaddockTeleportRequestMessage(double paddockId)
        {
            PaddockId = paddockId;
        }

        public GuildPaddockTeleportRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(PaddockId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockId = reader.ReadDouble();
        }

    }
}
