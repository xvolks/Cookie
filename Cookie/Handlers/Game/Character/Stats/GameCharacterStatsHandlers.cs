using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Character.Stats;
using Cookie.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Handlers.Game.Character.Stats
{
    public class GameCharacterStatsHandlers
    {
        [MessageHandler(CharacterStatsListMessage.ProtocolId)]
        private void CharacterStatsListMessageHandler(DofusClient client, CharacterStatsListMessage message)
        {
            client.Account.Character.Stats = message.Stats;
        }

        [MessageHandler(CharacterExperienceGainMessage.ProtocolId)]
        private void CharacterExperienceGainMessageHandler(DofusClient client, CharacterExperienceGainMessage message)
        {
            if (message.ExperienceCharacter != 0)
            {
                client.Account.Character.Stats.Experience += message.ExperienceCharacter;
                Logger.Default.Log($"Vous avez gagné {message.ExperienceCharacter} points d'expérience.",
                    LogMessageType.Info);
            }
            if (message.ExperienceGuild != 0)
                Logger.Default.Log($"Votre guilde a gagné {message.ExperienceGuild} points d'expérience.",
                    LogMessageType.Info);
            if (message.ExperienceMount != 0)
                Logger.Default.Log($"Vous monture a gagné {message.ExperienceMount} points d'expérience.",
                    LogMessageType.Info);
        }

        [MessageHandler(CharacterLevelUpInformationMessage.ProtocolId)]
        private void CharacterLevelUpInformationMessageHandler(DofusClient client,
            CharacterLevelUpInformationMessage message)
        {
            Logger.Default.Log($"{message.Name} viens de passer niveau {message.NewLevel}.", LogMessageType.Info);
        }

        [MessageHandler(CharacterLevelUpMessage.ProtocolId)]
        private void CharacterLevelUpMessageHandler(DofusClient client, CharacterLevelUpMessage message)
        {
            Logger.Default.Log($"Vous venez de passer niveau {message.NewLevel}.", LogMessageType.Info);
            client.Account.Character.Level = message.NewLevel;
        }

        [MessageHandler(LifePointsRegenBeginMessage.ProtocolId)]
        private void LifePointsRegenBeginMessageHandler(DofusClient client, LifePointsRegenBeginMessage message)
        {
            //
        }

        [MessageHandler(LifePointsRegenEndMessage.ProtocolId)]
        private void LifePointsRegenEndMessageHandler(DofusClient client, LifePointsRegenEndMessage message)
        {
            client.Account.Character.Stats.LifePoints = message.LifePoints;
            client.Account.Character.Stats.MaxLifePoints = message.MaxLifePoints;
            if (message.LifePointsGained != 0)
                Logger.Default.Log($"Vous avez récupéré {message.LifePointsGained} points de vie.",
                    LogMessageType.Info);
        }

        [MessageHandler(UpdateLifePointsMessage.ProtocolId)]
        private void UpdateLifePointsMessageHandler(DofusClient client, UpdateLifePointsMessage message)
        {
            client.Account.Character.Stats.LifePoints = message.LifePoints;
            client.Account.Character.Stats.MaxLifePoints = message.MaxLifePoints;
        }

        [MessageHandler(FighterStatsListMessage.ProtocolId)]
        private void FighterStatsListMessageHandler(DofusClient client, FighterStatsListMessage message)
        {
            client.Account.Character.Stats = message.Stats;
        }
    }
}