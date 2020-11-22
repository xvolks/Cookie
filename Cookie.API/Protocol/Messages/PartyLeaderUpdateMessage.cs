using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyLeaderUpdateMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 5578;

        public override ushort MessageID => ProtocolId;

        public ulong PartyLeaderId { get; set; }
        public PartyLeaderUpdateMessage() { }

        public PartyLeaderUpdateMessage( ulong PartyLeaderId ){
            this.PartyLeaderId = PartyLeaderId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PartyLeaderId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyLeaderId = reader.ReadVarUhLong();
        }
    }
}
