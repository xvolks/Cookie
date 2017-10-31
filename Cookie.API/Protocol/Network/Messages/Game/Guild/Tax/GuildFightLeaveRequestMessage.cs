namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Utils.IO;

    public class GuildFightLeaveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5715;
        public override ushort MessageID => ProtocolId;
        public double TaxCollectorId { get; set; }
        public ulong CharacterId { get; set; }

        public GuildFightLeaveRequestMessage(double taxCollectorId, ulong characterId)
        {
            TaxCollectorId = taxCollectorId;
            CharacterId = characterId;
        }

        public GuildFightLeaveRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(TaxCollectorId);
            writer.WriteVarUhLong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TaxCollectorId = reader.ReadDouble();
            CharacterId = reader.ReadVarUhLong();
        }

    }
}
