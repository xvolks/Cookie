using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildModificationEmblemValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6328;

        public override ushort MessageID => ProtocolId;

        public GuildEmblem GuildEmblem { get; set; }
        public GuildModificationEmblemValidMessage() { }

        public GuildModificationEmblemValidMessage( GuildEmblem GuildEmblem ){
            this.GuildEmblem = GuildEmblem;
        }

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
