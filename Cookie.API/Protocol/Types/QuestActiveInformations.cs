using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class QuestActiveInformations : NetworkType
    {
        public const ushort ProtocolId = 381;

        public override ushort TypeID => ProtocolId;

        public ushort QuestId { get; set; }
        public QuestActiveInformations() { }

        public QuestActiveInformations( ushort QuestId ){
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
