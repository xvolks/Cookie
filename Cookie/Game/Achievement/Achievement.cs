using Cookie.API.Core;
using Cookie.API.Game.Achievement;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Messages;
using Cookie.API.Protocol.Network.Messages.Game.Achievement;
using Cookie.API.Utils;

namespace Cookie.Game.Achievement
{
    public class Achievement : IAchievement
    {
        public Achievement(IAccount account)
        {
            account.Network.RegisterPacket<AchievementFinishedMessage>(HandleAchievementFinishedMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<AchievementRewardSuccessMessage>(HandleAchievementRewardSuccessMessage,
                MessagePriority.VeryHigh);
        }

        private void HandleAchievementFinishedMessage(IAccount account, AchievementFinishedMessage message)
        {
            var text = FastD2IReader.Instance.GetText(ObjectDataManager.Instance
                .Get<API.Datacenter.Achievement>(message.ObjectId).NameId);
            Logger.Default.Log($"Succés: {text} Dévérouillé");
            account.Network.SendToServer(new AchievementRewardRequestMessage((short) message.ObjectId));
        }

        private void HandleAchievementRewardSuccessMessage(IAccount account, AchievementRewardSuccessMessage message)
        {
            var text = FastD2IReader.Instance.GetText(ObjectDataManager.Instance
                .Get<API.Datacenter.Achievement>(message.AchievementId).NameId);
            Logger.Default.Log($"Succés: {text} Accepté!");
        }
    }
}