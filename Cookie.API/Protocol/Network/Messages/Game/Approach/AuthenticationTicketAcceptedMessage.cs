using Cookie.API.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Approach
{
    public class AuthenticationTicketAcceptedMessage : NetworkMessage
    {
        public const uint ProtocolId = 111;

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