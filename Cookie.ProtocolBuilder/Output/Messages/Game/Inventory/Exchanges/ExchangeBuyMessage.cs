namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeBuyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5774;
        public override ushort MessageID => ProtocolId;
        public uint ObjectToBuyId { get; set; }
        public uint Quantity { get; set; }

        public ExchangeBuyMessage(uint objectToBuyId, uint quantity)
        {
            ObjectToBuyId = objectToBuyId;
            Quantity = quantity;
        }

        public ExchangeBuyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectToBuyId);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectToBuyId = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
        }

    }
}
