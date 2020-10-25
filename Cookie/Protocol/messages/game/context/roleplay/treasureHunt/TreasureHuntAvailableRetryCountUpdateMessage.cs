using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TreasureHuntAvailableRetryCountUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6491;
        public override uint MessageID { get { return ProtocolId; } }

        public byte QuestType = 0;
        public int AvailableRetryCount = 0;

        public TreasureHuntAvailableRetryCountUpdateMessage()
        {
        }

        public TreasureHuntAvailableRetryCountUpdateMessage(
            byte questType,
            int availableRetryCount
        )
        {
            QuestType = questType;
            AvailableRetryCount = availableRetryCount;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(QuestType);
            writer.WriteInt(AvailableRetryCount);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            QuestType = reader.ReadByte();
            AvailableRetryCount = reader.ReadInt();
        }
    }
}