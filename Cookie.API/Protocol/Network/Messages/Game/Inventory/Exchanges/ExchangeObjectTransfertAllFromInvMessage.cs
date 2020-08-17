namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeObjectTransfertAllFromInvMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6184;
        public override ushort MessageID => ProtocolId;

        public ExchangeObjectTransfertAllFromInvMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
