using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GuildInformations : BasicGuildInformations
    {
        public new const ushort ProtocolId = 127;

        public override ushort TypeID => ProtocolId;

        public GuildEmblem GuildEmblem { get; set; }
        public GuildInformations() { }

        public GuildInformations( GuildEmblem GuildEmblem ){
            this.GuildEmblem = GuildEmblem;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            GuildEmblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuildEmblem = new GuildEmblem();
            GuildEmblem.Deserialize(reader);
        }
    }
}
