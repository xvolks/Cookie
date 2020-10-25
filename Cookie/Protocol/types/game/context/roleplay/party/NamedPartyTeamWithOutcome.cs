using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class NamedPartyTeamWithOutcome : NetworkType
    {
        public const short ProtocolId = 470;
        public override short TypeId { get { return ProtocolId; } }

        public NamedPartyTeam Team;
        public short Outcome = 0;

        public NamedPartyTeamWithOutcome()
        {
        }

        public NamedPartyTeamWithOutcome(
            NamedPartyTeam team,
            short outcome
        )
        {
            Team = team;
            Outcome = outcome;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Team.Serialize(writer);
            writer.WriteVarShort(Outcome);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Team = new NamedPartyTeam();
            Team.Deserialize(reader);
            Outcome = reader.ReadVarShort();
        }
    }
}