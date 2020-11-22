using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightEndMessage : NetworkMessage
    {
        public const ushort ProtocolId = 720;

        public override ushort MessageID => ProtocolId;

        public int Duration { get; set; }
        public short RewardRate { get; set; }
        public short LootShareLimitMalus { get; set; }
        public List<FightResultListEntry> Results { get; set; }
        public List<NamedPartyTeamWithOutcome> NamedPartyTeamsOutcomes { get; set; }
        public GameFightEndMessage() { }

        public GameFightEndMessage( int Duration, short RewardRate, short LootShareLimitMalus, List<FightResultListEntry> Results, List<NamedPartyTeamWithOutcome> NamedPartyTeamsOutcomes ){
            this.Duration = Duration;
            this.RewardRate = RewardRate;
            this.LootShareLimitMalus = LootShareLimitMalus;
            this.Results = Results;
            this.NamedPartyTeamsOutcomes = NamedPartyTeamsOutcomes;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Duration);
            writer.WriteVarShort(RewardRate);
            writer.WriteShort(LootShareLimitMalus);
			writer.WriteShort((short)Results.Count);
			foreach (var x in Results)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)NamedPartyTeamsOutcomes.Count);
			foreach (var x in NamedPartyTeamsOutcomes)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Duration = reader.ReadInt();
            RewardRate = reader.ReadVarShort();
            LootShareLimitMalus = reader.ReadShort();
            var ResultsCount = reader.ReadShort();
            Results = new List<FightResultListEntry>();
            for (var i = 0; i < ResultsCount; i++)
            {
                FightResultListEntry objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Results.Add(objectToAdd);
            }
            var NamedPartyTeamsOutcomesCount = reader.ReadShort();
            NamedPartyTeamsOutcomes = new List<NamedPartyTeamWithOutcome>();
            for (var i = 0; i < NamedPartyTeamsOutcomesCount; i++)
            {
                var objectToAdd = new NamedPartyTeamWithOutcome();
                objectToAdd.Deserialize(reader);
                NamedPartyTeamsOutcomes.Add(objectToAdd);
            }
        }
    }
}
