using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    public class AchievementDetailsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6380;

        public AchievementDetailsRequestMessage(ushort achievementId)
        {
            AchievementId = achievementId;
        }

        public AchievementDetailsRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort AchievementId { get; set; }

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