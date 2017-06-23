using Cookie.Core;
using Cookie.Protocol.Network.Messages.Connection.Register;

namespace Cookie.Handlers.Connection.register
{
    class ConnectionRegisterHandler
    {
        [MessageHandler(NicknameRegistrationMessage.ProtocolId)]
        private void NicknameRegistrationMessageHandler(DofusClient client, NicknameRegistrationMessage message)
        {
           //
        }
    }
}
