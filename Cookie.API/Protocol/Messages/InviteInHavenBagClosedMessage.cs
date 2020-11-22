using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class InviteInHavenBagClosedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6645;

        public override ushort MessageID => ProtocolId;

        public CharacterMinimalInformations HostInformations { get; set; }
        public InviteInHavenBagClosedMessage() { }

        public InviteInHavenBagClosedMessage( CharacterMinimalInformations HostInformations ){
            this.HostInformations = HostInformations;
        }

        public override void Serialize(IDataWriter writer)
        {
            HostInformations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            HostInformations = new CharacterMinimalInformations();
            HostInformations.Deserialize(reader);
        }
    }
}
