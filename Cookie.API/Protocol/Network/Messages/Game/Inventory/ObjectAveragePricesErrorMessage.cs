namespace Cookie.API.Protocol.Network.Messages.Game.Inventory
{
    using Utils.IO;

    public class ObjectAveragePricesErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6336;
        public override ushort MessageID => ProtocolId;

        public ObjectAveragePricesErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
