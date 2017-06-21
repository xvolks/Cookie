using Cookie.Core;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages.Game.Friend;

namespace Cookie.Handlers.Game.Friend
{
    public class GameFriendHandlers
    {
        [MessageHandler(FriendWarnOnConnectionStateMessage.ProtocolId)]
        private void FriendWarnOnConnectionStateMessageHandler(DofusClient Client, FriendWarnOnConnectionStateMessage Message)
        {
            //
        }

        [MessageHandler(FriendWarnOnLevelGainStateMessage.ProtocolId)]
        private void FriendWarnOnLevelGainStateMessageHandler(DofusClient Client, FriendWarnOnLevelGainStateMessage Message)
        {
            //
        }

        [MessageHandler(WarnOnPermaDeathStateMessage.ProtocolId)]
        private void WarnOnPermaDeathStateMessageHandler(DofusClient Client, WarnOnPermaDeathStateMessage Message)
        {
            //
        }

        [MessageHandler(FriendsListMessage.ProtocolId)]
        private void FriendsListMessageHandler(DofusClient Client, FriendsListMessage Message)
        {
            foreach (var friend in Message.FriendsList)
            {
                if (friend.PlayerState == (byte)PlayerStateEnum.NOT_CONNECTED)
                    continue;
                if (friend.PlayerState == (byte)PlayerStateEnum.UNKNOWN_STATE)
                    continue;
                Client.Logger.Log($"{friend.AccountName} connecté");
            }
        }

        [MessageHandler(IgnoredListMessage.ProtocolId)]
        private void IgnoredListMessageHandler(DofusClient Client, IgnoredListMessage Message)
        {
            //
        }

        [MessageHandler(FriendUpdateMessage.ProtocolId)]
        private void FriendUpdateMessageHandler(DofusClient Client, FriendUpdateMessage Message)
        {
            //
        }

        [MessageHandler(GuildMemberWarnOnConnectionStateMessage.ProtocolId)]
        private void GuildMemberWarnOnConnectionStateMessageHandler(DofusClient Client, GuildMemberWarnOnConnectionStateMessage Message)
        {
            //
        }

        [MessageHandler(SpouseStatusMessage.ProtocolId)]
        private void SpouseStatusMessageHandler(DofusClient Client, SpouseStatusMessage Message)
        {
            //
        }
        [MessageHandler(FriendDeleteResultMessage.ProtocolId)]
        private void FriendDeleteResultMessageHandler(DofusClient client, FriendDeleteResultMessage message)
        {
            client.Logger.Log($"Vous venez de supprimer {message.Name} de votre liste d'ami ", LogMessageType.Info);
        }
    }
}
