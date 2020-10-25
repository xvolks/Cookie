using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachGameFightEndMessage : GameFightEndMessage
    {
        public new const uint ProtocolId = 6809;
        public override uint MessageID { get { return ProtocolId; } }

        public int Budget = 0;

        public BreachGameFightEndMessage(): base()
        {
        }

        public BreachGameFightEndMessage(
            int duration,
            short rewardRate,
            short lootShareLimitMalus,
            List<FightResultListEntry> results,
            List<NamedPartyTeamWithOutcome> namedPartyTeamsOutcomes,
            int budget
        ): base(
            duration,
            rewardRate,
            lootShareLimitMalus,
            results,
            namedPartyTeamsOutcomes
        )
        {
            Budget = budget;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Budget);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Budget = reader.ReadInt();
        }
    }
}