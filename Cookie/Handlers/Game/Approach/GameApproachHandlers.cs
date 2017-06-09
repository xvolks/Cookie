using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Approach;
using Cookie.Protocol.Network.Messages.Game.Character.Choice;
using System.Threading;

namespace Cookie.Handlers.Game.Approach
{
    public class GameApproachHandlers
    {
        [MessageHandler(AuthenticationTicketAcceptedMessage.ProtocolId)]
        private void AuthenticationTicketAcceptedMessageHandler(DofusClient Client, AuthenticationTicketAcceptedMessage Message)
        {
            Thread.Sleep(500);
            Client.Send(new CharactersListRequestMessage());
        }

        [MessageHandler(HelloGameMessage.ProtocolId)]
        private void HelloGameMessageHandler(DofusClient Client, HelloGameMessage Message)
        {
            Client.Logger.Log("Connecté au serveur de jeu.");
            AuthenticationTicketMessage ATM = new AuthenticationTicketMessage("fr", Client.Account.Ticket);
            Client.Send(ATM);
        }

        [MessageHandler(AccountCapabilitiesMessage.ProtocolId)]
        private void AccountCapabilitiesMessageHandler(DofusClient Client, AccountCapabilitiesMessage Message)
        {
            //
        }

        [MessageHandler(ServerSettingsMessage.ProtocolId)]
        private void ServerSettingsMessageHandler(DofusClient Client, ServerSettingsMessage Message)
        {
            //
        }

        [MessageHandler(ServerOptionalFeaturesMessage.ProtocolId)]
        private void ServerOptionalFeaturesMessageHandler(DofusClient Client, ServerOptionalFeaturesMessage Message)
        {
            //
        }

        [MessageHandler(ServerSessionConstantsMessage.ProtocolId)]
        private void ServerSessionConstantsMessageHandler(DofusClient Client, ServerSessionConstantsMessage Message)
        {
            //
        }
    }
}
