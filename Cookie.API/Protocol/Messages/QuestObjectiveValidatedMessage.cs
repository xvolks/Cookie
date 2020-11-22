using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class QuestObjectiveValidatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6098;

        public override ushort MessageID => ProtocolId;

        public ushort QuestId { get; set; }
        public ushort ObjectiveId { get; set; }
        public QuestObjectiveValidatedMessage() { }

        public QuestObjectiveValidatedMessage( ushort QuestId, ushort ObjectiveId ){
            this.QuestId = QuestId;
            this.ObjectiveId = ObjectiveId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(QuestId);
            writer.WriteVarUhShort(ObjectiveId);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestId = reader.ReadVarUhShort();
            ObjectiveId = reader.ReadVarUhShort();
        }
    }
}
