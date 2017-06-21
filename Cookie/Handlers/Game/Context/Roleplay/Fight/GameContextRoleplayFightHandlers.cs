using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay.Fight;

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
        private void GameRolePlayAttackMonsterRequestMessageHandler(DofusClient client, GameRolePlayAttackMonsterRequestMessage message)
        {
            //
        }
        [MessageHandler(GameRolePlayFightRequestCanceledMessage.ProtocolId)]
        private void GameRolePlayFightRequestCanceledMessageHandler(DofusClient client, GameRolePlayFightRequestCanceledMessage message)
        {
            //
        }
        [MessageHandler(GameRolePlayPlayerFightFriendlyAnsweredMessage.ProtocolId)]
        private void GameRolePlayPlayerFightFriendlyAnsweredMessageHandler(DofusClient client, GameRolePlayPlayerFightFriendlyAnsweredMessage message)
        {
            if (!message.Accept)
                client.Logger.Log($"Le joueur a annulé le défie.", LogMessageType.Info);
        }
       
        [MessageHandler(GameRolePlayPlayerFightFriendlyRequestedMessage.ProtocolId)]
        private void GameRolePlayPlayerFightFriendlyRequestedMessageHandler(DofusClient client, GameRolePlayPlayerFightFriendlyRequestedMessage message)
        {
            client.Logger.Log($"Le joueur id: {message.SourceId} vous défie.", LogMessageType.Info);           
            client.Send(new GameRolePlayPlayerFightFriendlyAnswerMessage(message.FightId, false));
        }
        [MessageHandler(GameRolePlayPlayerFightRequestMessage.ProtocolId)]
        private void GameRolePlayPlayerFightRequestMessageHandler(DofusClient client, GameRolePlayPlayerFightRequestMessage message)
        {
            //
        }
        [MessageHandler(GameRolePlayRemoveChallengeMessage.ProtocolId)]
        private void GameRolePlayRemoveChallengeMessageHandler(DofusClient client, GameRolePlayRemoveChallengeMessage message)
        {
            //
        }
        [MessageHandler(GameRolePlayShowChallengeMessage.ProtocolId)]
        private void GameRolePlayShowChallengeMessageHandler(DofusClient client, GameRolePlayShowChallengeMessage message)
        {
            //
        }
    }
}
