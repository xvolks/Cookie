using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DareCancelRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6680;
        public override uint MessageID { get { return ProtocolId; } }

        public double DareId = 0;

        public DareCancelRequestMessage()
        {
        }

        public DareCancelRequestMessage(
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