namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeStartOkRunesTradeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6567;
        public override ushort MessageID => ProtocolId;

        public ExchangeStartOkRunesTradeMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
