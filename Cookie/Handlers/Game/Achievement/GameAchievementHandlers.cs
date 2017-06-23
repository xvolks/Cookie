using Cookie.Core;
using Cookie.Gamedata.D2o;
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
        private void FriendGuildWarnOnAchievementCompleteStateMessageHandler(DofusClient client,
            FriendGuildWarnOnAchievementCompleteStateMessage message)
        {
            //
        }

        [MessageHandler(AchievementFinishedMessage.ProtocolId)]
        private void AchievementFinishedMessageHandler(Client client, AchievementFinishedMessage message)
        {
            var text = FastD2IReader.Instance.GetText(ObjectDataManager.Instance
                .Get<Datacenter.Achievement>(message.ObjectId).NameId);
            client.Logger.Log($"Succés {text} obtenu");
        }
    }
}