using Cookie.API.Core;
using Cookie.API.Game.Party;
using Cookie.API.Messages;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Party
{
    public class Party : IParty
    {
        public Party(IAccount account)
        {
            account.Network.RegisterPacket<PartyInvitationMessage>(HandlePartyInvitationMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<PartyInvitationCancelledForGuestMessage>(
                HandlePartyInvitationCancelledForGuestMessage, MessagePriority.VeryHigh);
        }

        private void HandlePartyInvitationMessage(IAccount account, PartyInvitationMessage message)
        {
            Logger.Default.Log($"Le joueur {message.FromName} vous invite dans son groupe.", LogMessageType.Info);
        }

        private void HandlePartyInvitationCancelledForGuestMessage(IAccount account,
            PartyInvitationCancelledForGuestMessage message)
        {
            Logger.Default.Log($"Le joueur id: {message.CancelerId} a annulé son invitation de groupe.",
                LogMessageType.Info);
        }
    }
}