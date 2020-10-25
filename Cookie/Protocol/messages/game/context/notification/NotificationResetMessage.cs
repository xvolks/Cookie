using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class NotificationResetMessage : NetworkMessage
    {
        public const uint ProtocolId = 6089;
        public override uint MessageID { get { return ProtocolId; } }

        public NotificationResetMessage()
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