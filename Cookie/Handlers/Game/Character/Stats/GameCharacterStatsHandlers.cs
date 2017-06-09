using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Character.Stats;

namespace Cookie.Handlers.Game.Character.Stats
{
    public class GameCharacterStatsHandlers
    {
        [MessageHandler(CharacterStatsListMessage.ProtocolId)]
        private void CharacterStatsListMessageHandler(DofusClient Client, CharacterStatsListMessage Message)
        {
            Client.Account.Character.Stats = Message.Stats;
        }

        [MessageHandler(CharacterExperienceGainMessage.ProtocolId)]
        private void CharacterExperienceGainMessageHandler(DofusClient Client, CharacterExperienceGainMessage Message)
        {
            if (Message.ExperienceCharacter != 0)
            {
                Client.Account.Character.Stats.Experience += Message.ExperienceCharacter;
                Client.Logger.Log($"Vous avez gagné {Message.ExperienceCharacter} points d'expérience.", LogMessageType.Info);
            }
            if (Message.ExperienceGuild != 0)
                Client.Logger.Log($"Votre guilde a gagné {Message.ExperienceGuild} points d'expérience.", LogMessageType.Info);
            if (Message.ExperienceMount != 0)
                Client.Logger.Log($"Vous monture a gagné {Message.ExperienceMount} points d'expérience.", LogMessageType.Info);
        }

        [MessageHandler(CharacterLevelUpInformationMessage.ProtocolId)]
        private void CharacterLevelUpInformationMessageHandler(DofusClient Client, CharacterLevelUpInformationMessage Message)
        {
            Client.Logger.Log($"{Message.Name} viens de passer niveau {Message.NewLevel}.", LogMessageType.Info);
        }

        [MessageHandler(CharacterLevelUpMessage.ProtocolId)]
        private void CharacterLevelUpMessageHandler(DofusClient Client, CharacterLevelUpMessage Message)
        {
            Client.Logger.Log($"Vous venez de passer niveau {Message.NewLevel}.", LogMessageType.Info);
            Client.Account.Character.Level = Message.NewLevel;
        }

        [MessageHandler(LifePointsRegenBeginMessage.ProtocolId)]
        private void LifePointsRegenBeginMessageHandler(DofusClient Client, LifePointsRegenBeginMessage Message)
        {
            //
        }

        [MessageHandler(LifePointsRegenEndMessage.ProtocolId)]
        private void LifePointsRegenEndMessageHandler(DofusClient Client, LifePointsRegenEndMessage Message)
        {
            Client.Account.Character.Stats.LifePoints = Message.LifePoints;
            Client.Account.Character.Stats.MaxLifePoints = Message.MaxLifePoints;
            if (Message.LifePointsGained != 0)
                Client.Logger.Log($"Vous avez récupéré {Message.LifePointsGained} points de vie.", LogMessageType.Info);
        }

        [MessageHandler(UpdateLifePointsMessage.ProtocolId)]
        private void UpdateLifePointsMessageHandler(DofusClient Client, UpdateLifePointsMessage Message)
        {
            Client.Account.Character.Stats.LifePoints = Message.LifePoints;
            Client.Account.Character.Stats.MaxLifePoints = Message.MaxLifePoints;
        }

        [MessageHandler(FighterStatsListMessage.ProtocolId)]
        private void FighterStatsListMessageHandler(DofusClient Client, FighterStatsListMessage Message)
        {
            Client.Account.Character.Stats = Message.Stats;
        }
    }
}
