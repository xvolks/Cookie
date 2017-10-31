namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeRequestedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5522;
        public override ushort MessageID => ProtocolId;
        public sbyte ExchangeType { get; set; }

        public ExchangeRequestedMessage(sbyte exchangeType)
        {
            ExchangeType = exchangeType;
        }

        public ExchangeRequestedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ExchangeType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExchangeType = reader.ReadSByte();
        }

    }
}
