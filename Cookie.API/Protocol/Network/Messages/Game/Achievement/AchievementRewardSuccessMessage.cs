using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    public class AchievementRewardSuccessMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6376;

        public AchievementRewardSuccessMessage(short achievementId)
        {
            AchievementId = achievementId;
        }

        public AchievementRewardSuccessMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public short AchievementId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(AchievementId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AchievementId = reader.ReadShort();
        }
    }
}