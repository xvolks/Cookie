using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AnomalyStateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6831;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Open = false;
        public long ClosingTime = 0;

        public AnomalyStateMessage()
        {
        }

        public AnomalyStateMessage(
            bool open,
            long closingTime
        )
        {
            Open = open;
            ClosingTime = closingTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Open);
            writer.WriteVarLong(ClosingTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Open = reader.ReadBoolean();
            ClosingTime = reader.ReadVarLong();
        }
    }
}