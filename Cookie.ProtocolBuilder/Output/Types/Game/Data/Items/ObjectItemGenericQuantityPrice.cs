namespace Cookie.API.Protocol.Network.Types.Game.Data.Items
{
    using Utils.IO;

    public class ObjectItemGenericQuantityPrice : ObjectItemGenericQuantity
    {
        public new const ushort ProtocolId = 494;
        public override ushort TypeID => ProtocolId;
        public ulong Price { get; set; }

        public ObjectItemGenericQuantityPrice(ulong price)
        {
            Price = price;
        }

        public ObjectItemGenericQuantityPrice() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Price = reader.ReadVarUhLong();
        }

    }
}
