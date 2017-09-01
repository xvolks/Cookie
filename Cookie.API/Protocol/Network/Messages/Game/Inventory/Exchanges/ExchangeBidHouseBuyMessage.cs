using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidHouseBuyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5804;

        public ExchangeBidHouseBuyMessage(uint uid, uint qty, ulong price)
        {
            Uid = uid;
            Qty = qty;
            Price = price;
        }

        public ExchangeBidHouseBuyMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint Uid { get; set; }
        public uint Qty { get; set; }
        public ulong Price { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Uid);
            writer.WriteVarUhInt(Qty);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadVarUhInt();
            Qty = reader.ReadVarUhInt();
            Price = reader.ReadVarUhLong();
        }
    }
}