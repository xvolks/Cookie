using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Queues
{
    public class QueueStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6100;
        public override uint MessageID { get { return ProtocolId; } }

        public ushort Position;
        public ushort Total;

        public QueueStatusMessage() { }

        public QueueStatusMessage(ushort position, ushort total)
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
