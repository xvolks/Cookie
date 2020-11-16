using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class QuestStepInfoMessage : NetworkMessage
    {
        public const uint ProtocolId = 5625;
        public override uint MessageID { get { return ProtocolId; } }

        public QuestActiveInformations Infos;

        public QuestStepInfoMessage()
        {
        }

        public QuestStepInfoMessage(
            QuestActiveInformations infos
        )
        {
            Infos = infos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Infos.TypeId);
            Infos.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var infosTypeId = reader.ReadShort();
            Infos = new QuestActiveInformations();
            Infos.Deserialize(reader);
        }
    }
}