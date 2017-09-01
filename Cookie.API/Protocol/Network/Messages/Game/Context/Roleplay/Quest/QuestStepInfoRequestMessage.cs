using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    public class QuestStepInfoRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5622;

        public QuestStepInfoRequestMessage(ushort questId)
        {
            QuestId = questId;
        }

        public QuestStepInfoRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort QuestId { get; set; }

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