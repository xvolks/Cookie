namespace Cookie.API.Protocol.Network.Types.Game.Data.Items
{
    using Utils.IO;

    public class ObjectItemGenericQuantity : Item
    {
        public new const ushort ProtocolId = 483;
        public override ushort TypeID => ProtocolId;
        public ushort ObjectGID { get; set; }
        public uint Quantity { get; set; }

        public ObjectItemGenericQuantity(ushort objectGID, uint quantity)
        {
            ObjectGID = objectGID;
            Quantity = quantity;
        }

        public ObjectItemGenericQuantity() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ObjectGID);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarUhShort();
            Quantity = reader.ReadVarUhInt();
        }

    }
}
