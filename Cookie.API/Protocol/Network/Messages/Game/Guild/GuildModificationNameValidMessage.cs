using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildModificationNameValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6327;

        public GuildModificationNameValidMessage(string guildName)
        {
            GuildName = guildName;
        }

        public GuildModificationNameValidMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string GuildName { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(GuildName);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildName = reader.ReadUTF();
        }
    }
}