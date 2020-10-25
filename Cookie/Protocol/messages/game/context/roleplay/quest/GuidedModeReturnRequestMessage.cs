using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuidedModeReturnRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6088;
        public override uint MessageID { get { return ProtocolId; } }

        public GuidedModeReturnRequestMessage()
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