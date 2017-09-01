using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildJoinedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5564;

        public GuildJoinedMessage(GuildInformations guildInfo, uint memberRights)
        {
            GuildInfo = guildInfo;
            MemberRights = memberRights;
        }

        public GuildJoinedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public GuildInformations GuildInfo { get; set; }
        public uint MemberRights { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            GuildInfo.Serialize(writer);
            writer.WriteVarUhInt(MemberRights);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
            MemberRights = reader.ReadVarUhInt();
        }
    }
}