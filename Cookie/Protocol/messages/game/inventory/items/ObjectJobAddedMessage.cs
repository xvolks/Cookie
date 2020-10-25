using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectJobAddedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6014;
        public override uint MessageID { get { return ProtocolId; } }

        public byte JobId = 0;

        public ObjectJobAddedMessage()
        {
        }

        public ObjectJobAddedMessage(
            byte jobId
        )
        {
            JobId = jobId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(JobId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            JobId = reader.ReadByte();
        }
    }
}