using Cookie.API.Protocol.Network.Types.Game.Guild;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildModificationEmblemValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6328;

        public GuildModificationEmblemValidMessage(GuildEmblem guildEmblem)
        {
            GuildEmblem = guildEmblem;
        }

        public GuildModificationEmblemValidMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public GuildEmblem GuildEmblem { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            GuildEmblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildEmblem = new GuildEmblem();
            GuildEmblem.Deserialize(reader);
        }
    }
}