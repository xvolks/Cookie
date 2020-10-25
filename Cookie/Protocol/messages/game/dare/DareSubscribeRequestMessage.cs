using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DareSubscribeRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6666;
        public override uint MessageID { get { return ProtocolId; } }

        public double DareId = 0;
        public bool Subscribe = false;

        public DareSubscribeRequestMessage()
        {
        }

        public DareSubscribeRequestMessage(
            double dareId,
            bool subscribe
        )
        {
            DareId = dareId;
            Subscribe = subscribe;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteBoolean(Subscribe);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DareId = reader.ReadDouble();
            Subscribe = reader.ReadBoolean();
        }
    }
}