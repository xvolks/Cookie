using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GuildVersatileInformations : NetworkType
    {
        public const ushort ProtocolId = 435;

        public override ushort TypeID => ProtocolId;

        public uint GuildId { get; set; }
        public ulong LeaderId { get; set; }
        public byte GuildLevel { get; set; }
        public byte NbMembers { get; set; }
        public GuildVersatileInformations() { }

        public GuildVersatileInformations( uint GuildId, ulong LeaderId, byte GuildLevel, byte NbMembers ){
            this.GuildId = GuildId;
            this.LeaderId = LeaderId;
            this.GuildLevel = GuildLevel;
            this.NbMembers = NbMembers;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(GuildId);
            writer.WriteVarUhLong(LeaderId);
            writer.WriteByte(GuildLevel);
            writer.WriteByte(NbMembers);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildId = reader.ReadVarUhInt();
            LeaderId = reader.ReadVarUhLong();
            GuildLevel = reader.ReadByte();
            NbMembers = reader.ReadByte();
        }
    }
}
