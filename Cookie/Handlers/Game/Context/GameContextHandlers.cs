using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context;
using System.Linq;

namespace Cookie.Handlers.Game.Context
{
    public class GameContextHandlers
    {
        [MessageHandler(GameContextDestroyMessage.ProtocolId)]
        private void GameContextDestroyMessageHandler(DofusClient client, GameContextDestroyMessage message)
        {
            //
        }

        [MessageHandler(GameContextCreateMessage.ProtocolId)]
        private void GameContextCreateMessageHandler(DofusClient client, GameContextCreateMessage message)
        {
            //
        }

        [MessageHandler(GameContextRefreshEntityLookMessage.ProtocolId)]
        private void GameContextRefreshEntityLookMessageHandler(DofusClient client, GameContextRefreshEntityLookMessage message)
        {
            if (message.ObjectId == client.Account.Character.Id)
                client.Account.Character.Look = message.Look;
        }

        [MessageHandler(GameContextRemoveElementMessage.ProtocolId)]
        private void GameContextRemoveElementMessageHandler(DofusClient client, GameContextRemoveElementMessage message)
        {
            client.Account.Character.MapData.RemoveActor(message.ObjectId);
        }

        [MessageHandler(GameMapChangeOrientationMessage.ProtocolId)]
        private void GameMapChangeOrientationMessageHandler(DofusClient client, GameMapChangeOrientationMessage message)
        {
            //
        }

        [MessageHandler(GameMapMovementMessage.ProtocolId)]
        private void GameMapMovementMessageHandler(DofusClient client, GameMapMovementMessage message)
        {
            if (message.ActorId == client.Account.Character.Id)
            {
                client.Account.Character.Status = Utils.Enums.CharacterStatus.Moving;
                client.Account.Character.CellId = message.KeyMovements.Last();
            }
            client.Account.Character.MapData.RefreshActor(message.ActorId, message.KeyMovements.Last());
        }
    }
}
