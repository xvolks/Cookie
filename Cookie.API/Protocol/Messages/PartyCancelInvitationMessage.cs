using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyCancelInvitationMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6254;

        public override ushort MessageID => ProtocolId;

        public ulong GuestId { get; set; }
        public PartyCancelInvitationMessage() { }

        public PartyCancelInvitationMessage( ulong GuestId ){
            this.GuestId = GuestId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(GuestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuestId = reader.ReadVarUhLong();
        }
    }
}
