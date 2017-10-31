namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeSellOkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5792;
        public override ushort MessageID => ProtocolId;

        public ExchangeSellOkMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
