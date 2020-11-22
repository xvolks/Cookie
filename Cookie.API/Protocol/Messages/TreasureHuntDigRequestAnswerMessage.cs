using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TreasureHuntDigRequestAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6484;

        public override ushort MessageID => ProtocolId;

        public sbyte QuestType { get; set; }
        public sbyte Result { get; set; }
        public TreasureHuntDigRequestAnswerMessage() { }

        public TreasureHuntDigRequestAnswerMessage( sbyte QuestType, sbyte Result ){
            this.QuestType = QuestType;
            this.Result = Result;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(QuestType);
            writer.WriteSByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadSByte();
            Result = reader.ReadSByte();
        }
    }
}
