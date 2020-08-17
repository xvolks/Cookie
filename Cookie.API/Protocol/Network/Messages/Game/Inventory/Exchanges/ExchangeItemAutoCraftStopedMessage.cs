using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeItemAutoCraftStopedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5810;

        public ExchangeItemAutoCraftStopedMessage(sbyte reason)
        {
            Reason = reason;
        }

        public ExchangeItemAutoCraftStopedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public sbyte Reason { get; set; }

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