using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    public class GuildVersatileInformations : NetworkType
    {
        public const ushort ProtocolId = 435;

        public GuildVersatileInformations(uint guildId, ulong leaderId, byte guildLevel, byte nbMembers)
        {
            GuildId = guildId;
            LeaderId = leaderId;
            GuildLevel = guildLevel;
            NbMembers = nbMembers;
        }

        public GuildVersatileInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint GuildId { get; set; }
        public ulong LeaderId { get; set; }
        public byte GuildLevel { get; set; }
        public byte NbMembers { get; set; }

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