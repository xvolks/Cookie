using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class QuestStepInfoRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5622;

        public override ushort MessageID => ProtocolId;

        public ushort QuestId { get; set; }
        public QuestStepInfoRequestMessage() { }

        public QuestStepInfoRequestMessage( ushort QuestId ){
            this.QuestId = QuestId;
        }

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
