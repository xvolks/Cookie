using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeRequestOnTaxCollectorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5779;

        public ExchangeRequestOnTaxCollectorMessage(int taxCollectorId)
        {
            TaxCollectorId = taxCollectorId;
        }

        public ExchangeRequestOnTaxCollectorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int TaxCollectorId { get; set; }

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