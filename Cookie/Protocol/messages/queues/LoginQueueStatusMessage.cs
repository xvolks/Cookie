using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LoginQueueStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 10;
        public override uint MessageID { get { return ProtocolId; } }

        public short Position = 0;
        public short Total = 0;

        public LoginQueueStatusMessage()
        {
        }

        public LoginQueueStatusMessage(
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