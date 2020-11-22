using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterCapabilitiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6339;

        public override ushort MessageID => ProtocolId;

        public uint GuildEmblemSymbolCategories { get; set; }
        public CharacterCapabilitiesMessage() { }

        public CharacterCapabilitiesMessage( uint GuildEmblemSymbolCategories ){
            this.GuildEmblemSymbolCategories = GuildEmblemSymbolCategories;
        }

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
