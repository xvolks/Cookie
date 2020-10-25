using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class QuestActiveDetailedInformations : QuestActiveInformations
    {
        public new const short ProtocolId = 382;
        public override short TypeId { get { return ProtocolId; } }

        public short StepId = 0;
        public List<QuestObjectiveInformations> Objectives;

        public QuestActiveDetailedInformations(): base()
        {
        }

        public QuestActiveDetailedInformations(
            short questId,
            short stepId,
            List<QuestObjectiveInformations> objectives
        ): base(
            questId
        )
        {
            StepId = stepId;
            Objectives = objectives;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(StepId);
            writer.WriteShort((short)Objectives.Count());
            foreach (var current in Objectives)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            StepId = reader.ReadVarShort();
            var countObjectives = reader.ReadShort();
            Objectives = new List<QuestObjectiveInformations>();
            for (short i = 0; i < countObjectives; i++)
            {
                var objectivestypeId = reader.ReadShort();
                QuestObjectiveInformations type = new QuestObjectiveInformations();
                type.Deserialize(reader);
                Objectives.Add(type);
            }
        }
    }
}