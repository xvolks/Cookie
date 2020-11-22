using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildModificationValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6323;

        public override ushort MessageID => ProtocolId;

        public string GuildName { get; set; }
        public GuildEmblem GuildEmblem { get; set; }
        public GuildModificationValidMessage() { }

        public GuildModificationValidMessage( string GuildName, GuildEmblem GuildEmblem ){
            this.GuildName = GuildName;
            this.GuildEmblem = GuildEmblem;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(GuildName);
            GuildEmblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildName = reader.ReadUTF();
            GuildEmblem = new GuildEmblem();
            GuildEmblem.Deserialize(reader);
        }
    }
}
