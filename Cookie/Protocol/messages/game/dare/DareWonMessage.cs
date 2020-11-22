using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DareWonMessage : NetworkMessage
    {
        public const uint ProtocolId = 6681;
        public override uint MessageID { get { return ProtocolId; } }

        public double DareId = 0;

        public DareWonMessage()
        {
        }

        public DareWonMessage(
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