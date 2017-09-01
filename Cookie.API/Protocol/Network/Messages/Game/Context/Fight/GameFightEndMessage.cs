using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightEndMessage : NetworkMessage
    {
        public const ushort ProtocolId = 720;

        public GameFightEndMessage(int duration, short ageBonus, short lootShareLimitMalus,
            List<FightResultListEntry> results, List<NamedPartyTeamWithOutcome> namedPartyTeamsOutcomes)
        {
            Duration = duration;
            AgeBonus = ageBonus;
            LootShareLimitMalus = lootShareLimitMalus;
            Results = results;
            NamedPartyTeamsOutcomes = namedPartyTeamsOutcomes;
        }

        public GameFightEndMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int Duration { get; set; }
        public short AgeBonus { get; set; }
        public short LootShareLimitMalus { get; set; }
        public List<FightResultListEntry> Results { get; set; }
        public List<NamedPartyTeamWithOutcome> NamedPartyTeamsOutcomes { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Duration);
            writer.WriteShort(AgeBonus);
            writer.WriteShort(LootShareLimitMalus);
            writer.WriteShort((short) Results.Count);
            for (var resultsIndex = 0; resultsIndex < Results.Count; resultsIndex++)
            {
                var objectToSend = Results[resultsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) NamedPartyTeamsOutcomes.Count);
            for (var namedPartyTeamsOutcomesIndex = 0;
                namedPartyTeamsOutcomesIndex < NamedPartyTeamsOutcomes.Count;
                namedPartyTeamsOutcomesIndex++)
            {
                var objectToSend = NamedPartyTeamsOutcomes[namedPartyTeamsOutcomesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            Duration = reader.ReadInt();
            AgeBonus = reader.ReadShort();
            LootShareLimitMalus = reader.ReadShort();
            var resultsCount = reader.ReadUShort();
            Results = new List<FightResultListEntry>();
            for (var resultsIndex = 0; resultsIndex < resultsCount; resultsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<FightResultListEntry>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Results.Add(objectToAdd);
            }
            var namedPartyTeamsOutcomesCount = reader.ReadUShort();
            NamedPartyTeamsOutcomes = new List<NamedPartyTeamWithOutcome>();
            for (var namedPartyTeamsOutcomesIndex = 0;
                namedPartyTeamsOutcomesIndex < namedPartyTeamsOutcomesCount;
                namedPartyTeamsOutcomesIndex++)
            {
                var objectToAdd = new NamedPartyTeamWithOutcome();
                objectToAdd.Deserialize(reader);
                NamedPartyTeamsOutcomes.Add(objectToAdd);
            }
        }
    }
}