using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GuildFactSheetInformations : GuildInformations
    {
        public new const short ProtocolId = 424;
        public override short TypeId { get { return ProtocolId; } }

        public long LeaderId = 0;
        public short NbMembers = 0;

        public GuildFactSheetInformations(): base()
        {
        }

        public GuildFactSheetInformations(
            int guildId,
            string guildName,
            byte guildLevel,
            GuildEmblem guildEmblem_,
            long leaderId,
            short nbMembers
        ): base(
            guildId,
            guildName,
            guildLevel,
            guildEmblem_
        )
        {
            LeaderId = leaderId;
            NbMembers = nbMembers;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(LeaderId);
            writer.WriteVarShort(NbMembers);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            LeaderId = reader.ReadVarLong();
            NbMembers = reader.ReadVarShort();
        }
    }
}