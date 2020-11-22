using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyInvitationDungeonRequestMessage : PartyInvitationRequestMessage
    {
        public new const ushort ProtocolId = 6245;

        public override ushort MessageID => ProtocolId;

        public ushort DungeonId { get; set; }
        public PartyInvitationDungeonRequestMessage() { }

        public PartyInvitationDungeonRequestMessage( ushort DungeonId ){
            this.DungeonId = DungeonId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(DungeonId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DungeonId = reader.ReadVarUhShort();
        }
    }
}
