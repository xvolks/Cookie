using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Chat.Channel;
using Cookie.API.Protocol.Network.Messages.Game.Context;
using Cookie.API.Protocol.Network.Messages.Game.Friend;
using Cookie.API.Protocol.Network.Messages.Game.Initialization;
using Cookie.API.Protocol.Network.Messages.Security;
using Cookie.Core;
using Cookie.Utils;

namespace Cookie.Handlers.Game.Initialization
{
    public class GameInitializationHandlers
    {
        [MessageHandler(CharacterLoadingCompleteMessage.ProtocolId)]
        private void CharacterLoadingCompleteMessageHandler(DofusClient client, CharacterLoadingCompleteMessage message)
        {
            client.Send(new FriendsGetListMessage());
            client.Send(new IgnoredGetListMessage());
            client.Send(new SpouseGetInformationsMessage());
            client.Send(new ClientKeyMessage(FlashKeyGenerator.GetRandomFlashKey(client.Account.Nickname)));
            client.Send(new GameContextCreateRequestMessage());
            client.Send(new ChannelEnablingMessage(7, false));
        }

        [MessageHandler(CharacterCapabilitiesMessage.ProtocolId)]
        private void CharacterCapabilitiesMessageHandler(DofusClient client, CharacterCapabilitiesMessage message)
        {
            //
        }

        [MessageHandler(OnConnectionEventMessage.ProtocolId)]
        private void OnConnectionEventMessageHandler(DofusClient client, OnConnectionEventMessage message)
        {
            Logger.Default.Log("Connection Event Type: " + message.EventType + " | MessageID: " + message.MessageID,
                LogMessageType.Arena);
        }

        [MessageHandler(SetCharacterRestrictionsMessage.ProtocolId)]
        private void SetCharacterRestrictionsMessageHandler(DofusClient client, SetCharacterRestrictionsMessage message)
        {
            client.Account.Character.Restrictions = message.Restrictions;
        }

        [MessageHandler(ServerExperienceModificatorMessage.ProtocolId)]
        private void ServerExperienceModificatorMessageHandler(DofusClient client,
            ServerExperienceModificatorMessage message)
        {
            //
        }
    }
}