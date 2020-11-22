using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class FightAllianceTeamInformations : FightTeamInformations
    {
        public new const short ProtocolId = 439;
        public override short TypeId { get { return ProtocolId; } }

        public byte Relation = 0;

        public FightAllianceTeamInformations(): base()
        {
        }

        public FightAllianceTeamInformations(
            byte teamId,
            double leaderId,
            byte teamSide,
            byte teamTypeId,
            byte nbWaves,
            List<FightTeamMemberInformations> teamMembers,
            byte relation
        ): base(
            teamId,
            leaderId,
            teamSide,
            teamTypeId,
            nbWaves,
            teamMembers
        )
        {
            Relation = relation;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Relation);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Relation = reader.ReadByte();
        }
    }
}