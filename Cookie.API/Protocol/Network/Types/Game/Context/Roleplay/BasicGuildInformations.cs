using Cookie.API.Protocol.Network.Types.Game.Social;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class BasicGuildInformations : AbstractSocialGroupInfos
    {
        public new const ushort ProtocolId = 365;

        public BasicGuildInformations(uint guildId, string guildName, byte guildLevel)
        {
            GuildId = guildId;
            GuildName = guildName;
            GuildLevel = guildLevel;
        }

        public BasicGuildInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint GuildId { get; set; }
        public string GuildName { get; set; }
        public byte GuildLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(GuildId);
            writer.WriteUTF(GuildName);
            writer.WriteByte(GuildLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuildId = reader.ReadVarUhInt();
            GuildName = reader.ReadUTF();
            GuildLevel = reader.ReadByte();
        }
    }
}