using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Game.Context.Roleplay.Quest
{
    public class GameContextRoleplayQuestHandlers
    {
        [MessageHandler(FollowedQuestsMessage.ProtocolId)]
        private void FollowedQuestsMessageHandler(DofusClient Client, FollowedQuestsMessage Message)
        {
            //
        }
    }
}
