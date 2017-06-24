using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest;

namespace Cookie.Handlers.Game.Context.Roleplay.Quest
{
    public class GameContextRoleplayQuestHandlers
    {
        [MessageHandler(FollowedQuestsMessage.ProtocolId)]
        private void FollowedQuestsMessageHandler(DofusClient client, FollowedQuestsMessage message)
        {
            //
        }
    }
}