using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    public class GuildFactSheetInformations : GuildInformations
    {
        public new const ushort ProtocolId = 424;

        public GuildFactSheetInformations(ulong leaderId, ushort nbMembers)
        {
            LeaderId = leaderId;
            NbMembers = nbMembers;
        }

        public GuildFactSheetInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ulong LeaderId { get; set; }
        public ushort NbMembers { get; set; }

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