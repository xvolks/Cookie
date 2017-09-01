using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class AbstractFightTeamInformations : NetworkType
    {
        public const ushort ProtocolId = 116;

        public AbstractFightTeamInformations(byte teamId, double leaderId, sbyte teamSide, byte teamTypeId,
            byte nbWaves)
        {
            TeamId = teamId;
            LeaderId = leaderId;
            TeamSide = teamSide;
            TeamTypeId = teamTypeId;
            NbWaves = nbWaves;
        }

        public AbstractFightTeamInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte TeamId { get; set; }
        public double LeaderId { get; set; }
        public sbyte TeamSide { get; set; }
        public byte TeamTypeId { get; set; }
        public byte NbWaves { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(TeamId);
            writer.WriteDouble(LeaderId);
            writer.WriteSByte(TeamSide);
            writer.WriteByte(TeamTypeId);
            writer.WriteByte(NbWaves);
        }

        public override void Deserialize(IDataReader reader)
        {
            TeamId = reader.ReadByte();
            LeaderId = reader.ReadDouble();
            TeamSide = reader.ReadSByte();
            TeamTypeId = reader.ReadByte();
            NbWaves = reader.ReadByte();
        }
    }
}