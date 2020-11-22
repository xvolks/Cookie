using Cookie.API.Core;
using Cookie.API.Game.Party;
using Cookie.API.Messages;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Cookie.Game.Party
{
    public class Party : IParty
    {
        public IAccount Account { get; set; }
        public IDictionary<double,PartyMemberInformations> PartyMembers { get; set; }
        public uint PartyId { get; set; }
        private bool IsLeader { get; set; }
        public event EventHandler<PartyLeaderUpdateMessage> PartyLeaderUpdate;
        public delegate void PartyNewMemberEventHandler(IAccount account, bool message);
        public PartyNewMemberEventHandler PartyNewMemberEvent;
        public Party(IAccount account)
        {
            Account = account;
            PartyMembers = new Dictionary<double, PartyMemberInformations>();
            #region Party Handlers

            account.Network.RegisterPacket<PartyInvitationMessage>(HandlePartyInvitationMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<PartyInvitationCancelledForGuestMessage>( HandlePartyInvitationCancelledForGuestMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<PartyJoinMessage>(HandlePartyJoinMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<PartyNewGuestMessage>(HandlePartyNewGuestMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<PartyNewMemberMessage>(HandlePartyNewMemberMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<PartyMemberRemoveMessage>(HandlePartyMemberRemoveMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<PartyLoyaltyStatusMessage>(HandlePartyLoyaltyStatusMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<PartyUpdateMessage>(HandlePartyUpdateMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<PartyLeaderUpdateMessage>(HandlePartyLeaderUpdateMessage, MessagePriority.VeryHigh);

            #endregion
        }
        #region Party Methods
        public bool PassOnThrone(IAccount account, string characterName)
        {
            var member = account.Character.Party.PartyMembers.FirstOrDefault(x => x.Value.Name == characterName).Value;
            if (member == default(PartyMemberInformations))
                Logger.Default.Log($"Could not find the specified CharacterName. Try using the <.partyMemberList> command ", LogMessageType.Party);
            else
            {
                if (!IsLeader)
                    Logger.Default.Log($"Bot is not the PartyLeader.");
                else
                {
                    PartyAbdicateThroneMessage message = new PartyAbdicateThroneMessage(member.Id)
                    {
                        PartyId = PartyId
                    };
                    account.Network.SendToServer(message);
                    return true;
                }                       
            }
            return false;
        }
        #endregion

        #region Party Handlers Methods

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
        private void HandlePartyUpdateMessage(IAccount account, PartyUpdateMessage message)
        {
            if (PartyMembers.ContainsKey(message.MemberInformations.Id))
                PartyMembers[message.MemberInformations.Id] = message.MemberInformations;
            else
                Logger.Default.Log($"Player <{message.MemberInformations.Name}> can't be updated. Could not find player in your party.", LogMessageType.Error);
        }
        private void HandlePartyNewMemberMessage(IAccount account, PartyNewMemberMessage message)
        {
            if (message.MemberInformations.Id == account.Character.Id) return;
            if (PartyMembers.ContainsKey(message.MemberInformations.Id))
            {
                Logger.Default.Log($"Player <{message.MemberInformations.Name}> is already listed in your party.", LogMessageType.Error);
                PartyNewMemberEvent?.Invoke(account, false);
            }
            else
            {
                PartyMembers.Add(message.MemberInformations.Id, message.MemberInformations);
                Logger.Default.Log($"Player <{message.MemberInformations.Name}> is a new member of your party.", LogMessageType.Party);
                PartyNewMemberEvent?.Invoke(account, true);
            }
        }
        private void HandlePartyNewGuestMessage(IAccount account, PartyNewGuestMessage message)
        {
            Logger.Default.Log($"{message.Guest.Name} has been invited.");
        }
        private void HandlePartyJoinMessage(IAccount account, PartyJoinMessage message)
        {
            PartyId = message.PartyId;
            if (message.PartyLeaderId == account.Character.Id)
                IsLeader = true;
            else
                IsLeader = false;
            foreach (var member in message.Members)
                if (!PartyMembers.ContainsKey(member.Id))
                    PartyMembers.Add(member.Id, member);
        }
        private void HandlePartyLoyaltyStatusMessage(IAccount account, PartyLoyaltyStatusMessage message)
        {
            Logger.Default.Log($"PartyLoyaltyStatusMessage received");
        }
        private void HandlePartyMemberRemoveMessage(IAccount account, PartyMemberRemoveMessage message)
        {
            if (PartyMembers.ContainsKey(message.LeavingPlayerId))
            {
                Logger.Default.Log($"Player <{PartyMembers[message.LeavingPlayerId].Name}> was removed from your party.", LogMessageType.Party);
                PartyMembers.Remove(message.LeavingPlayerId);
                if(PartyMembers.Count == 1)
                {
                    Logger.Default.Log($"Your party has been disbanded.", LogMessageType.Party);
                    PartyMembers.Clear();
                }
                else
                    Logger.Default.Log($"Your party has now {PartyMembers.Count} members",LogMessageType.Party);
            }
            else
                Logger.Default.Log($"Player <{message.LeavingPlayerId}> is not a member of your party. It can't be removed.", LogMessageType.Party);
        }
        private void HandlePartyLeaderUpdateMessage(IAccount account, PartyLeaderUpdateMessage message)
        {
            if (account.Character.Id == message.PartyLeaderId)
            {
                Logger.Default.Log($"You're the new party leader.");
            }
            PartyLeaderUpdate?.Invoke(account, message);
        }

        #endregion
    }

    [Serializable]
    internal class PartyException : Exception
    {
        public PartyException()
        {
        }

        public PartyException(string message) : base(message)
        {
        }

        public PartyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PartyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}