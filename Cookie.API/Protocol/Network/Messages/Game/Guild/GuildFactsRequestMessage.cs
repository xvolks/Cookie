namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildFactsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6404;
        public override ushort MessageID => ProtocolId;
        public uint GuildId { get; set; }

        public GuildFactsRequestMessage(uint guildId)
        {
            GuildId = guildId;
        }

        public GuildFactsRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(GuildId);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildId = reader.ReadVarUhInt();
        }

    }
}
