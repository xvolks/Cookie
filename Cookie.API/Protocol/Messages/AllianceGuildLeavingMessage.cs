using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceGuildLeavingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6399;

        public override ushort MessageID => ProtocolId;

        public bool Kicked { get; set; }
        public uint GuildId { get; set; }
        public AllianceGuildLeavingMessage() { }

        public AllianceGuildLeavingMessage( bool Kicked, uint GuildId ){
            this.Kicked = Kicked;
            this.GuildId = GuildId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Kicked);
            writer.WriteVarUhInt(GuildId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Kicked = reader.ReadBoolean();
            GuildId = reader.ReadVarUhInt();
        }
    }
}
