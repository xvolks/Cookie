namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeObjectTransfertExistingToInvMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6326;
        public override ushort MessageID => ProtocolId;

        public ExchangeObjectTransfertExistingToInvMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
