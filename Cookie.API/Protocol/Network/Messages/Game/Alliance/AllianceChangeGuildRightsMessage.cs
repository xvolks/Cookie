namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Utils.IO;

    public class AllianceChangeGuildRightsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6426;
        public override ushort MessageID => ProtocolId;
        public uint GuildId { get; set; }
        public byte Rights { get; set; }

        public AllianceChangeGuildRightsMessage(uint guildId, byte rights)
        {
            GuildId = guildId;
            Rights = rights;
        }

        public AllianceChangeGuildRightsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(GuildId);
            writer.WriteByte(Rights);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildId = reader.ReadVarUhInt();
            Rights = reader.ReadByte();
        }

    }
}
