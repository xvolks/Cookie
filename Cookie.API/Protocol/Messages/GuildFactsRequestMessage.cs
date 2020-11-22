using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildFactsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6404;

        public override ushort MessageID => ProtocolId;

        public uint GuildId { get; set; }
        public GuildFactsRequestMessage() { }

        public GuildFactsRequestMessage( uint GuildId ){
            this.GuildId = GuildId;
        }

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
