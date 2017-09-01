namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Types.Game.Guild;
    using Utils.IO;

    public class GuildModificationEmblemValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6328;
        public override ushort MessageID => ProtocolId;
        public GuildEmblem GuildEmblem { get; set; }

        public GuildModificationEmblemValidMessage(GuildEmblem guildEmblem)
        {
            GuildEmblem = guildEmblem;
        }

        public GuildModificationEmblemValidMessage() { }

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
