using Cookie.API.Network;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Character.Choice;
using Cookie.API.Protocol.Network.Messages.Game.Character.Creation;
using Cookie.Core;

namespace Cookie.Handlers.Game.Character.Choice
{
    public class GameCharacterChoiceHandlers
    {
        [MessageHandler(BasicCharactersListMessage.ProtocolId)]
        private void BasicCharactersListMessageHandler(DofusClient client, BasicCharactersListMessage message)
        {
            if (message.Characters.Count == 0)
            {
                client.Send(new CharacterNameSuggestionRequestMessage());
            }
            else
            {
                var c = message.Characters[0];
                Logger.Default.Log("Connexion sur le personnage " + c.Name);

                client.Send(client.Account.Character.IsFirstConnection == false
                    ? new CharacterSelectionMessage(c.ObjectID)
                    : new CharacterFirstSelectionMessage(false, c.ObjectID));
            }
        }


        [MessageHandler(CharactersListMessage.ProtocolId)]
        private void CharactersListMessageHandler(DofusClient client, CharactersListMessage message)
        {
            if (message.Characters.Count == 0)
            {
                Logger.Default.Log("Pas de personnage.");
                Logger.Default.Log("Création du personnage en cours.");
                client.Send(new CharacterNameSuggestionRequestMessage());
            }
            else
            {
                var c = message.Characters[0];
                Logger.Default.Log("Connexion sur le personnage " + c.Name);

                client.Send(client.Account.Character.IsFirstConnection == false
                    ? new CharacterSelectionMessage(c.ObjectID)
                    : new CharacterFirstSelectionMessage(false, c.ObjectID));
            }
        }

        [MessageHandler(CharacterSelectedSuccessMessage.ProtocolId)]
        private void CharacterSelectedSuccessMessageHandler(DofusClient client, CharacterSelectedSuccessMessage message)
        {
            client.Account.Character.Level = message.Infos.Level;
            client.Account.Character.Id = message.Infos.ObjectID;
            client.Account.Character.Name = message.Infos.Name;
            client.Account.Character.Sex = message.Infos.Sex;
            client.Account.Character.Look = message.Infos.EntityLook;
            client.Account.Character.Breed = (BreedEnum)message.Infos.Breed;
        }

        [MessageHandler(CharacterSelectedForceMessage.ProtocolId)]
        private void CharacterSelectedForceMessageHandler(DofusClient client, CharacterSelectedForceMessage message)
        {
            //
        }
    }
}