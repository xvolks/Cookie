namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeCraftCountModifiedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6595;
        public override ushort MessageID => ProtocolId;
        public int Count { get; set; }

        public ExchangeCraftCountModifiedMessage(int count)
        {
            Count = count;
        }

        public ExchangeCraftCountModifiedMessage() { }

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
