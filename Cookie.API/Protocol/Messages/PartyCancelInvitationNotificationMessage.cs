using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyCancelInvitationNotificationMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 6251;

        public override ushort MessageID => ProtocolId;

        public ulong CancelerId { get; set; }
        public ulong GuestId { get; set; }
        public PartyCancelInvitationNotificationMessage() { }

        public PartyCancelInvitationNotificationMessage( ulong CancelerId, ulong GuestId ){
            this.CancelerId = CancelerId;
            this.GuestId = GuestId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(CancelerId);
            writer.WriteVarUhLong(GuestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CancelerId = reader.ReadVarUhLong();
            GuestId = reader.ReadVarUhLong();
        }
    }
}
