using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Achievement;

namespace Cookie.Handlers.Game.Achievement
{
    public class GameAchievementHandlers
    {
        [MessageHandler(AchievementListMessage.ProtocolId)]
        private void AchievementListMessageHandler(DofusClient Client, AchievementListMessage Message)
        {
            //
        }

        [MessageHandler(FriendGuildWarnOnAchievementCompleteStateMessage.ProtocolId)]
        private void FriendGuildWarnOnAchievementCompleteStateMessageHandler(DofusClient Client, FriendGuildWarnOnAchievementCompleteStateMessage Message)
        {
            //
        }
    }
}
