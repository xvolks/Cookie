using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightTeamMemberTaxCollectorInformations : FightTeamMemberInformations
    {
        public new const ushort ProtocolId = 177;

        public FightTeamMemberTaxCollectorInformations(ushort firstNameId, ushort lastNameId, byte level, uint guildId,
            uint uid)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            Level = level;
            GuildId = guildId;
            Uid = uid;
        }

        public FightTeamMemberTaxCollectorInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public byte Level { get; set; }
        public uint GuildId { get; set; }
        public uint Uid { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
            writer.WriteByte(Level);
            writer.WriteVarUhInt(GuildId);
            writer.WriteVarUhInt(Uid);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
            Level = reader.ReadByte();
            GuildId = reader.ReadVarUhInt();
            Uid = reader.ReadVarUhInt();
        }
    }
}