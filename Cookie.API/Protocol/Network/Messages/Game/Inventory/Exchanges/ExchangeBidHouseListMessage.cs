namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeBidHouseListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5807;
        public override ushort MessageID => ProtocolId;
        public ushort ObjectId { get; set; }

        public ExchangeBidHouseListMessage(ushort objectId)
        {
            ObjectId = objectId;
        }

        public ExchangeBidHouseListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhShort();
        }

    }
}
