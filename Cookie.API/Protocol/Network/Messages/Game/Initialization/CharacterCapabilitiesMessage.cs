using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Initialization
{
    public class CharacterCapabilitiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6339;

        public CharacterCapabilitiesMessage(uint guildEmblemSymbolCategories)
        {
            GuildEmblemSymbolCategories = guildEmblemSymbolCategories;
        }

        public CharacterCapabilitiesMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint GuildEmblemSymbolCategories { get; set; }

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