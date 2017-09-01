namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeBidHouseGenericItemAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5947;
        public override ushort MessageID => ProtocolId;
        public ushort ObjGenericId { get; set; }

        public ExchangeBidHouseGenericItemAddedMessage(ushort objGenericId)
        {
            ObjGenericId = objGenericId;
        }

        public ExchangeBidHouseGenericItemAddedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjGenericId = reader.ReadVarUhShort();
        }

    }
}
