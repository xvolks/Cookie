using Cookie.Core;
using Cookie.Gamedata.D2o;
using Cookie.Gamedata.I18n;
using Cookie.Protocol.Network.Messages.Game.Achievement;

namespace Cookie.Handlers.Game.Achievement
{
    public class GameAchievementHandlers
    {
        [MessageHandler(AchievementListMessage.ProtocolId)]
        private void AchievementListMessageHandler(DofusClient client, AchievementListMessage message)
        {
            //
        }

        [MessageHandler(FriendGuildWarnOnAchievementCompleteStateMessage.ProtocolId)]
        private void FriendGuildWarnOnAchievementCompleteStateMessageHandler(DofusClient client, FriendGuildWarnOnAchievementCompleteStateMessage message)
        {
            //
        }

        [MessageHandler(AchievementFinishedMessage.ProtocolId)]
        private void AchievementFinishedMessageHandler(Client client, AchievementFinishedMessage message)
        {
            var text = I18nDataManager.Instance.ReadText(ObjectDataManager.Instance.Get<Datacenter.Achievement>(message.ObjectId).NameId);
            client.Logger.Log($"Succés {text} obtenu");

        }
    }
}
