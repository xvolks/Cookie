using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Queues
{
    public class QueueStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6100;

        public QueueStatusMessage(ushort position, ushort total)
        {
            Position = position;
            Total = total;
        }

        public QueueStatusMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort Position { get; set; }
        public ushort Total { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Position);
            writer.WriteUShort(Total);
        }

        public override void Deserialize(IDataReader reader)
        {
            Position = reader.ReadUShort();
            Total = reader.ReadUShort();
        }
    }
}