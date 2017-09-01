using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Quest;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    public class QuestStepInfoMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5625;

        public QuestStepInfoMessage(QuestActiveInformations infos)
        {
            Infos = infos;
        }

        public QuestStepInfoMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public QuestActiveInformations Infos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Infos.TypeID);
            Infos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Infos = ProtocolTypeManager.GetInstance<QuestActiveInformations>(reader.ReadUShort());
            Infos.Deserialize(reader);
        }
    }
}