using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildLevelUpMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6062;

        public override ushort MessageID => ProtocolId;

        public byte NewLevel { get; set; }
        public GuildLevelUpMessage() { }

        public GuildLevelUpMessage( byte NewLevel ){
            this.NewLevel = NewLevel;
        }

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
