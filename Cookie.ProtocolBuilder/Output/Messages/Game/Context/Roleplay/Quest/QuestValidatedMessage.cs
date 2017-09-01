namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    using Utils.IO;

    public class QuestValidatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6097;
        public override ushort MessageID => ProtocolId;
        public ushort QuestId { get; set; }

        public QuestValidatedMessage(ushort questId)
        {
            QuestId = questId;
        }

        public QuestValidatedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(QuestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestId = reader.ReadVarUhShort();
        }

    }
}
