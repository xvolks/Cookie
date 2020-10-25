using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AnomalySubareaInformationRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6835;
        public override uint MessageID { get { return ProtocolId; } }

        public AnomalySubareaInformationRequestMessage()
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