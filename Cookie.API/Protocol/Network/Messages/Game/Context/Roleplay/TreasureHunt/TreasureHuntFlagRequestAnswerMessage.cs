using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntFlagRequestAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6507;

        public TreasureHuntFlagRequestAnswerMessage(byte questType, byte result, byte index)
        {
            QuestType = questType;
            Result = result;
            Index = index;
        }

        public TreasureHuntFlagRequestAnswerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte QuestType { get; set; }
        public byte Result { get; set; }
        public byte Index { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(QuestType);
            writer.WriteByte(Result);
            writer.WriteByte(Index);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadByte();
            Result = reader.ReadByte();
            Index = reader.ReadByte();
        }
    }
}