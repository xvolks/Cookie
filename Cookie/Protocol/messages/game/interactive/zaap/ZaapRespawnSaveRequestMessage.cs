using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ZaapRespawnSaveRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6572;
        public override uint MessageID { get { return ProtocolId; } }

        public ZaapRespawnSaveRequestMessage()
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