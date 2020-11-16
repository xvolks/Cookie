using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CurrentServerStatusUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6525;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Status = 1;

        public CurrentServerStatusUpdateMessage()
        {
        }

        public CurrentServerStatusUpdateMessage(
            byte status
        )
        {
            Status = status;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Status);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Status = reader.ReadByte();
        }
    }
}