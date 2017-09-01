using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntDigRequestAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6484;

        public TreasureHuntDigRequestAnswerMessage(byte questType, byte result)
        {
            QuestType = questType;
            Result = result;
        }

        public TreasureHuntDigRequestAnswerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte QuestType { get; set; }
        public byte Result { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(QuestType);
            writer.WriteByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadByte();
            Result = reader.ReadByte();
        }
    }
}