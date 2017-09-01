namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeObjectMoveKamaMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5520;
        public override ushort MessageID => ProtocolId;
        public long Quantity { get; set; }

        public ExchangeObjectMoveKamaMessage(long quantity)
        {
            Quantity = quantity;
        }

        public ExchangeObjectMoveKamaMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            Quantity = reader.ReadVarLong();
        }

    }
}
