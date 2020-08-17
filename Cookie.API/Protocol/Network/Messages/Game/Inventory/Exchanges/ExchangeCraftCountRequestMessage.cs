namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeCraftCountRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6597;
        public override ushort MessageID => ProtocolId;
        public int Count { get; set; }

        public ExchangeCraftCountRequestMessage(int count)
        {
            Count = count;
        }

        public ExchangeCraftCountRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(Count);
        }

        public override void Deserialize(IDataReader reader)
        {
            Count = reader.ReadVarInt();
        }

    }
}
