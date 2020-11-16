using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ResetCharacterStatsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6739;
        public override uint MessageID { get { return ProtocolId; } }

        public ResetCharacterStatsRequestMessage()
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