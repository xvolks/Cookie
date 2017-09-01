using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    public class FollowQuestObjectiveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6724;

        public FollowQuestObjectiveRequestMessage(ushort questId, short objectiveId)
        {
            QuestId = questId;
            ObjectiveId = objectiveId;
        }

        public FollowQuestObjectiveRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort QuestId { get; set; }
        public short ObjectiveId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(QuestId);
            writer.WriteShort(ObjectiveId);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestId = reader.ReadVarUhShort();
            ObjectiveId = reader.ReadShort();
        }
    }
}