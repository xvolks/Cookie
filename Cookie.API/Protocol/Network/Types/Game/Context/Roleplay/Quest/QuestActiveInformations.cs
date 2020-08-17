using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Quest
{
    public class QuestActiveInformations : NetworkType
    {
        public const ushort ProtocolId = 381;

        public QuestActiveInformations(ushort questId)
        {
            QuestId = questId;
        }

        public QuestActiveInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
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