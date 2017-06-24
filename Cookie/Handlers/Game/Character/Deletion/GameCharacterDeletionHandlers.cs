using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Character.Deletion;

namespace Cookie.Handlers.Game.Character.Deletion
{
    public class GameCharacterDeletionHandlers
    {
        [MessageHandler(CharacterDeletionErrorMessage.ProtocolId)]
        private void CharacterDeletionErrorMessageHandler(DofusClient client, CharacterDeletionErrorMessage message)
        {
            client.Logger.Log("Une erreur est survenue lors de la suppression du personnage.", LogMessageType.Info);
        }
    }
}