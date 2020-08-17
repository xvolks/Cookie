namespace Cookie.API.Protocol.Network.Types.Game.Data.Items
{
    using Utils.IO;

    public class GoldItem : Item
    {
        public new const ushort ProtocolId = 123;
        public override ushort TypeID => ProtocolId;
        public ulong Sum { get; set; }

        public GoldItem(ulong sum)
        {
            Sum = sum;
        }

        public GoldItem() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Sum);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Sum = reader.ReadVarUhLong();
        }

    }
}
