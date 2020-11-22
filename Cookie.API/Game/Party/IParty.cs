using Cookie.API.Core;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Cookie.API.Game.Party
{
    public interface IParty
    {
        IAccount Account { get; }
        IDictionary<double, PartyMemberInformations> PartyMembers { get; set; }
        /// <summary>
        ///     Pass the Leadership to the specified player if valid and present on the party.
        /// </summary>
        /// <param name="account"> IAccount template.</param>
        /// <param name="characterName"> String ChacterName of the destination Leader.</param>
        /// <returns></returns>
        bool PassOnThrone(IAccount account, string characterName);
        event EventHandler<PartyLeaderUpdateMessage> PartyLeaderUpdate;
    }
}