using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AchievementDetailedListRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6357;
        public override uint MessageID { get { return ProtocolId; } }

        public short CategoryId = 0;

        public AchievementDetailedListRequestMessage()
        {
        }

        public AchievementDetailedListRequestMessage(
            short categoryId
        )
        {
            CategoryId = categoryId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(CategoryId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CategoryId = reader.ReadVarShort();
        }
    }
}