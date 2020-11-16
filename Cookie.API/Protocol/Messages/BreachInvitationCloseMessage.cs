using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachInvitationCloseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6790;

        public override ushort MessageID => ProtocolId;

        public CharacterMinimalInformations Host { get; set; }
        public BreachInvitationCloseMessage() { }

        public BreachInvitationCloseMessage( CharacterMinimalInformations Host ){
            this.Host = Host;
        }

        public override void Serialize(IDataWriter writer)
        {
            Host.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Host = new CharacterMinimalInformations();
            Host.Deserialize(reader);
        }
    }
}
