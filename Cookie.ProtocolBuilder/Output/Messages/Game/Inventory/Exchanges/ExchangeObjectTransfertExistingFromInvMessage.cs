namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeObjectTransfertExistingFromInvMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6325;
        public override ushort MessageID => ProtocolId;

        public ExchangeObjectTransfertExistingFromInvMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
