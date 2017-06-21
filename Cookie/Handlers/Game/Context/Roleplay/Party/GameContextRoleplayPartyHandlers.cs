using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay.Party;

namespace Cookie.Handlers.Game.Context.Roleplay.Party
{
    public class GameContextRoleplayPartyHandlers
    {
        [MessageHandler(PartyInvitationMessage.ProtocolId)]
        private void PartyInvitationMessageHandler(DofusClient client, PartyInvitationMessage message)
        {
            client.Logger.Log($"Le joueur {message.FromName} vous invite dans son groupe.", LogMessageType.Info);
        }
        [MessageHandler(PartyInvitationCancelledForGuestMessage.ProtocolId)]
        private void PartyInvitationCancelledForGuestMessageHandler(DofusClient client, PartyInvitationCancelledForGuestMessage message)
        {
            client.Logger.Log($"Le joueur id: {message.CancelerId} a annulé son invitation de groupe.", LogMessageType.Info);
        }

        
    }
}
