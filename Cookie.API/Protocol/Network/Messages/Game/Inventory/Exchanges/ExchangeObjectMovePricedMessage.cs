using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeObjectMovePricedMessage : ExchangeObjectMoveMessage
    {
        public new const ushort ProtocolId = 5514;

        public ExchangeObjectMovePricedMessage(ulong price)
        {
            Price = price;
        }

        public ExchangeObjectMovePricedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong Price { get; set; }

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