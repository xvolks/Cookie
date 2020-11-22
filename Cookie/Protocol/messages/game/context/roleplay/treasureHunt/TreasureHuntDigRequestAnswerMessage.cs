using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TreasureHuntDigRequestAnswerMessage : NetworkMessage
    {
        public const uint ProtocolId = 6484;
        public override uint MessageID { get { return ProtocolId; } }

        public byte QuestType = 0;
        public byte Result = 0;

        public TreasureHuntDigRequestAnswerMessage()
        {
        }

        public TreasureHuntDigRequestAnswerMessage(
            byte questType,
            byte result
        )
        {
            QuestType = questType;
            Result = result;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(QuestType);
            writer.WriteByte(Result);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            QuestType = reader.ReadByte();
            Result = reader.ReadByte();
        }
    }
}