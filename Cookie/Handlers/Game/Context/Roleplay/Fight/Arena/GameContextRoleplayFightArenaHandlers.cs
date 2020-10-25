using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Game.Context.Roleplay.Fight.Arena
{
    public class GameContextRoleplayFightArenaHandlers
    {
        [MessageHandler(GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage.ProtocolId)]
        private void GameRolePlayArenaUpdatePlayerInfosAllQueuesMessageHandler(DofusClient Client, GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage Message)
        {
            //
        }
    }
}
