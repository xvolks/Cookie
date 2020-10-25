using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
    {
        public new const short ProtocolId = 84;
        public override short TypeId { get { return ProtocolId; } }

        public byte Level = 0;
        public BasicGuildInformations GuildInfo;
        public int ExperienceForGuild = 0;

        public FightResultTaxCollectorListEntry(): base()
        {
        }

        public FightResultTaxCollectorListEntry(
            short outcome,
            byte wave,
            FightLoot rewards,
            double id_,
            bool alive,
            byte level,
            BasicGuildInformations guildInfo,
            int experienceForGuild
        ): base(
            outcome,
            wave,
            rewards,
            id_,
            alive
        )
        {
            Level = level;
            GuildInfo = guildInfo;
            ExperienceForGuild = experienceForGuild;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Level);
            GuildInfo.Serialize(writer);
            writer.WriteInt(ExperienceForGuild);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadByte();
            GuildInfo = new BasicGuildInformations();
            GuildInfo.Deserialize(reader);
            ExperienceForGuild = reader.ReadInt();
        }
    }
}