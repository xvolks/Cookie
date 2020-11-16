using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class BasicGuildInformations : AbstractSocialGroupInfos
    {
        public new const ushort ProtocolId = 365;

        public override ushort TypeID => ProtocolId;

        public uint GuildId { get; set; }
        public string GuildName { get; set; }
        public byte GuildLevel { get; set; }
        public BasicGuildInformations() { }

        public BasicGuildInformations( uint GuildId, string GuildName, byte GuildLevel ){
            this.GuildId = GuildId;
            this.GuildName = GuildName;
            this.GuildLevel = GuildLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(GuildId);
            writer.WriteUTF(GuildName);
            writer.WriteByte(GuildLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuildId = reader.ReadVarUhInt();
            GuildName = reader.ReadUTF();
            GuildLevel = reader.ReadByte();
        }
    }
}
