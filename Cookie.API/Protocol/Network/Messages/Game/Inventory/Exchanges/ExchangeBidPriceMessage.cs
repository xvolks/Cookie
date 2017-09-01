using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidPriceMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5755;

        public ExchangeBidPriceMessage(ushort genericId, long averagePrice)
        {
            GenericId = genericId;
            AveragePrice = averagePrice;
        }

        public ExchangeBidPriceMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort GenericId { get; set; }
        public long AveragePrice { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(GenericId);
            writer.WriteVarLong(AveragePrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            GenericId = reader.ReadVarUhShort();
            AveragePrice = reader.ReadVarLong();
        }
    }
}