using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AbstractFightTeamInformations : NetworkType
    {
        public const short ProtocolId = 116;
        public override short TypeId { get { return ProtocolId; } }

        public byte TeamId = 2;
        public double LeaderId = 0;
        public byte TeamSide = 0;
        public byte TeamTypeId = 0;
        public byte NbWaves = 0;

        public AbstractFightTeamInformations()
        {
        }

        public AbstractFightTeamInformations(
            byte teamId,
            double leaderId,
            byte teamSide,
            byte teamTypeId,
            byte nbWaves
        )
        {
            TeamId = teamId;
            LeaderId = leaderId;
            TeamSide = teamSide;
            TeamTypeId = teamTypeId;
            NbWaves = nbWaves;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(TeamId);
            writer.WriteDouble(LeaderId);
            writer.WriteByte(TeamSide);
            writer.WriteByte(TeamTypeId);
            writer.WriteByte(NbWaves);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TeamId = reader.ReadByte();
            LeaderId = reader.ReadDouble();
            TeamSide = reader.ReadByte();
            TeamTypeId = reader.ReadByte();
            NbWaves = reader.ReadByte();
        }
    }
}