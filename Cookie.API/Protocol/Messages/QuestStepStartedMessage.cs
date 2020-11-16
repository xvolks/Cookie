using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class QuestStepStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6096;

        public override ushort MessageID => ProtocolId;

        public ushort QuestId { get; set; }
        public ushort StepId { get; set; }
        public QuestStepStartedMessage() { }

        public QuestStepStartedMessage( ushort QuestId, ushort StepId ){
            this.QuestId = QuestId;
            this.StepId = StepId;
        }

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
