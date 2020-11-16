using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyMemberRemoveMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 5579;

        public override ushort MessageID => ProtocolId;

        public ulong LeavingPlayerId { get; set; }
        public PartyMemberRemoveMessage() { }

        public PartyMemberRemoveMessage( ulong LeavingPlayerId ){
            this.LeavingPlayerId = LeavingPlayerId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(LeavingPlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LeavingPlayerId = reader.ReadVarUhLong();
        }
    }
}
