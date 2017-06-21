using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Character.Creation;

namespace Cookie.Handlers.Game.Character.Creation
{
    public class GameCharacterCreationHandlers
    {
        [MessageHandler(CharacterCanBeCreatedResultMessage.ProtocolId)]
        private void CharacterStatsListMessageHandler(DofusClient client, CharacterCanBeCreatedResultMessage message)
        {
            //
        }

        [MessageHandler(CharacterCreationResultMessage.ProtocolId)]
        private void CharacterCreationResultMessageHandler(DofusClient client, CharacterCreationResultMessage message)
        {
            //
        }

        [MessageHandler(CharacterNameSuggestionFailureMessage.ProtocolId)]
        private void CharacterNameSuggestionFailureMessageHandler(DofusClient client,
            CharacterNameSuggestionFailureMessage message)
        {
            //
        }

        [MessageHandler(CharacterNameSuggestionSuccessMessage.ProtocolId)]
        private void CharacterNameSuggestionSuccessMessageHandler(DofusClient client,
            CharacterNameSuggestionSuccessMessage message)
        {
            //
        }
    }
}