using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class QuestActiveInformations : NetworkType
    {
        public const short ProtocolId = 381;
        public override short TypeId { get { return ProtocolId; } }

        public short QuestId = 0;

        public QuestActiveInformations()
        {
        }

        public QuestActiveInformations(
            short questId
        )
        {
            QuestId = questId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(QuestId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            QuestId = reader.ReadVarShort();
        }
    }
}