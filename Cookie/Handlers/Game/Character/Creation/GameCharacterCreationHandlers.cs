using System.Linq;
using Cookie.API.Datacenter;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Network;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Character.Creation;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Core;

namespace Cookie.Handlers.Game.Character.Creation
{
    public class GameCharacterCreationHandlers
    {
        [MessageHandler(CharacterCanBeCreatedResultMessage.ProtocolId)]
        private void CharacterStatsListMessageHandler(DofusClient client, CharacterCanBeCreatedResultMessage message)
        {
            // Si nous ne pouvons pas créer de personnages, nous arrêtons la fonction
            if (!message.YesYouCan) return;
            // Sinon, nous choisissons une classe au hasard 
            var breedId = (byte) Randomize.GetRandomNumber(1, 18);
            // Nous récupérons les informations de la classe avec les D2O
            var breed = ObjectDataManager.Instance.Get<Breed>(breedId);
            // Nous récupérons la couleur de base de la classe, et nous faisons un léger random sur la couleur
            var breedColors = breed.MaleColors.Select(i => Randomize.GetRandomNumber((int) i - 80000, (int) i + 80000))
                .ToList();
            // On récupère la liste des cosmetics disponibles pour cette classe et ce sexe
            var headsList = ObjectDataManager.Instance.EnumerateObjects<Head>().ToList()
                .FindAll(h => h.Breed == breedId && h.Gender == 0);
            // Nous selectionnons au hasard un cosmetics dans la liste
            var head = headsList[Randomize.GetRandomNumber(0, 7)];
            //// Nous envoyons la requête pour créer le personnage
            var test = new CharacterCreationRequestMessage(client.Account.Character.Name, breedId, false, breedColors,
                (ushort) head.Id);
            client.Send(test);
        }

        [MessageHandler(CharacterCreationResultMessage.ProtocolId)]
        private void CharacterCreationResultMessageHandler(DofusClient client, CharacterCreationResultMessage message)
        {
            switch ((CharacterCreationResultEnum) message.Result)
            {
                case CharacterCreationResultEnum.OK:
                    client.Account.Character.IsFirstConnection = true;
                    break;
                case CharacterCreationResultEnum.ERR_NO_REASON:
                    break;
                case CharacterCreationResultEnum.ERR_INVALID_NAME:
                    Logger.Default.Log("Ce nom de personnage est invalide.", LogMessageType.Public);
                    client.Dispose();
                    break;
                case CharacterCreationResultEnum.ERR_NAME_ALREADY_EXISTS:
                    Logger.Default.Log("Ce nom de personnage est déjà pris.", LogMessageType.Public);
                    client.Dispose();
                    break;
                case CharacterCreationResultEnum.ERR_TOO_MANY_CHARACTERS:
                    Logger.Default.Log("Vous avez déjà atteint la limite de personnages disponible.",
                        LogMessageType.Public);
                    client.Dispose();
                    break;
                case CharacterCreationResultEnum.ERR_NOT_ALLOWED:
                    break;
                case CharacterCreationResultEnum.ERR_NEW_PLAYER_NOT_ALLOWED:
                    break;
                case CharacterCreationResultEnum.ERR_RESTRICED_ZONE:
                    break;
                case CharacterCreationResultEnum.ERR_INCONSISTENT_COMMUNITY:
                    break;
            }
        }

        [MessageHandler(CharacterNameSuggestionFailureMessage.ProtocolId)]
        private void CharacterNameSuggestionFailureMessageHandler(DofusClient client,
            CharacterNameSuggestionFailureMessage message)
        {
            Logger.Default.Log($"{message.Reason}", LogMessageType.Public);
            client.Dispose();
        }

        [MessageHandler(CharacterNameSuggestionSuccessMessage.ProtocolId)]
        private void CharacterNameSuggestionSuccessMessageHandler(DofusClient client,
            CharacterNameSuggestionSuccessMessage message)
        {
            Logger.Default.Log($"Pseudo Suggérer: {message.Suggestion}");
            client.Account.Character.Name = message.Suggestion;

            var test = new CharacterCanBeCreatedRequestMessage();
            client.Send(test);
        }
    }
}