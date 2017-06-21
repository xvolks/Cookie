using Cookie.Core;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages.Game.Friend;

namespace Cookie.Handlers.Game.Friend
{
    public class GameFriendHandlers
    {
        [MessageHandler(FriendWarnOnConnectionStateMessage.ProtocolId)]
        private void FriendWarnOnConnectionStateMessageHandler(DofusClient client,
            FriendWarnOnConnectionStateMessage message)
        {
            //
        }

        [MessageHandler(FriendWarnOnLevelGainStateMessage.ProtocolId)]
        private void FriendWarnOnLevelGainStateMessageHandler(DofusClient client,
            FriendWarnOnLevelGainStateMessage message)
        {
            //
        }

        [MessageHandler(WarnOnPermaDeathStateMessage.ProtocolId)]
        private void WarnOnPermaDeathStateMessageHandler(DofusClient client, WarnOnPermaDeathStateMessage message)
        {
            //
        }

        [MessageHandler(FriendsListMessage.ProtocolId)]
        private void FriendsListMessageHandler(DofusClient client, FriendsListMessage message)
        {
            foreach (var friend in message.FriendsList)
                switch (friend.PlayerState)
                {
                    case (byte) PlayerStateEnum.NOT_CONNECTED:
                        continue;
                    case (byte) PlayerStateEnum.UNKNOWN_STATE:
                        continue;
                    default:
                        client.Logger.Log($"{friend.AccountName} connecté");
                        break;
                }
        }

        [MessageHandler(IgnoredListMessage.ProtocolId)]
        private void IgnoredListMessageHandler(DofusClient client, IgnoredListMessage message)
        {
            //
        }

        [MessageHandler(FriendUpdateMessage.ProtocolId)]
        private void FriendUpdateMessageHandler(DofusClient client, FriendUpdateMessage message)
        {
            //
        }

        [MessageHandler(GuildMemberWarnOnConnectionStateMessage.ProtocolId)]
        private void GuildMemberWarnOnConnectionStateMessageHandler(DofusClient client,
            GuildMemberWarnOnConnectionStateMessage message)
        {
            //
        }

        [MessageHandler(SpouseStatusMessage.ProtocolId)]
        private void SpouseStatusMessageHandler(DofusClient client, SpouseStatusMessage message)
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