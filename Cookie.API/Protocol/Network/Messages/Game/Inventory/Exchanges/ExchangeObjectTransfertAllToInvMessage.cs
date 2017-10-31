namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeObjectTransfertAllToInvMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6032;
        public override ushort MessageID => ProtocolId;

        public ExchangeObjectTransfertAllToInvMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
