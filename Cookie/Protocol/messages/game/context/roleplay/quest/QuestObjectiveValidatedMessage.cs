using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class QuestObjectiveValidatedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6098;
        public override uint MessageID { get { return ProtocolId; } }

        public short QuestId = 0;
        public short ObjectiveId = 0;

        public QuestObjectiveValidatedMessage()
        {
        }

        public QuestObjectiveValidatedMessage(
            short questId,
            short objectiveId
        )
        {
            QuestId = questId;
            ObjectiveId = objectiveId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(QuestId);
            writer.WriteVarShort(ObjectiveId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            QuestId = reader.ReadVarShort();
            ObjectiveId = reader.ReadVarShort();
        }
    }
}