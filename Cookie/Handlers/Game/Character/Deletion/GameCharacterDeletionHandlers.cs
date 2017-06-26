using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Character.Deletion;
using Cookie.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Handlers.Game.Character.Deletion
{
    public class GameCharacterDeletionHandlers
    {
        [MessageHandler(CharacterDeletionErrorMessage.ProtocolId)]
        private void CharacterDeletionErrorMessageHandler(DofusClient client, CharacterDeletionErrorMessage message)
        {
            Logger.Default.Log("Une erreur est survenue lors de la suppression du personnage.", LogMessageType.Info);
        }
    }
}