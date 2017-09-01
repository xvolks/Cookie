namespace Cookie.API.Protocol.Network.Messages.Game.Initialization
{
    using Utils.IO;

    public class CharacterCapabilitiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6339;
        public override ushort MessageID => ProtocolId;
        public uint GuildEmblemSymbolCategories { get; set; }

        public CharacterCapabilitiesMessage(uint guildEmblemSymbolCategories)
        {
            GuildEmblemSymbolCategories = guildEmblemSymbolCategories;
        }

        public CharacterCapabilitiesMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(GuildEmblemSymbolCategories);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildEmblemSymbolCategories = reader.ReadVarUhInt();
        }

    }
}
