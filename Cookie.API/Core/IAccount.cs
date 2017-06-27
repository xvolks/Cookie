using Cookie.API.Core.Frames;
using Cookie.API.Core.Network;
using Cookie.API.Game.Achievement;
using Cookie.API.Game.Alliance;
using Cookie.API.Game.Chat;
using Cookie.API.Game.Friend;
using Cookie.API.Game.Guild;
using Cookie.API.Game.Inventory;
using Cookie.API.Game.Map;
using Cookie.API.Game.Party;

namespace Cookie.API.Core
{
    public interface IAccount
    {
        /// <summary>
        ///     the Login of the account
        /// </summary>
        string Login { get; set; }

        /// <summary>
        ///     The password of the account
        /// </summary>
        string Password { get; set; }

        /// <summary>
        ///     The ID of the account
        /// </summary>
        int Id { get; set; }

        /// <summary>
        ///     The ticket for the connection
        /// </summary>
        string Ticket { get; set; }

        /// <summary>
        ///     The nickname of the account
        /// </summary>
        string Nickname { get; set; }

        /// <summary>
        ///     The Secret Question of the account
        /// </summary>
        string SecretQuestion { get; set; }

        /// <summary>
        ///     The account creation date
        /// </summary>
        double AccountCreation { get; set; }

        /// <summary>
        ///     The account community id
        /// </summary>
        byte CommunityId { get; set; }

        /// <summary>
        ///     The total subscription duration of this account
        /// </summary>
        double SubscriptionElapsedDuration { get; set; }

        /// <summary>
        ///     The subscription end date
        /// </summary>
        double SubscriptionEndDate { get; set; }

        /// <summary>
        ///     The character connected on this account
        /// </summary>
        ICharacter Character { get; set; }

        /// <summary>
        ///     The latency frame for this account
        /// </summary>
        ILatencyFrame LatencyFrame { get; set; }

        INetwork Network { get; set; }

        IAchievement Achievement { get; set; }

        IAlliance Alliance { get; set; }

        IChat Chat { get; set; }

        IMap Map { get; set; }

        IFriend Friend { get; set; }

        IGuild Guild { get; set; }

        IInventory Inventory { get; set; }

        IParty Party { get; set; }

        void LogPacket(string origin, string name, string id);
        void LogNoHandler(string name);
    }
}