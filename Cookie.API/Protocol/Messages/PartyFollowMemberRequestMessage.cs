using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyFollowMemberRequestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5577;

        public override ushort MessageID => ProtocolId;

        public ulong PlayerId { get; set; }
        public PartyFollowMemberRequestMessage() { }

        public PartyFollowMemberRequestMessage( ulong PlayerId ){
            this.PlayerId = PlayerId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
        }
    }
}
