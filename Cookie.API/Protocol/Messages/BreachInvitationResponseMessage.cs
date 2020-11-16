using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachInvitationResponseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6792;

        public override ushort MessageID => ProtocolId;

        public CharacterMinimalInformations Guest { get; set; }
        public bool Accept { get; set; }
        public BreachInvitationResponseMessage() { }

        public BreachInvitationResponseMessage( CharacterMinimalInformations Guest, bool Accept ){
            this.Guest = Guest;
            this.Accept = Accept;
        }

        public override void Serialize(IDataWriter writer)
        {
            Guest.Serialize(writer);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            Guest = new CharacterMinimalInformations();
            Guest.Deserialize(reader);
            Accept = reader.ReadBoolean();
        }
    }
}
