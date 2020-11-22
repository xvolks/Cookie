using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PlayerStatusUpdateErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6385;
        public override uint MessageID { get { return ProtocolId; } }

        public PlayerStatusUpdateErrorMessage()
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