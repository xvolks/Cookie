using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Approach
{
    public class AuthenticationTicketAcceptedMessage : NetworkMessage
    {
        public const uint ProtocolId = 111;
        public override uint MessageID { get { return ProtocolId; } }

        public AuthenticationTicketAcceptedMessage() { }

        public override void Serialize(ICustomDataOutput writer)
        {
            //
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            //
        }
    }
}
