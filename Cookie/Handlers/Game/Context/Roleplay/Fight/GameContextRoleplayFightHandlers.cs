using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight;
using Cookie.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Handlers.Game.Context.Roleplay.Fight
{
    public class GameContextRoleplayFightHandlers
    {
        [MessageHandler(GameRolePlayAggressionMessage.ProtocolId)]
        private void GameRolePlayAggressionMessageHandler(DofusClient client, GameRolePlayAggressionMessage message)
        {
            //
        }

        [MessageHandler(GameRolePlayAttackMonsterRequestMessage.ProtocolId)]
        private void GameRolePlayAttackMonsterRequestMessageHandler(DofusClient client,
            GameRolePlayAttackMonsterRequestMessage message)
        {
            //
        }

        [MessageHandler(GameRolePlayFightRequestCanceledMessage.ProtocolId)]
        private void GameRolePlayFightRequestCanceledMessageHandler(DofusClient client,
            GameRolePlayFightRequestCanceledMessage message)
        {
            //
        }

        [MessageHandler(GameRolePlayPlayerFightFriendlyAnsweredMessage.ProtocolId)]
        private void GameRolePlayPlayerFightFriendlyAnsweredMessageHandler(DofusClient client,
            GameRolePlayPlayerFightFriendlyAnsweredMessage message)
        {
            if (!message.Accept)
                Logger.Default.Log("Fermeture de la demande de défi.", LogMessageType.Info);
        }

        [MessageHandler(GameRolePlayPlayerFightFriendlyRequestedMessage.ProtocolId)]
        private void GameRolePlayPlayerFightFriendlyRequestedMessageHandler(DofusClient client,
            GameRolePlayPlayerFightFriendlyRequestedMessage message)
        {
            Logger.Default.Log($"Le joueur id: {message.SourceId} vous défi.", LogMessageType.Info);
            Randomize.RunBetween(
                () => client.Send(new GameRolePlayPlayerFightFriendlyAnswerMessage(message.FightId, false)), 2000,
                4000);
        }

        [MessageHandler(GameRolePlayPlayerFightRequestMessage.ProtocolId)]
        private void GameRolePlayPlayerFightRequestMessageHandler(DofusClient client,
            GameRolePlayPlayerFightRequestMessage message)
        {
            //
        }

        [MessageHandler(GameRolePlayRemoveChallengeMessage.ProtocolId)]
        private void GameRolePlayRemoveChallengeMessageHandler(DofusClient client,
            GameRolePlayRemoveChallengeMessage message)
        {
            //
        }

        [MessageHandler(GameRolePlayShowChallengeMessage.ProtocolId)]
        private void GameRolePlayShowChallengeMessageHandler(DofusClient client,
            GameRolePlayShowChallengeMessage message)
        {
            //
        }
    }
}