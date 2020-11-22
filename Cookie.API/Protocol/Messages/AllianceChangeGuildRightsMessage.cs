using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceChangeGuildRightsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6426;

        public override ushort MessageID => ProtocolId;

        public uint GuildId { get; set; }
        public sbyte Rights { get; set; }
        public AllianceChangeGuildRightsMessage() { }

        public AllianceChangeGuildRightsMessage( uint GuildId, sbyte Rights ){
            this.GuildId = GuildId;
            this.Rights = Rights;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(GuildId);
            writer.WriteSByte(Rights);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildId = reader.ReadVarUhInt();
            Rights = reader.ReadSByte();
        }
    }
}
