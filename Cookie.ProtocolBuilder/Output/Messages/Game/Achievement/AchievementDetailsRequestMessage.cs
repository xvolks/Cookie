namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    using Utils.IO;

    public class AchievementDetailsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6380;
        public override ushort MessageID => ProtocolId;
        public ushort AchievementId { get; set; }

        public AchievementDetailsRequestMessage(ushort achievementId)
        {
            AchievementId = achievementId;
        }

        public AchievementDetailsRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(AchievementId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AchievementId = reader.ReadVarUhShort();
        }

    }
}
