namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeItemAutoCraftStopedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5810;
        public override ushort MessageID => ProtocolId;
        public sbyte Reason { get; set; }

        public ExchangeItemAutoCraftStopedMessage(sbyte reason)
        {
            Reason = reason;
        }

        public ExchangeItemAutoCraftStopedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadSByte();
        }

    }
}
