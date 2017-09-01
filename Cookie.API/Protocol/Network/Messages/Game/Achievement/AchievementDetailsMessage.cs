using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    public class AchievementDetailsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6378;

        public AchievementDetailsMessage(Types.Game.Achievement.Achievement achievement)
        {
            Achievement = achievement;
        }

        public AchievementDetailsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public Types.Game.Achievement.Achievement Achievement { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Achievement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Achievement = new Types.Game.Achievement.Achievement();
            Achievement.Deserialize(reader);
        }
    }
}