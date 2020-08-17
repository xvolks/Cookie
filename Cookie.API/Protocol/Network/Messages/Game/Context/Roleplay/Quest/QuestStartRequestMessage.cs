namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    using Utils.IO;

    public class QuestStartRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5643;
        public override ushort MessageID => ProtocolId;
        public ushort QuestId { get; set; }

        public QuestStartRequestMessage(ushort questId)
        {
            QuestId = questId;
        }

        public QuestStartRequestMessage() { }

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
