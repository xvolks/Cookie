using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeWaitingResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 5786;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Bwait = false;

        public ExchangeWaitingResultMessage()
        {
        }

        public ExchangeWaitingResultMessage(
            bool bwait
        )
        {
            Bwait = bwait;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Bwait);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Bwait = reader.ReadBoolean();
        }
    }
}