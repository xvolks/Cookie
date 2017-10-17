using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class GameRolePlayTaxCollectorFightRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5954;

        public GameRolePlayTaxCollectorFightRequestMessage(double taxCollectorId)
        {
            TaxCollectorId = taxCollectorId;
        }

        public GameRolePlayTaxCollectorFightRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TaxCollectorId { get; set; }

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