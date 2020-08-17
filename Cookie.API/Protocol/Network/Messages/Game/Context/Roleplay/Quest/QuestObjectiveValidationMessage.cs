using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    public class QuestObjectiveValidationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6085;

        public QuestObjectiveValidationMessage(ushort questId, ushort objectiveId)
        {
            QuestId = questId;
            ObjectiveId = objectiveId;
        }

        public QuestObjectiveValidationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort QuestId { get; set; }
        public ushort ObjectiveId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(QuestId);
            writer.WriteVarUhShort(ObjectiveId);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestId = reader.ReadVarUhShort();
            ObjectiveId = reader.ReadVarUhShort();
        }
    }
}