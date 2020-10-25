using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterCapabilitiesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6339;
        public override uint MessageID { get { return ProtocolId; } }

        public int GuildEmblemSymbolCategories = 0;

        public CharacterCapabilitiesMessage()
        {
        }

        public CharacterCapabilitiesMessage(
            int guildEmblemSymbolCategories
        )
        {
            GuildEmblemSymbolCategories = guildEmblemSymbolCategories;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(GuildEmblemSymbolCategories);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuildEmblemSymbolCategories = reader.ReadVarInt();
        }
    }
}