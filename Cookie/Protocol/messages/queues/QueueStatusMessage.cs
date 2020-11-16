using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class QueueStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6100;
        public override uint MessageID { get { return ProtocolId; } }

        public short Position = 0;
        public short Total = 0;

        public QueueStatusMessage()
        {
        }

        public QueueStatusMessage(
            short position,
            short total
        )
        {
            Position = position;
            Total = total;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Position);
            writer.WriteShort(Total);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Position = reader.ReadShort();
            Total = reader.ReadShort();
        }
    }
}