using Cookie.Core;
using Cookie.Protocol.Network.Messages.Connection.Register;

namespace Cookie.Handlers.Connection.Register
{
    public class ConnectionRegisterHandlers
    {
        [MessageHandler(NicknameRegistrationMessage.ProtocolId)]
        private void NicknameRegistrationMessageHandler(DofusClient client, NicknameRegistrationMessage message)
        {
            client.Logger.Log("Vous devez choisir un pseudo pour pouvoir vous connecter.");
        }
    }
}
