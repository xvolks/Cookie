using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Quest
{
    public class QuestActiveDetailedInformations : QuestActiveInformations
    {
        public new const ushort ProtocolId = 382;

        public QuestActiveDetailedInformations(ushort stepId, List<QuestObjectiveInformations> objectives)
        {
            StepId = stepId;
            Objectives = objectives;
        }

        public QuestActiveDetailedInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort StepId { get; set; }
        public List<QuestObjectiveInformations> Objectives { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(StepId);
            writer.WriteShort((short) Objectives.Count);
            for (var objectivesIndex = 0; objectivesIndex < Objectives.Count; objectivesIndex++)
            {
                var objectToSend = Objectives[objectivesIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            StepId = reader.ReadVarUhShort();
            var objectivesCount = reader.ReadUShort();
            Objectives = new List<QuestObjectiveInformations>();
            for (var objectivesIndex = 0; objectivesIndex < objectivesCount; objectivesIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<QuestObjectiveInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Objectives.Add(objectToAdd);
            }
        }
    }
}