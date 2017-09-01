namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Utils.IO;

    public class GuildFightJoinRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5717;
        public override ushort MessageID => ProtocolId;
        public int TaxCollectorId { get; set; }

        public GuildFightJoinRequestMessage(int taxCollectorId)
        {
            TaxCollectorId = taxCollectorId;
        }

        public GuildFightJoinRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(TaxCollectorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TaxCollectorId = reader.ReadInt();
        }

    }
}
