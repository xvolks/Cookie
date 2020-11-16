using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GuildInAllianceInformations : GuildInformations
    {
        public new const short ProtocolId = 420;
        public override short TypeId { get { return ProtocolId; } }

        public byte NbMembers = 0;
        public int JoinDate = 0;

        public GuildInAllianceInformations(): base()
        {
        }

        public GuildInAllianceInformations(
            int guildId,
            string guildName,
            byte guildLevel,
            GuildEmblem guildEmblem_,
            byte nbMembers,
            int joinDate
        ): base(
            guildId,
            guildName,
            guildLevel,
            guildEmblem_
        )
        {
            NbMembers = nbMembers;
            JoinDate = joinDate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(NbMembers);
            writer.WriteInt(JoinDate);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            NbMembers = reader.ReadByte();
            JoinDate = reader.ReadInt();
        }
    }
}