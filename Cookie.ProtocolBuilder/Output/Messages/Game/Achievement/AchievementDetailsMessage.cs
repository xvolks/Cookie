namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    using Types.Game.Achievement;
    using Utils.IO;

    public class AchievementDetailsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6378;
        public override ushort MessageID => ProtocolId;
        public Achievement Achievement { get; set; }

        public AchievementDetailsMessage(Achievement achievement)
        {
            Achievement = achievement;
        }

        public AchievementDetailsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Achievement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Achievement = new Achievement();
            Achievement.Deserialize(reader);
        }

    }
}
