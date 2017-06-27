using Cookie.API.Core;
using Cookie.API.Game.Friend;
using Cookie.API.Messages;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Friend;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Friend
{
    public class Friend : IFriend
    {
        public Friend(IAccount account)
        {
            account.Network.RegisterPacket<FriendsListMessage>(HandleFriendsListMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<FriendDeleteResultMessage>(HandleFriendDeleteResultMessage,
                MessagePriority.VeryHigh);
        }

        private void HandleFriendsListMessage(IAccount account, FriendsListMessage message)
        {
            foreach (var friend in message.FriendsList)
                switch (friend.PlayerState)
                {
                    case (byte) PlayerStateEnum.NOT_CONNECTED:
                        continue;
                    case (byte) PlayerStateEnum.UNKNOWN_STATE:
                        continue;
                    default:
                        Logger.Default.Log($"{friend.AccountName} connecté");
                        break;
                }
        }

        private void HandleFriendDeleteResultMessage(IAccount account, FriendDeleteResultMessage message)
        {
            if (message.Success)
                Logger.Default.Log($"Vous venez de supprimer {message.Name} de votre liste d'ami ",
                    LogMessageType.Info);
            else
                Logger.Default.Log($"Erreur lors de la suppresion de l'ami {message.Name}");
        }
    }
}