using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Chat.Channel;
using Cookie.Protocol.Network.Messages.Game.Context;
using Cookie.Protocol.Network.Messages.Game.Friend;
using Cookie.Protocol.Network.Messages.Game.Initialization;
using Cookie.Protocol.Network.Messages.Security;
using Cookie.Utils;

namespace Cookie.Handlers.Game.Initialization
{
    public class GameInitializationHandlers
    {
        [MessageHandler(CharacterLoadingCompleteMessage.ProtocolId)]
        private void CharacterLoadingCompleteMessageHandler(DofusClient Client, CharacterLoadingCompleteMessage Message)
        {
            Client.Send(new FriendsGetListMessage());
            Client.Send(new IgnoredGetListMessage());
            Client.Send(new SpouseGetInformationsMessage());
            Client.Send(new ClientKeyMessage(FlashKeyGenerator.GetRandomFlashKey(Client.Account.Nickname)));
            Client.Send(new GameContextCreateRequestMessage());
            Client.Send(new ChannelEnablingMessage(7, false));
        }

        [MessageHandler(CharacterCapabilitiesMessage.ProtocolId)]
        private void CharacterCapabilitiesMessageHandler(DofusClient Client, CharacterCapabilitiesMessage Message)
        {
            //
        }

        [MessageHandler(OnConnectionEventMessage.ProtocolId)]
        private void OnConnectionEventMessageHandler(DofusClient Client, OnConnectionEventMessage Message)
        {
            Client.Logger.Log("Connection Event Type: " + Message.EventType + " | MessageID: " + Message.MessageID, LogMessageType.Arena);
        }

        [MessageHandler(SetCharacterRestrictionsMessage.ProtocolId)]
        private void SetCharacterRestrictionsMessageHandler(DofusClient Client, SetCharacterRestrictionsMessage Message)
        {
            Client.Account.Character.Restrictions = Message.Restrictions;
        }
        [MessageHandler(ServerExperienceModificatorMessage.ProtocolId)]
        private void ServerExperienceModificatorMessageHandler(DofusClient Client, ServerExperienceModificatorMessage Message)
        {
            //
        }
    }
}
