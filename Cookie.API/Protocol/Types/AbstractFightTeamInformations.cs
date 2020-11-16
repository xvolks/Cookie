using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AbstractFightTeamInformations : NetworkType
    {
        public const ushort ProtocolId = 116;

        public override ushort TypeID => ProtocolId;

        public sbyte TeamId { get; set; }
        public double LeaderId { get; set; }
        public sbyte TeamSide { get; set; }
        public sbyte TeamTypeId { get; set; }
        public sbyte NbWaves { get; set; }
        public AbstractFightTeamInformations() { }

        public AbstractFightTeamInformations( sbyte TeamId, double LeaderId, sbyte TeamSide, sbyte TeamTypeId, sbyte NbWaves ){
            this.TeamId = TeamId;
            this.LeaderId = LeaderId;
            this.TeamSide = TeamSide;
            this.TeamTypeId = TeamTypeId;
            this.NbWaves = NbWaves;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(TeamId);
            writer.WriteDouble(LeaderId);
            writer.WriteSByte(TeamSide);
            writer.WriteSByte(TeamTypeId);
            writer.WriteSByte(NbWaves);
        }

        public override void Deserialize(IDataReader reader)
        {
            TeamId = reader.ReadSByte();
            LeaderId = reader.ReadDouble();
            TeamSide = reader.ReadSByte();
            TeamTypeId = reader.ReadSByte();
            NbWaves = reader.ReadSByte();
        }
    }
}
