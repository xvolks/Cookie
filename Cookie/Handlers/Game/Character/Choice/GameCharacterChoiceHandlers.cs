using Cookie.Core;
using Cookie.Protocol.Network.Messages;
using Cookie.Protocol.Network.Types;
using System.Linq;

namespace Cookie.Handlers.Game.Character.Choice
{
    public class GameCharacterChoiceHandlers
    {
        [MessageHandler(BasicCharactersListMessage.ProtocolId)]
        private void BasicCharactersListMessageHandler(DofusClient Client, BasicCharactersListMessage Message)
        {
            CharacterBaseInformations c = Message.Characters.FirstOrDefault();
            Client.Logger.Log("Connexion sur le personnage " + c.Name);
            Client.Send(new CharacterSelectionMessage(c.Id_));
        }

        [MessageHandler(CharactersListMessage.ProtocolId)]
        private void CharactersListMessageHandler(DofusClient Client, CharactersListMessage Message)
        {
            CharacterBaseInformations c = Message.Characters.FirstOrDefault();
            Client.Logger.Log("Connexion sur le personnage " + c.Name);
            Client.Send(new CharacterSelectionMessage(c.Id_));
        }

        [MessageHandler(CharacterSelectedSuccessMessage.ProtocolId)]
        private void CharacterSelectedSuccessMessageHandler(DofusClient Client, CharacterSelectedSuccessMessage Message)
        {
            Client.Account.Character.Level = Message.Infos.Level;
            Client.Account.Character.Id = Message.Infos.Id_;
            Client.Account.Character.Name = Message.Infos.Name;
            Client.Account.Character.Sex = Message.Infos.Sex;
            Client.Account.Character.Look = Message.Infos.EntityLook_;
            Client.Account.Character.Breed = Message.Infos.Breed;

            Client.Send(new FriendsGetListMessage());
            Client.Send(new AcquaintancesGetListMessage());
            Client.Send(new IgnoredGetListMessage());
            Client.Send(new SpouseGetInformationsMessage());
            Client.Send(new ClientKeyMessage("y3JJiZ0geixj3GDmm2#01"));
            Client.Send(new GameContextCreateRequestMessage());
            //Client.Send(new ChannelEnablingMessage(7, false));
        }
    }
}
