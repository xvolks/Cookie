using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightTeamMemberCompanionInformations : FightTeamMemberInformations
    {
        public new const ushort ProtocolId = 451;

        public FightTeamMemberCompanionInformations(byte companionId, byte level, double masterId)
        {
            CompanionId = companionId;
            Level = level;
            MasterId = masterId;
        }

        public FightTeamMemberCompanionInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte CompanionId { get; set; }
        public byte Level { get; set; }
        public double MasterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(CompanionId);
            writer.WriteByte(Level);
            writer.WriteDouble(MasterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CompanionId = reader.ReadByte();
            Level = reader.ReadByte();
            MasterId = reader.ReadDouble();
        }
    }
}