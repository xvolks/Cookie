using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GuildFactSheetInformations : GuildInformations
    {
        public new const ushort ProtocolId = 424;

        public override ushort TypeID => ProtocolId;

        public ulong LeaderId { get; set; }
        public ushort NbMembers { get; set; }
        public GuildFactSheetInformations() { }

        public GuildFactSheetInformations( ulong LeaderId, ushort NbMembers ){
            this.LeaderId = LeaderId;
            this.NbMembers = NbMembers;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(LeaderId);
            writer.WriteVarUhShort(NbMembers);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LeaderId = reader.ReadVarUhLong();
            NbMembers = reader.ReadVarUhShort();
        }
    }
}
