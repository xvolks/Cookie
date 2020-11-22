using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TreasureHuntDigRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6485;
        public override uint MessageID { get { return ProtocolId; } }

        public byte QuestType = 0;

        public TreasureHuntDigRequestMessage()
        {
        }

        public TreasureHuntDigRequestMessage(
            byte questType
        )
        {
            QuestType = questType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(QuestType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            QuestType = reader.ReadByte();
        }
    }
}