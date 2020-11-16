using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildModificationNameValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6327;

        public override ushort MessageID => ProtocolId;

        public string GuildName { get; set; }
        public GuildModificationNameValidMessage() { }

        public GuildModificationNameValidMessage( string GuildName ){
            this.GuildName = GuildName;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(GuildName);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildName = reader.ReadUTF();
        }
    }
}
