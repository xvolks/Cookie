using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuidedModeQuitRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6092;
        public override uint MessageID { get { return ProtocolId; } }

        public GuidedModeQuitRequestMessage()
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