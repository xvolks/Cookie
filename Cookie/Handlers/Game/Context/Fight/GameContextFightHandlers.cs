using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Context.Fight;
using Cookie.Core;

namespace Cookie.Handlers.Game.Context.Fight
{
    public class GameContextFightHandlers
    {
        [MessageHandler(GameFightEndMessage.ProtocolId)]
        private void GameFightEndMessageHandler(DofusClient client, GameFightEndMessage message)
        {
            client.Logger.Log("Fin du combat en : " + message.Duration / 1000 + " secondes. ", LogMessageType.FightLog);
        }

        [MessageHandler(GameFightHumanReadyStateMessage.ProtocolId)]
        private void GameFightHumanReadyStateMessageHandler(DofusClient client, GameFightHumanReadyStateMessage message)
        {
            //
        }

        [MessageHandler(GameFightJoinMessage.ProtocolId)]
        private void GameFightJoinMessageHandler(DofusClient client, GameFightJoinMessage message)
        {
            //
        }

        [MessageHandler(GameFightLeaveMessage.ProtocolId)]
        private void GameFightLeaveMessageHandler(DofusClient client, GameFightLeaveMessage message)
        {
            //
        }

        [MessageHandler(GameFightNewRoundMessage.ProtocolId)]
        private void GameFightNewRoundMessageHandler(DofusClient client, GameFightNewRoundMessage message)
        {
            client.Logger.Log("Nouveau tour : " + message.RoundNumber, LogMessageType.FightLog);
        }

        [MessageHandler(GameFightNewWaveMessage.ProtocolId)]
        private void GameFightNewWaveMessageHandler(DofusClient client, GameFightNewWaveMessage message)
        {
            client.Logger.Log("Nombre de tours avant la prochaine vague : " + message.NbTurnBeforeNextWave,
                LogMessageType.FightLog);
        }

        [MessageHandler(GameFightOptionStateUpdateMessage.ProtocolId)]
        private void GameFightOptionStateUpdateMessageHandler(DofusClient client,
            GameFightOptionStateUpdateMessage message)
        {
            //
        }

        [MessageHandler(GameFightPlacementPossiblePositionsMessage.ProtocolId)]
        private void GameFightPlacementPossiblePositionsMessageHandler(DofusClient client,
            GameFightPlacementPossiblePositionsMessage message)
        {
            //
        }

        [MessageHandler(GameFightPlacementSwapPositionsCancelledMessage.ProtocolId)]
        private void GameFightPlacementSwapPositionsCancelledMessageHandler(DofusClient client,
            GameFightPlacementSwapPositionsCancelledMessage message)
        {
            //
        }

        [MessageHandler(GameFightPlacementSwapPositionsErrorMessage.ProtocolId)]
        private void GameFightPlacementSwapPositionsErrorMessageHandler(DofusClient client,
            GameFightPlacementSwapPositionsErrorMessage message)
        {
            //
        }

        [MessageHandler(GameFightPlacementSwapPositionsMessage.ProtocolId)]
        private void GameFightPlacementSwapPositionsMessageHandler(DofusClient client,
            GameFightPlacementSwapPositionsMessage message)
        {
            //
        }

        [MessageHandler(GameFightPlacementSwapPositionsOfferMessage.ProtocolId)]
        private void GameFightPlacementSwapPositionsOfferMessageHandler(DofusClient client,
            GameFightPlacementSwapPositionsOfferMessage message)
        {
            //
        }

        [MessageHandler(GameFightRemoveTeamMemberMessage.ProtocolId)]
        private void GameFightRemoveTeamMemberMessageHandler(DofusClient client,
            GameFightRemoveTeamMemberMessage message)
        {
            //
        }

        [MessageHandler(GameFightResumeMessage.ProtocolId)]
        private void GameFightResumeMessageHandler(DofusClient client, GameFightResumeMessage message)
        {
            client.Logger.Log("Tour(s): (" + message.GameTurn + ")", LogMessageType.FightLog);
        }

        [MessageHandler(GameFightResumeWithSlavesMessage.ProtocolId)]
        private void GameFightResumeWithSlavesMessageHandler(DofusClient client,
            GameFightResumeWithSlavesMessage message)
        {
            //
        }

        [MessageHandler(GameFightSpectateMessage.ProtocolId)]
        private void GameFightSpectateMessageHandler(DofusClient client, GameFightSpectateMessage message)
        {
            //
        }

        [MessageHandler(GameFightSpectatePlayerRequestMessage.ProtocolId)]
        private void GameFightSpectatePlayerRequestMessageHandler(DofusClient client,
            GameFightSpectatePlayerRequestMessage message)
        {
            client.Logger.Log("Un spectateur a rejoint le combat.", LogMessageType.FightLog);
        }

        [MessageHandler(GameFightStartingMessage.ProtocolId)]
        private void GameFightStartingMessageHandler(DofusClient client, GameFightStartingMessage message)
        {
            client.Logger.Log("Le combat a commencé !", LogMessageType.FightLog);
        }

        [MessageHandler(GameFightStartMessage.ProtocolId)]
        private void GameFightStartMessageHandler(DofusClient client, GameFightStartMessage message)
        {
            //
        }

        [MessageHandler(GameFightSynchronizeMessage.ProtocolId)]
        private void GameFightSynchronizeMessageHandler(DofusClient client, GameFightSynchronizeMessage message)
        {
            //
        }

        [MessageHandler(GameFightTurnEndMessage.ProtocolId)]
        private void GameFightTurnEndMessageHandler(DofusClient client, GameFightTurnEndMessage message)
        {
            client.Logger.Log("Fin du tour.", LogMessageType.FightLog);
        }

        [MessageHandler(GameFightTurnListMessage.ProtocolId)]
        private void GameFightTurnListMessageHandler(DofusClient client, GameFightTurnListMessage message)
        {
            //
        }

        [MessageHandler(GameFightTurnReadyRequestMessage.ProtocolId)]
        private void GameFightTurnReadyRequestMessageHandler(DofusClient client,
            GameFightTurnReadyRequestMessage message)
        {
            client.Logger.Log("A votre tour de jouer.", LogMessageType.FightLog);
        }

        [MessageHandler(GameFightTurnResumeMessage.ProtocolId)]
        private void GameFightTurnResumeMessageHandler(DofusClient client, GameFightTurnResumeMessage message)
        {
            //
        }

        [MessageHandler(GameFightTurnStartMessage.ProtocolId)]
        private void GameFightTurnStartMessageHandler(DofusClient client, GameFightTurnStartMessage message)
        {
            //
        }

        [MessageHandler(GameFightTurnStartPlayingMessage.ProtocolId)]
        private void GameFightTurnStartPlayingMessageHandler(DofusClient client,
            GameFightTurnStartPlayingMessage message)
        {
            //
        }

        [MessageHandler(GameFightUpdateTeamMessage.ProtocolId)]
        private void GameFightUpdateTeamMessageHandler(DofusClient client, GameFightUpdateTeamMessage message)
        {
            //
        }

        [MessageHandler(RefreshCharacterStatsMessage.ProtocolId)]
        private void RefreshCharacterStatsMessageHandler(DofusClient client, RefreshCharacterStatsMessage message)
        {
            //
        }

        [MessageHandler(SlaveSwitchContextMessage.ProtocolId)]
        private void SlaveSwitchContextMessageHandler(DofusClient client, SlaveSwitchContextMessage message)
        {
            //
        }
    }
}