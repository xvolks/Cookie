namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Types.Game.Guild;
    using Utils.IO;

    public class GuildCreationValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5546;
        public override ushort MessageID => ProtocolId;
        public string GuildName { get; set; }
        public GuildEmblem GuildEmblem { get; set; }

        public GuildCreationValidMessage(string guildName, GuildEmblem guildEmblem)
        {
            GuildName = guildName;
            GuildEmblem = guildEmblem;
        }

        public GuildCreationValidMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(GuildName);
            GuildEmblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildName = reader.ReadUTF();
            GuildEmblem = new GuildEmblem();
            GuildEmblem.Deserialize(reader);
        }

    }
}
