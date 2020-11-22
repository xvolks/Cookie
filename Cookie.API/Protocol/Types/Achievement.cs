using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class Achievement : NetworkType
    {
        public const ushort ProtocolId = 363;

        public override ushort TypeID => ProtocolId;

        public ushort Id { get; set; }
        public List<AchievementObjective> FinishedObjective { get; set; }
        public List<AchievementStartedObjective> StartedObjectives { get; set; }
        public Achievement() { }

        public Achievement( ushort Id, List<AchievementObjective> FinishedObjective, List<AchievementStartedObjective> StartedObjectives ){
            this.Id = Id;
            this.FinishedObjective = FinishedObjective;
            this.StartedObjectives = StartedObjectives;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Id);
			writer.WriteShort((short)FinishedObjective.Count);
			foreach (var x in FinishedObjective)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)StartedObjectives.Count);
			foreach (var x in StartedObjectives)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhShort();
            var FinishedObjectiveCount = reader.ReadShort();
            FinishedObjective = new List<AchievementObjective>();
            for (var i = 0; i < FinishedObjectiveCount; i++)
            {
                var objectToAdd = new AchievementObjective();
                objectToAdd.Deserialize(reader);
                FinishedObjective.Add(objectToAdd);
            }
            var StartedObjectivesCount = reader.ReadShort();
            StartedObjectives = new List<AchievementStartedObjective>();
            for (var i = 0; i < StartedObjectivesCount; i++)
            {
                var objectToAdd = new AchievementStartedObjective();
                objectToAdd.Deserialize(reader);
                StartedObjectives.Add(objectToAdd);
            }
        }
    }
}
