using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceInsiderInfoRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6417;
        public override uint MessageID { get { return ProtocolId; } }

        public AllianceInsiderInfoRequestMessage()
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