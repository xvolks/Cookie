using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightEndMessage : NetworkMessage
    {
        public const uint ProtocolId = 720;
        public override uint MessageID { get { return ProtocolId; } }

        public int Duration = 0;
        public short RewardRate = 0;
        public short LootShareLimitMalus = 0;
        public List<FightResultListEntry> Results;
        public List<NamedPartyTeamWithOutcome> NamedPartyTeamsOutcomes;

        public GameFightEndMessage()
        {
        }

        public GameFightEndMessage(
            int duration,
            short rewardRate,
            short lootShareLimitMalus,
            List<FightResultListEntry> results,
            List<NamedPartyTeamWithOutcome> namedPartyTeamsOutcomes
        )
        {
            Duration = duration;
            RewardRate = rewardRate;
            LootShareLimitMalus = lootShareLimitMalus;
            Results = results;
            NamedPartyTeamsOutcomes = namedPartyTeamsOutcomes;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(Duration);
            writer.WriteVarShort(RewardRate);
            writer.WriteShort(LootShareLimitMalus);
            writer.WriteShort((short)Results.Count());
            foreach (var current in Results)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteShort((short)NamedPartyTeamsOutcomes.Count());
            foreach (var current in NamedPartyTeamsOutcomes)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Duration = reader.ReadInt();
            RewardRate = reader.ReadVarShort();
            LootShareLimitMalus = reader.ReadShort();
            var countResults = reader.ReadShort();
            Results = new List<FightResultListEntry>();
            for (short i = 0; i < countResults; i++)
            {
                var resultstypeId = reader.ReadShort();
                FightResultListEntry type = new FightResultListEntry();
                type.Deserialize(reader);
                Results.Add(type);
            }
            var countNamedPartyTeamsOutcomes = reader.ReadShort();
            NamedPartyTeamsOutcomes = new List<NamedPartyTeamWithOutcome>();
            for (short i = 0; i < countNamedPartyTeamsOutcomes; i++)
            {
                NamedPartyTeamWithOutcome type = new NamedPartyTeamWithOutcome();
                type.Deserialize(reader);
                NamedPartyTeamsOutcomes.Add(type);
            }
        }
    }
}