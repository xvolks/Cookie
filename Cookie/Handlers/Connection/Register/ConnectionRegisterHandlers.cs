using System;
using Cookie.Core;
using Cookie.Protocol.Network.Messages.Connection.Register;
using Cookie.Utils;
using Cookie.Utils.Extensions;

namespace Cookie.Handlers.Connection.Register
{
    public class ConnectionRegisterHandlers
    {
        [MessageHandler(NicknameRegistrationMessage.ProtocolId)]
        private void NicknameRegistrationMessageHandler(DofusClient client, NicknameRegistrationMessage message)
        {
            /*
             * On reçoit ce packet sur un nouveau compte, il faut donc générer aléatoirement un pseudo afin de poursuivre le jeu.
             */
            client.Logger.Log("Vous devez choisir un pseudo pour pouvoir vous connecter.", LogMessageType.Public);
            // Ici on génère donc un pseudo de 10 caractères aléatoires.
            var random = new Random();
            var nickname = random.RandomString(10);
            // On envois ce choix de pseudo au serveur de Dofus.
            var nicknameMessage = new NicknameChoiceRequestMessage(nickname);
            client.Send(nicknameMessage);
            // On définit le pseudo dans notre classe client.
            client.Account.Nickname = nickname;
        }

        [MessageHandler(NicknameAcceptedMessage.ProtocolId)]
        private void NicknameAcceptedMessageHandler(DofusClient client, NicknameAcceptedMessage message)
        {
            // Notre pseudo est bien accepté, on affiche un message.
            client.Logger.Log($"Vous avez choisi le pseudo : {client.Account.Nickname}", LogMessageType.Info);
        }
    }
}
