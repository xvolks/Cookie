namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeStartOkCraftMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5813;
        public override ushort MessageID => ProtocolId;

        public ExchangeStartOkCraftMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
