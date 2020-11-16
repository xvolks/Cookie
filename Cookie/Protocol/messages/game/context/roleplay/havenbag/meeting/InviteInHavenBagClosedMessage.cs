using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class InviteInHavenBagClosedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6645;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterMinimalInformations HostInformations;

        public InviteInHavenBagClosedMessage()
        {
        }

        public InviteInHavenBagClosedMessage(
            CharacterMinimalInformations hostInformations
        )
        {
            HostInformations = hostInformations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            HostInformations.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HostInformations = new CharacterMinimalInformations();
            HostInformations.Deserialize(reader);
        }
    }
}