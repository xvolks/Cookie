using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TreasureHuntFlagRequestAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6507;

        public override ushort MessageID => ProtocolId;

        public sbyte QuestType { get; set; }
        public sbyte Result { get; set; }
        public sbyte Index { get; set; }
        public TreasureHuntFlagRequestAnswerMessage() { }

        public TreasureHuntFlagRequestAnswerMessage( sbyte QuestType, sbyte Result, sbyte Index ){
            this.QuestType = QuestType;
            this.Result = Result;
            this.Index = Index;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(QuestType);
            writer.WriteSByte(Result);
            writer.WriteSByte(Index);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadSByte();
            Result = reader.ReadSByte();
            Index = reader.ReadSByte();
        }
    }
}
