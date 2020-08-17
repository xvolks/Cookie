namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    using Utils.IO;

    public class AchievementRewardErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6375;
        public override ushort MessageID => ProtocolId;
        public short AchievementId { get; set; }

        public AchievementRewardErrorMessage(short achievementId)
        {
            AchievementId = achievementId;
        }

        public AchievementRewardErrorMessage() { }

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
