using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AuthenticationTicketAcceptedMessage : NetworkMessage
    {
        public const uint ProtocolId = 111;
        public override uint MessageID { get { return ProtocolId; } }

        public AuthenticationTicketAcceptedMessage()
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