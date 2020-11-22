using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AchievementFinishedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6208;
        public override uint MessageID { get { return ProtocolId; } }

        public AchievementAchievedRewardable Achievement;

        public AchievementFinishedMessage()
        {
        }

        public AchievementFinishedMessage(
            AchievementAchievedRewardable achievement
        )
        {
            Achievement = achievement;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Achievement.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Achievement = new AchievementAchievedRewardable();
            Achievement.Deserialize(reader);
        }
    }
}