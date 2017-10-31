namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildPaddockRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5955;
        public override ushort MessageID => ProtocolId;
        public double PaddockId { get; set; }

        public GuildPaddockRemovedMessage(double paddockId)
        {
            PaddockId = paddockId;
        }

        public GuildPaddockRemovedMessage() { }

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
