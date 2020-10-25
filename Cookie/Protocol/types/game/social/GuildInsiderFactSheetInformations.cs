using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GuildInsiderFactSheetInformations : GuildFactSheetInformations
    {
        public new const short ProtocolId = 423;
        public override short TypeId { get { return ProtocolId; } }

        public string LeaderName;
        public short NbConnectedMembers = 0;
        public byte NbTaxCollectors = 0;
        public int LastActivity = 0;

        public GuildInsiderFactSheetInformations(): base()
        {
        }

        public GuildInsiderFactSheetInformations(
            int guildId,
            string guildName,
            byte guildLevel,
            GuildEmblem guildEmblem_,
            long leaderId,
            short nbMembers,
            string leaderName,
            short nbConnectedMembers,
            byte nbTaxCollectors,
            int lastActivity
        ): base(
            guildId,
            guildName,
            guildLevel,
            guildEmblem_,
            leaderId,
            nbMembers
        )
        {
            LeaderName = leaderName;
            NbConnectedMembers = nbConnectedMembers;
            NbTaxCollectors = nbTaxCollectors;
            LastActivity = lastActivity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(LeaderName);
            writer.WriteVarShort(NbConnectedMembers);
            writer.WriteByte(NbTaxCollectors);
            writer.WriteInt(LastActivity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            LeaderName = reader.ReadUTF();
            NbConnectedMembers = reader.ReadVarShort();
            NbTaxCollectors = reader.ReadByte();
            LastActivity = reader.ReadInt();
        }
    }
}