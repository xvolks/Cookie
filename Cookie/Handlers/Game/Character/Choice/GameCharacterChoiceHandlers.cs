using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Character.Choice;
using Cookie.Protocol.Network.Types.Game.Character.Choice;

namespace Cookie.Handlers.Game.Character.Choice
{
    public class GameCharacterChoiceHandlers
    {
        [MessageHandler(BasicCharactersListMessage.ProtocolId)]
        private void BasicCharactersListMessageHandler(DofusClient Client, BasicCharactersListMessage Message)
        {
            CharacterBaseInformations c = Message.Characters[0];
            Client.Logger.Log("Connexion sur le personnage " + c.Name);
            Client.Send(new CharacterSelectionMessage(c.ObjectID));
        }

        [MessageHandler(CharactersListMessage.ProtocolId)]
        private void CharactersListMessageHandler(DofusClient Client, CharactersListMessage Message)
        {
            CharacterBaseInformations c = Message.Characters[0];
            Client.Logger.Log("Connexion sur le personnage " + c.Name);
            Client.Send(new CharacterSelectionMessage(c.ObjectID));
        }

        [MessageHandler(CharacterSelectedSuccessMessage.ProtocolId)]
        private void CharacterSelectedSuccessMessageHandler(DofusClient Client, CharacterSelectedSuccessMessage Message)
        {
            Client.Account.Character.Level = Message.Infos.Level;
            Client.Account.Character.Id = Message.Infos.ObjectID;
            Client.Account.Character.Name = Message.Infos.Name;
            Client.Account.Character.Sex = Message.Infos.Sex;
            Client.Account.Character.Look = Message.Infos.EntityLook;
            Client.Account.Character.Breed = Message.Infos.Breed;
        }
    }
}
