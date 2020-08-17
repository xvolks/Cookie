using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    public class AchievementRewardRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6377;

        public AchievementRewardRequestMessage(short achievementId)
        {
            AchievementId = achievementId;
        }

        public AchievementRewardRequestMessage()
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