using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5513;

        public ExchangeErrorMessage(sbyte errorType)
        {
            ErrorType = errorType;
        }

        public ExchangeErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public sbyte ErrorType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ErrorType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ErrorType = reader.ReadSByte();
        }
    }
}