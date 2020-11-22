using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class QuestObjectiveInformations : NetworkType
    {
        public const short ProtocolId = 385;
        public override short TypeId { get { return ProtocolId; } }

        public short ObjectiveId = 0;
        public bool ObjectiveStatus = false;
        public List<string> DialogParams;

        public QuestObjectiveInformations()
        {
        }

        public QuestObjectiveInformations(
            short objectiveId,
            bool objectiveStatus,
            List<string> dialogParams
        )
        {
            ObjectiveId = objectiveId;
            ObjectiveStatus = objectiveStatus;
            DialogParams = dialogParams;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ObjectiveId);
            writer.WriteBoolean(ObjectiveStatus);
            writer.WriteShort((short)DialogParams.Count());
            foreach (var current in DialogParams)
            {
                writer.WriteUTF(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectiveId = reader.ReadVarShort();
            ObjectiveStatus = reader.ReadBoolean();
            var countDialogParams = reader.ReadShort();
            DialogParams = new List<string>();
            for (short i = 0; i < countDialogParams; i++)
            {
                DialogParams.Add(reader.ReadUTF());
            }
        }
    }
}