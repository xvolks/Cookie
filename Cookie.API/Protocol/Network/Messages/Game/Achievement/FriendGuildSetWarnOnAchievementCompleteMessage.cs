using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    public class FriendGuildSetWarnOnAchievementCompleteMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6382;

        public FriendGuildSetWarnOnAchievementCompleteMessage(bool enable)
        {
            Enable = enable;
        }

        public FriendGuildSetWarnOnAchievementCompleteMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}