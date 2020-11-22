using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TreasureHuntFlagRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6508;

        public override ushort MessageID => ProtocolId;

        public sbyte QuestType { get; set; }
        public sbyte Index { get; set; }
        public TreasureHuntFlagRequestMessage() { }

        public TreasureHuntFlagRequestMessage( sbyte QuestType, sbyte Index ){
            this.QuestType = QuestType;
            this.Index = Index;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(QuestType);
            writer.WriteSByte(Index);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadSByte();
            Index = reader.ReadSByte();
        }
    }
}
