using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GuildVersatileInformations : NetworkType
    {
        public const short ProtocolId = 435;
        public override short TypeId { get { return ProtocolId; } }

        public int GuildId = 0;
        public long LeaderId = 0;
        public byte GuildLevel = 0;
        public byte NbMembers = 0;

        public GuildVersatileInformations()
        {
        }

        public GuildVersatileInformations(
            int guildId,
            long leaderId,
            byte guildLevel,
            byte nbMembers
        )
        {
            GuildId = guildId;
            LeaderId = leaderId;
            GuildLevel = guildLevel;
            NbMembers = nbMembers;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(GuildId);
            writer.WriteVarLong(LeaderId);
            writer.WriteByte(GuildLevel);
            writer.WriteByte(NbMembers);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuildId = reader.ReadVarInt();
            LeaderId = reader.ReadVarLong();
            GuildLevel = reader.ReadByte();
            NbMembers = reader.ReadByte();
        }
    }
}