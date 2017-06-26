using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party;
using Cookie.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Handlers.Game.Context.Roleplay.Party
{
    public class GameContextRoleplayPartyHandlers
    {
        [MessageHandler(PartyInvitationMessage.ProtocolId)]
        private void PartyInvitationMessageHandler(DofusClient client, PartyInvitationMessage message)
        {
            Logger.Default.Log($"Le joueur {message.FromName} vous invite dans son groupe.", LogMessageType.Info);
        }

        [MessageHandler(PartyInvitationCancelledForGuestMessage.ProtocolId)]
        private void PartyInvitationCancelledForGuestMessageHandler(DofusClient client,
            PartyInvitationCancelledForGuestMessage message)
        {
            Logger.Default.Log($"Le joueur id: {message.CancelerId} a annulé son invitation de groupe.",
                LogMessageType.Info);
        }
    }
}