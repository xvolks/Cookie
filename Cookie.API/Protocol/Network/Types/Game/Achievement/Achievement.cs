using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Achievement
{
    public class Achievement : NetworkType
    {
        public const ushort ProtocolId = 363;

        public Achievement(ushort objectId, List<AchievementObjective> finishedObjective,
            List<AchievementStartedObjective> startedObjectives)
        {
            ObjectId = objectId;
            FinishedObjective = finishedObjective;
            StartedObjectives = startedObjectives;
        }

        public Achievement()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort ObjectId { get; set; }
        public List<AchievementObjective> FinishedObjective { get; set; }
        public List<AchievementStartedObjective> StartedObjectives { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectId);
            writer.WriteShort((short) FinishedObjective.Count);
            for (var finishedObjectiveIndex = 0;
                finishedObjectiveIndex < FinishedObjective.Count;
                finishedObjectiveIndex++)
            {
                var objectToSend = FinishedObjective[finishedObjectiveIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) StartedObjectives.Count);
            for (var startedObjectivesIndex = 0;
                startedObjectivesIndex < StartedObjectives.Count;
                startedObjectivesIndex++)
            {
                var objectToSend = StartedObjectives[startedObjectivesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhShort();
            var finishedObjectiveCount = reader.ReadUShort();
            FinishedObjective = new List<AchievementObjective>();
            for (var finishedObjectiveIndex = 0;
                finishedObjectiveIndex < finishedObjectiveCount;
                finishedObjectiveIndex++)
            {
                var objectToAdd = new AchievementObjective();
                objectToAdd.Deserialize(reader);
                FinishedObjective.Add(objectToAdd);
            }
            var startedObjectivesCount = reader.ReadUShort();
            StartedObjectives = new List<AchievementStartedObjective>();
            for (var startedObjectivesIndex = 0;
                startedObjectivesIndex < startedObjectivesCount;
                startedObjectivesIndex++)
            {
                var objectToAdd = new AchievementStartedObjective();
                objectToAdd.Deserialize(reader);
                StartedObjectives.Add(objectToAdd);
            }
        }
    }
}