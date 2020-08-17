namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    using Utils.IO;

    public class AchievementRewardRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6377;
        public override ushort MessageID => ProtocolId;
        public short AchievementId { get; set; }

        public AchievementRewardRequestMessage(short achievementId)
        {
            AchievementId = achievementId;
        }

        public AchievementRewardRequestMessage() { }

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
