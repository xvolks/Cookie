using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Queues
{
    public class LoginQueueStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 10;
        public override uint MessageID { get { return ProtocolId; } }

        public ushort Position;
        public ushort Total;

        public LoginQueueStatusMessage() { }

        public LoginQueueStatusMessage(ushort position, ushort total)
        {
            Position = position;
            Total = total;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Position);
            writer.WriteShort((short)Total);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Position = reader.ReadUShort();
            Total = reader.ReadUShort();
        }
    }
}
