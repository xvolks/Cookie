namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Utils.IO;

    public class GameRolePlayTaxCollectorFightRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5954;
        public override ushort MessageID => ProtocolId;
        public double TaxCollectorId { get; set; }

        public GameRolePlayTaxCollectorFightRequestMessage(double taxCollectorId)
        {
            TaxCollectorId = taxCollectorId;
        }

        public GameRolePlayTaxCollectorFightRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(TaxCollectorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TaxCollectorId = reader.ReadDouble();
        }

    }
}
