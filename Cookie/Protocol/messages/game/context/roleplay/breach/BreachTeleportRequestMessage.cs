using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachTeleportRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6817;
        public override uint MessageID { get { return ProtocolId; } }

        public BreachTeleportRequestMessage()
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