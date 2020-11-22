using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class UnfollowQuestObjectiveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6723;

        public override ushort MessageID => ProtocolId;

        public ushort QuestId { get; set; }
        public short ObjectiveId { get; set; }
        public UnfollowQuestObjectiveRequestMessage() { }

        public UnfollowQuestObjectiveRequestMessage( ushort QuestId, short ObjectiveId ){
            this.QuestId = QuestId;
            this.ObjectiveId = ObjectiveId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(QuestId);
            writer.WriteShort(ObjectiveId);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestId = reader.ReadVarUhShort();
            ObjectiveId = reader.ReadShort();
        }
    }
}
