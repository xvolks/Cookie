using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DareCanceledMessage : NetworkMessage
    {
        public const uint ProtocolId = 6679;
        public override uint MessageID { get { return ProtocolId; } }

        public double DareId = 0;

        public DareCanceledMessage()
        {
        }

        public DareCanceledMessage(
            double dareId
        )
        {
            DareId = dareId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(DareId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DareId = reader.ReadDouble();
        }
    }
}