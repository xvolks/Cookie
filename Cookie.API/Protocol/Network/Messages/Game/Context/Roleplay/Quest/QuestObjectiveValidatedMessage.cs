namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    using Utils.IO;

    public class QuestObjectiveValidatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6098;
        public override ushort MessageID => ProtocolId;
        public ushort QuestId { get; set; }
        public ushort ObjectiveId { get; set; }

        public QuestObjectiveValidatedMessage(ushort questId, ushort objectiveId)
        {
            QuestId = questId;
            ObjectiveId = objectiveId;
        }

        public QuestObjectiveValidatedMessage() { }

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
