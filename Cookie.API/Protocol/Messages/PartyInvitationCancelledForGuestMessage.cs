using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyInvitationCancelledForGuestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6256;

        public override ushort MessageID => ProtocolId;

        public ulong CancelerId { get; set; }
        public PartyInvitationCancelledForGuestMessage() { }

        public PartyInvitationCancelledForGuestMessage( ulong CancelerId ){
            this.CancelerId = CancelerId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(CancelerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CancelerId = reader.ReadVarUhLong();
        }
    }
}
