namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildLevelUpMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6062;
        public override ushort MessageID => ProtocolId;
        public byte NewLevel { get; set; }

        public GuildLevelUpMessage(byte newLevel)
        {
            NewLevel = newLevel;
        }

        public GuildLevelUpMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(NewLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            NewLevel = reader.ReadByte();
        }

    }
}
