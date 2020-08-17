namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeBidHouseGenericItemRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5948;
        public override ushort MessageID => ProtocolId;
        public ushort ObjGenericId { get; set; }

        public ExchangeBidHouseGenericItemRemovedMessage(ushort objGenericId)
        {
            ObjGenericId = objGenericId;
        }

        public ExchangeBidHouseGenericItemRemovedMessage() { }

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
