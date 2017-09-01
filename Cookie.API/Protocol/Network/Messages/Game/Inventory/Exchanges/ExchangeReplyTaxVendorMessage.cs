using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeReplyTaxVendorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5787;

        public ExchangeReplyTaxVendorMessage(ulong objectValue, ulong totalTaxValue)
        {
            ObjectValue = objectValue;
            TotalTaxValue = totalTaxValue;
        }

        public ExchangeReplyTaxVendorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong ObjectValue { get; set; }
        public ulong TotalTaxValue { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ObjectValue);
            writer.WriteVarUhLong(TotalTaxValue);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectValue = reader.ReadVarUhLong();
            TotalTaxValue = reader.ReadVarUhLong();
        }
    }
}