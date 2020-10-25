using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceCreationStartedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6394;
        public override uint MessageID { get { return ProtocolId; } }

        public AllianceCreationStartedMessage()
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