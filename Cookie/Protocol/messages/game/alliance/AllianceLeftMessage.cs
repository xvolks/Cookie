using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceLeftMessage : NetworkMessage
    {
        public const uint ProtocolId = 6398;
        public override uint MessageID { get { return ProtocolId; } }

        public AllianceLeftMessage()
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