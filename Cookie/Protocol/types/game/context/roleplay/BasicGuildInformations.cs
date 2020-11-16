using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class BasicGuildInformations : AbstractSocialGroupInfos
    {
        public new const short ProtocolId = 365;
        public override short TypeId { get { return ProtocolId; } }

        public int GuildId = 0;
        public string GuildName;
        public byte GuildLevel = 0;

        public BasicGuildInformations(): base()
        {
        }

        public BasicGuildInformations(
            int guildId,
            string guildName,
            byte guildLevel
        ): base()
        {
            GuildId = guildId;
            GuildName = guildName;
            GuildLevel = guildLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(GuildId);
            writer.WriteUTF(GuildName);
            writer.WriteByte(GuildLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            GuildId = reader.ReadVarInt();
            GuildName = reader.ReadUTF();
            GuildLevel = reader.ReadByte();
        }
    }
}