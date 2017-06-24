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
            client.Logger.Log("Vous devez choisir un pseudo pour pouvoir vous connecter.", LogMessageType.Public);
            var random = new Random();
            var nickname = random.RandomString(10);
            var nicknameMessage = new NicknameChoiceRequestMessage(nickname);
            client.Send(nicknameMessage);
            client.Account.Nickname = nickname;
        }

        [MessageHandler(NicknameAcceptedMessage.ProtocolId)]
        private void NicknameAcceptedMessageHandler(DofusClient client, NicknameAcceptedMessage message)
        {
            client.Logger.Log($"Vous avez choisi le pseudo : {client.Account.Nickname}", LogMessageType.Info);
        }
    }
}
