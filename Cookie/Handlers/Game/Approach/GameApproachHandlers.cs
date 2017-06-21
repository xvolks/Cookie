using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Approach;
using Cookie.Protocol.Network.Messages.Game.Character.Choice;
using System.Threading;

namespace Cookie.Handlers.Game.Approach
{
    public class GameApproachHandlers
    {
        [MessageHandler(AuthenticationTicketAcceptedMessage.ProtocolId)]
        private void AuthenticationTicketAcceptedMessageHandler(DofusClient client, AuthenticationTicketAcceptedMessage message)
        {
            Thread.Sleep(500);
            client.Send(new CharactersListRequestMessage());
        }

        [MessageHandler(HelloGameMessage.ProtocolId)]
        private void HelloGameMessageHandler(DofusClient client, HelloGameMessage message)
        {
            client.Logger.Log("Connecté au serveur de jeu.");
            AuthenticationTicketMessage atm = new AuthenticationTicketMessage("fr", client.Account.Ticket);
            client.Send(atm);
        }

        [MessageHandler(AccountCapabilitiesMessage.ProtocolId)]
        private void AccountCapabilitiesMessageHandler(DofusClient client, AccountCapabilitiesMessage message)
        {
            //
        }

        [MessageHandler(ServerSettingsMessage.ProtocolId)]
        private void ServerSettingsMessageHandler(DofusClient client, ServerSettingsMessage message)
        {
            //
        }

        [MessageHandler(ServerOptionalFeaturesMessage.ProtocolId)]
        private void ServerOptionalFeaturesMessageHandler(DofusClient client, ServerOptionalFeaturesMessage message)
        {
            //
        }

        [MessageHandler(ServerSessionConstantsMessage.ProtocolId)]
        private void ServerSessionConstantsMessageHandler(DofusClient client, ServerSessionConstantsMessage message)
        {
            //
        }
    }
}
