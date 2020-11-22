using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class QuestStepStartedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6096;
        public override uint MessageID { get { return ProtocolId; } }

        public short QuestId = 0;
        public short StepId = 0;

        public QuestStepStartedMessage()
        {
        }

        public QuestStepStartedMessage(
            short questId,
            short stepId
        )
        {
            QuestId = questId;
            StepId = stepId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(QuestId);
            writer.WriteVarShort(StepId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            QuestId = reader.ReadVarShort();
            StepId = reader.ReadVarShort();
        }
    }
}