using Cookie.Core;
using Cookie.Protocol.Network.Messages;
using System.Linq;

namespace Cookie.Handlers.Game.Context
{
    public class GameContextHandlers
    {
        [MessageHandler(GameContextDestroyMessage.ProtocolId)]
        private void GameContextDestroyMessageHandler(DofusClient Client, GameContextDestroyMessage Message)
        {
            //
        }

        [MessageHandler(GameContextCreateMessage.ProtocolId)]
        private void GameContextCreateMessageHandler(DofusClient Client, GameContextCreateMessage Message)
        {
            //
        }

        [MessageHandler(GameContextRefreshEntityLookMessage.ProtocolId)]
        private void GameContextRefreshEntityLookMessageHandler(DofusClient Client, GameContextRefreshEntityLookMessage Message)
        {
            if (Message.Id_ == Client.Account.Character.Id)
                Client.Account.Character.Look = Message.Look;
        }

        [MessageHandler(GameContextRemoveElementMessage.ProtocolId)]
        private void GameContextRemoveElementMessageHandler(DofusClient Client, GameContextRemoveElementMessage Message)
        {
            //
        }

        [MessageHandler(GameMapChangeOrientationMessage.ProtocolId)]
        private void GameMapChangeOrientationMessageHandler(DofusClient Client, GameMapChangeOrientationMessage Message)
        {
            //
        }
        
        [MessageHandler(GameMapMovementMessage.ProtocolId)]
        private void GameMapMovementMessageHandler(DofusClient Client, GameMapMovementMessage Message)
        {
            if (Message.ActorId == Client.Account.Character.Id)
            {
                Client.Account.Character.Status = Utils.Enums.CharacterStatus.Moving;
                Client.Account.Character.CellId = Message.KeyMovements.Last();
            }
        }
    }
}
