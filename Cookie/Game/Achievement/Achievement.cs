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
        }

        private void HandleAchievementFinishedMessage(IAccount account, AchievementFinishedMessage message)
        {
            var text = FastD2IReader.Instance.GetText(ObjectDataManager.Instance
                .Get<API.Datacenter.Achievement>(message.ObjectId).NameId);
            Logger.Default.Log($"Succés {text} obtenu");
        }
    }
}