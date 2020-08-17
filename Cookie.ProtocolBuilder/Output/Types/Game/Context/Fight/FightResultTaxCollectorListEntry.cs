namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
    {
        public new const ushort ProtocolId = 84;
        public override ushort TypeID => ProtocolId;
        public byte Level { get; set; }
        public BasicGuildInformations GuildInfo { get; set; }
        public int ExperienceForGuild { get; set; }

        public FightResultTaxCollectorListEntry(byte level, BasicGuildInformations guildInfo, int experienceForGuild)
        {
            Level = level;
            GuildInfo = guildInfo;
            ExperienceForGuild = experienceForGuild;
        }

        public FightResultTaxCollectorListEntry() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Level);
            GuildInfo.Serialize(writer);
            writer.WriteInt(ExperienceForGuild);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadByte();
            GuildInfo = new BasicGuildInformations();
            GuildInfo.Deserialize(reader);
            ExperienceForGuild = reader.ReadInt();
        }

    }
}
