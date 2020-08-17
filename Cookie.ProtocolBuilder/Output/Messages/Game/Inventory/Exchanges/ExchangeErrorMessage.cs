namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5513;
        public override ushort MessageID => ProtocolId;
        public sbyte ErrorType { get; set; }

        public ExchangeErrorMessage(sbyte errorType)
        {
            ErrorType = errorType;
        }

        public ExchangeErrorMessage() { }

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
