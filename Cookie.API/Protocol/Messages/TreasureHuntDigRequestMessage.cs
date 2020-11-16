using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TreasureHuntDigRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6485;

        public override ushort MessageID => ProtocolId;

        public sbyte QuestType { get; set; }
        public TreasureHuntDigRequestMessage() { }

        public TreasureHuntDigRequestMessage( sbyte QuestType ){
            this.QuestType = QuestType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(QuestType);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadSByte();
        }
    }
}
