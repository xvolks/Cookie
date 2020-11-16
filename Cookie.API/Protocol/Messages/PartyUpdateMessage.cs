using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyUpdateMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 5575;

        public override ushort MessageID => ProtocolId;

        public PartyMemberInformations MemberInformations { get; set; }
        public PartyUpdateMessage() { }

        public PartyUpdateMessage( PartyMemberInformations MemberInformations ){
            this.MemberInformations = MemberInformations;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            MemberInformations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MemberInformations = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            MemberInformations.Deserialize(reader);
        }
    }
}
