using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismAttackRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6042;
        public override uint MessageID { get { return ProtocolId; } }

        public PrismAttackRequestMessage()
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