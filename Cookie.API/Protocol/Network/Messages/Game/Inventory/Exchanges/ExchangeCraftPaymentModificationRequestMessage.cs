using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeCraftPaymentModificationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6579;

        public ExchangeCraftPaymentModificationRequestMessage(ulong quantity)
        {
            Quantity = quantity;
        }

        public ExchangeCraftPaymentModificationRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            Quantity = reader.ReadVarUhLong();
        }
    }
}