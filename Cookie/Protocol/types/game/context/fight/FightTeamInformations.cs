using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class FightTeamInformations : AbstractFightTeamInformations
    {
        public new const short ProtocolId = 33;
        public override short TypeId { get { return ProtocolId; } }

        public List<FightTeamMemberInformations> TeamMembers;

        public FightTeamInformations(): base()
        {
        }

        public FightTeamInformations(
            byte teamId,
            double leaderId,
            byte teamSide,
            byte teamTypeId,
            byte nbWaves,
            List<FightTeamMemberInformations> teamMembers
        ): base(
            teamId,
            leaderId,
            teamSide,
            teamTypeId,
            nbWaves
        )
        {
            TeamMembers = teamMembers;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)TeamMembers.Count());
            foreach (var current in TeamMembers)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countTeamMembers = reader.ReadShort();
            TeamMembers = new List<FightTeamMemberInformations>();
            for (short i = 0; i < countTeamMembers; i++)
            {
                var teamMemberstypeId = reader.ReadShort();
                FightTeamMemberInformations type = new FightTeamMemberInformations();
                type.Deserialize(reader);
                TeamMembers.Add(type);
            }
        }
    }
}