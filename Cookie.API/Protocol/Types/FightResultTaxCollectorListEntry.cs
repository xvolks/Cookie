using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
    {
        public new const ushort ProtocolId = 84;

        public override ushort TypeID => ProtocolId;

        public byte Level { get; set; }
        public BasicGuildInformations GuildInfo { get; set; }
        public int ExperienceForGuild { get; set; }
        public FightResultTaxCollectorListEntry() { }

        public FightResultTaxCollectorListEntry( byte Level, BasicGuildInformations GuildInfo, int ExperienceForGuild ){
            this.Level = Level;
            this.GuildInfo = GuildInfo;
            this.ExperienceForGuild = ExperienceForGuild;
        }

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
