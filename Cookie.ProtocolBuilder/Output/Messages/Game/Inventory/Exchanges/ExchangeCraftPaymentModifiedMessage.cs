namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeCraftPaymentModifiedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6578;
        public override ushort MessageID => ProtocolId;
        public ulong GoldSum { get; set; }

        public ExchangeCraftPaymentModifiedMessage(ulong goldSum)
        {
            GoldSum = goldSum;
        }

        public ExchangeCraftPaymentModifiedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(GoldSum);
        }

        public override void Deserialize(IDataReader reader)
        {
            GoldSum = reader.ReadVarUhLong();
        }

    }
}
