using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class QuestStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6091;

        public override ushort MessageID => ProtocolId;

        public ushort QuestId { get; set; }
        public QuestStartedMessage() { }

        public QuestStartedMessage( ushort QuestId ){
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
