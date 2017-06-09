using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Approach
{
    class AuthenticationTicketRefusedMessage : NetworkMessage
    {
        public const uint ProtocolId = 112;
        public override uint MessageID { get { return ProtocolId; } }

        public AuthenticationTicketRefusedMessage() { }

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
