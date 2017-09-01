namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeBidHouseSearchMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5806;
        public override ushort MessageID => ProtocolId;
        public uint Type { get; set; }
        public ushort GenId { get; set; }

        public ExchangeBidHouseSearchMessage(uint type, ushort genId)
        {
            Type = type;
            GenId = genId;
        }

        public ExchangeBidHouseSearchMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Type);
            writer.WriteVarUhShort(GenId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadVarUhInt();
            GenId = reader.ReadVarUhShort();
        }

    }
}
