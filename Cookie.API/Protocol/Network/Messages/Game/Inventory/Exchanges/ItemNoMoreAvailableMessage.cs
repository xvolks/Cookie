namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ItemNoMoreAvailableMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5769;
        public override ushort MessageID => ProtocolId;

        public ItemNoMoreAvailableMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
