using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6488;

        public TreasureHuntRequestMessage(byte questLevel, byte questType)
        {
            QuestLevel = questLevel;
            QuestType = questType;
        }

        public TreasureHuntRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte QuestLevel { get; set; }
        public byte QuestType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(QuestLevel);
            writer.WriteByte(QuestType);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestLevel = reader.ReadByte();
            QuestType = reader.ReadByte();
        }
    }
}