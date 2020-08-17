using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntAvailableRetryCountUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6491;

        public TreasureHuntAvailableRetryCountUpdateMessage(byte questType, int availableRetryCount)
        {
            QuestType = questType;
            AvailableRetryCount = availableRetryCount;
        }

        public TreasureHuntAvailableRetryCountUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte QuestType { get; set; }
        public int AvailableRetryCount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(QuestType);
            writer.WriteInt(AvailableRetryCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadByte();
            AvailableRetryCount = reader.ReadInt();
        }
    }
}