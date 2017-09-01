namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeBidPriceMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5755;
        public override ushort MessageID => ProtocolId;
        public ushort GenericId { get; set; }
        public long AveragePrice { get; set; }

        public ExchangeBidPriceMessage(ushort genericId, long averagePrice)
        {
            GenericId = genericId;
            AveragePrice = averagePrice;
        }

        public ExchangeBidPriceMessage() { }

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
