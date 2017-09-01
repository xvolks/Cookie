using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class PaddockSellRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5953;

        public PaddockSellRequestMessage(ulong price, bool forSale)
        {
            Price = price;
            ForSale = forSale;
        }

        public PaddockSellRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong Price { get; set; }
        public bool ForSale { get; set; }

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