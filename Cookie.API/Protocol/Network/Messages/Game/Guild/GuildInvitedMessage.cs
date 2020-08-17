using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildInvitedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5552;

        public GuildInvitedMessage(ulong recruterId, string recruterName, BasicGuildInformations guildInfo)
        {
            RecruterId = recruterId;
            RecruterName = recruterName;
            GuildInfo = guildInfo;
        }

        public GuildInvitedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong RecruterId { get; set; }
        public string RecruterName { get; set; }
        public BasicGuildInformations GuildInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(RecruterId);
            writer.WriteUTF(RecruterName);
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            RecruterId = reader.ReadVarUhLong();
            RecruterName = reader.ReadUTF();
            GuildInfo = new BasicGuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}