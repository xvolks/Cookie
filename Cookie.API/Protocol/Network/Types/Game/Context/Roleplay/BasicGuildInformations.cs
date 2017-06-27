using Cookie.API.Protocol.Network.Types.Game.Social;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class BasicGuildInformations : AbstractSocialGroupInfos
    {
        public new const short ProtocolId = 365;

        public uint GuildId;
        public sbyte GuildLevel;
        public string GuildName;

        public BasicGuildInformations()
        {
        }

        public BasicGuildInformations(uint guildId, string guildName, sbyte guildLevel)
        {
            GuildId = guildId;
            GuildName = guildName;
            GuildLevel = guildLevel;
        }

        public override short TypeID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(GuildId);
            writer.WriteUTF(GuildName);
            writer.WriteSByte(GuildLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuildId = reader.ReadVarUhInt();
            GuildName = reader.ReadUTF();
            GuildLevel = reader.ReadSByte();
        }
    }
}