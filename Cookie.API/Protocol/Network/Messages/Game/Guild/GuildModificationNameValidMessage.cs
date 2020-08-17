namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildModificationNameValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6327;
        public override ushort MessageID => ProtocolId;
        public string GuildName { get; set; }

        public GuildModificationNameValidMessage(string guildName)
        {
            GuildName = guildName;
        }

        public GuildModificationNameValidMessage() { }

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
