using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TreasureHuntFlagRequestAnswerMessage : NetworkMessage
    {
        public const uint ProtocolId = 6507;
        public override uint MessageID { get { return ProtocolId; } }

        public byte QuestType = 0;
        public byte Result = 0;
        public byte Index = 0;

        public TreasureHuntFlagRequestAnswerMessage()
        {
        }

        public TreasureHuntFlagRequestAnswerMessage(
            byte questType,
            byte result,
            byte index
        )
        {
            QuestType = questType;
            Result = result;
            Index = index;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(QuestType);
            writer.WriteByte(Result);
            writer.WriteByte(Index);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            QuestType = reader.ReadByte();
            Result = reader.ReadByte();
            Index = reader.ReadByte();
        }
    }
}