using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeObjectMoveKamaMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5520;

        public ExchangeObjectMoveKamaMessage(long quantity)
        {
            Quantity = quantity;
        }

        public ExchangeObjectMoveKamaMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public long Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            Quantity = reader.ReadVarLong();
        }
    }
}