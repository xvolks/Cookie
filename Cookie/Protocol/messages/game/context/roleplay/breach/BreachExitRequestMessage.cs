using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachExitRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6815;
        public override uint MessageID { get { return ProtocolId; } }

        public BreachExitRequestMessage()
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