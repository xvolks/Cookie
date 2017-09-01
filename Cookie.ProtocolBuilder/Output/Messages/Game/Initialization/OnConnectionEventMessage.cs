namespace Cookie.API.Protocol.Network.Messages.Game.Initialization
{
    using Utils.IO;

    public class OnConnectionEventMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5726;
        public override ushort MessageID => ProtocolId;
        public byte EventType { get; set; }

        public OnConnectionEventMessage(byte eventType)
        {
            EventType = eventType;
        }

        public OnConnectionEventMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(EventType);
        }

        public override void Deserialize(IDataReader reader)
        {
            EventType = reader.ReadByte();
        }

    }
}
