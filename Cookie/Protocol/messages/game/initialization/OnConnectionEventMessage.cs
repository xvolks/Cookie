using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class OnConnectionEventMessage : NetworkMessage
    {
        public const uint ProtocolId = 5726;
        public override uint MessageID { get { return ProtocolId; } }

        public byte EventType = 0;

        public OnConnectionEventMessage()
        {
        }

        public OnConnectionEventMessage(
            byte eventType
        )
        {
            EventType = eventType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(EventType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            EventType = reader.ReadByte();
        }
    }
}