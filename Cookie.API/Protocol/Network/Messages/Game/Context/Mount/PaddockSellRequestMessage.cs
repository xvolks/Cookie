namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class PaddockSellRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5953;
        public override ushort MessageID => ProtocolId;
        public ulong Price { get; set; }
        public bool ForSale { get; set; }

        public PaddockSellRequestMessage(ulong price, bool forSale)
        {
            Price = price;
            ForSale = forSale;
        }

        public PaddockSellRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Price);
            writer.WriteBoolean(ForSale);
        }

        public override void Deserialize(IDataReader reader)
        {
            Price = reader.ReadVarUhLong();
            ForSale = reader.ReadBoolean();
        }

    }
}
