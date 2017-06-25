using System.Linq;
using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Context;
using Cookie.Core;
using Cookie.Utils.Enums;

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
        private void GameContextRefreshEntityLookMessageHandler(DofusClient client,
            GameContextRefreshEntityLookMessage message)
        {
            if (message.ObjectId == client.Account.Character.Id)
                client.Account.Character.Look = message.Look;
        }

        [MessageHandler(GameContextRemoveElementMessage.ProtocolId)]
        private void GameContextRemoveElementMessageHandler(DofusClient client, GameContextRemoveElementMessage message)
        {
            client.Account.Character.Map.RemoveEntity((int)message.ObjectId);
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
                client.Account.Character.Status = CharacterStatus.Moving;
                client.Account.Character.CellId = message.KeyMovements.Last();
            }
            client.Account.Character.Map.UpdateEntity(message);
        }

        [MessageHandler(GameMapNoMovementMessage.ProtocolId)]
        private void GameMapNoMovementMessageHandler(DofusClient client, GameMapNoMovementMessage message)
        {
            Logger.Default.Log("Erreur lors du déplacement sur cellX : " + message.CellX + "cellY : " + message.CellY);
            client.Account.Character.Status = CharacterStatus.None;
        }

        [MessageHandler(GameEntitiesDispositionMessage.ProtocolId)]
        private void GameEntitiesDispositionMessageHandler(DofusClient client, GameEntitiesDispositionMessage message)
        {
            var _ListDispositions = message.Dispositions;
            foreach (var player in _ListDispositions)
                if (player.ObjectId == client.Account.Character.Id)
                    Logger.Default.Log("Actualisation des joueurs: Vous êtes sur la cellID: " + player.CellId);
        }
    }
}