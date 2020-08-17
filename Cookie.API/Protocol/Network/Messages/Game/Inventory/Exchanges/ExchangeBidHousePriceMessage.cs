namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeBidHousePriceMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5805;
        public override ushort MessageID => ProtocolId;
        public ushort GenId { get; set; }

        public ExchangeBidHousePriceMessage(ushort genId)
        {
            GenId = genId;
        }

        public ExchangeBidHousePriceMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(GenId);
        }

        public override void Deserialize(IDataReader reader)
        {
            GenId = reader.ReadVarUhShort();
        }

    }
}
