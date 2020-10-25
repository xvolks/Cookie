using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FollowQuestObjectiveRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6724;
        public override uint MessageID { get { return ProtocolId; } }

        public short QuestId = 0;
        public short ObjectiveId = 0;

        public FollowQuestObjectiveRequestMessage()
        {
        }

        public FollowQuestObjectiveRequestMessage(
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
            writer.WriteShort(ObjectiveId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            QuestId = reader.ReadVarShort();
            ObjectiveId = reader.ReadShort();
        }
    }
}