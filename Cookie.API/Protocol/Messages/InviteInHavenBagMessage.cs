using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class InviteInHavenBagMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6642;

        public override ushort MessageID => ProtocolId;

        public CharacterMinimalInformations GuestInformations { get; set; }
        public bool Accept { get; set; }
        public InviteInHavenBagMessage() { }

        public InviteInHavenBagMessage( CharacterMinimalInformations GuestInformations, bool Accept ){
            this.GuestInformations = GuestInformations;
            this.Accept = Accept;
        }

        public override void Serialize(IDataWriter writer)
        {
            GuestInformations.Serialize(writer);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuestInformations = new CharacterMinimalInformations();
            GuestInformations.Deserialize(reader);
            Accept = reader.ReadBoolean();
        }
    }
}
