using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay.Fight;

namespace Cookie.Handlers.Game.Context.Roleplay.Fight
{
    public class GameContextRoleplayFightHandlers
    {
        [MessageHandler(GameRolePlayRemoveChallengeMessage.ProtocolId)]
        private void GameRolePlayRemoveChallengeMessageHandler(DofusClient client, GameRolePlayRemoveChallengeMessage message)
        {
            //
        }
    }
}
