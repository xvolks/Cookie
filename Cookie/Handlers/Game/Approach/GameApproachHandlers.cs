using com.sun.tools.javac.util;
using Cookie.Core;
using Cookie.Protocol.Network.Messages;
using org.omg.IOP;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Cookie.Handlers.Game.Approach
{
    public class GameApproachHandlers
    {
        [MessageHandler(AuthenticationTicketAcceptedMessage.ProtocolId)]
        private void AuthenticationTicketAcceptedMessageHandler(DofusClient Client, AuthenticationTicketAcceptedMessage Message)
        {
            Client.Send(new CharactersListRequestMessage());
        }

        [MessageHandler(HelloGameMessage.ProtocolId)]
        private void HelloGameMessageHandler(DofusClient Client, HelloGameMessage Message)
        {
            Client.Logger.Log("Connecté au serveur de jeu.");
            List<string> list = new List<string>();
            Client.Account.Ticket.ForEach(x => {
                list.Add(x.ToString());
            });
            AuthenticationTicketMessage ATM = new AuthenticationTicketMessage("fr", string.Join(",",list));
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
