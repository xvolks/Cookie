using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeReplayStopMessage : NetworkMessage
    {
        public const uint ProtocolId = 6001;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeReplayStopMessage()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
        }

        public override void Deserialize(ICustomDataInput reader)
        {
        }
    }
}