using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class QuestValidatedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6097;
        public override uint MessageID { get { return ProtocolId; } }

        public short QuestId = 0;

        public QuestValidatedMessage()
        {
        }

        public QuestValidatedMessage(
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