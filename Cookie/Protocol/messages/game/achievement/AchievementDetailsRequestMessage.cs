using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AchievementDetailsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6380;
        public override uint MessageID { get { return ProtocolId; } }

        public short AchievementId = 0;

        public AchievementDetailsRequestMessage()
        {
        }

        public AchievementDetailsRequestMessage(
            short achievementId
        )
        {
            AchievementId = achievementId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(AchievementId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AchievementId = reader.ReadVarShort();
        }
    }
}