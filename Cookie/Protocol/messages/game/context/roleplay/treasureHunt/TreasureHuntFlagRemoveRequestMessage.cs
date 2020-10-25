using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TreasureHuntFlagRemoveRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6510;
        public override uint MessageID { get { return ProtocolId; } }

        public byte QuestType = 0;
        public byte Index = 0;

        public TreasureHuntFlagRemoveRequestMessage()
        {
        }

        public TreasureHuntFlagRemoveRequestMessage(
            byte questType,
            byte index
        )
        {
            QuestType = questType;
            Index = index;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(QuestType);
            writer.WriteByte(Index);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            QuestType = reader.ReadByte();
            Index = reader.ReadByte();
        }
    }
}