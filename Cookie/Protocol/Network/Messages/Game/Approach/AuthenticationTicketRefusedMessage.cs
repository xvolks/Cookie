using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Approach
{
    internal class AuthenticationTicketRefusedMessage : NetworkMessage
    {
        public const uint ProtocolId = 112;

        public override uint MessageID => ProtocolId;

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