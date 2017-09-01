using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5512;

        public ExchangeStartedMessage(sbyte exchangeType)
        {
            ExchangeType = exchangeType;
        }

        public ExchangeStartedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public sbyte ExchangeType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ExchangeType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExchangeType = reader.ReadSByte();
        }
    }
}