namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    using Utils.IO;

    public class QuestStepStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6096;
        public override ushort MessageID => ProtocolId;
        public ushort QuestId { get; set; }
        public ushort StepId { get; set; }

        public QuestStepStartedMessage(ushort questId, ushort stepId)
        {
            QuestId = questId;
            StepId = stepId;
        }

        public QuestStepStartedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(QuestId);
            writer.WriteVarUhShort(StepId);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestId = reader.ReadVarUhShort();
            StepId = reader.ReadVarUhShort();
        }

    }
}
