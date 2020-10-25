using Cookie.Core;
using Cookie.Protocol.Network.Messages;
using Cookie.Utils;

namespace Cookie.Handlers.Game.Initialization
{
    public class GameInitializationHandlers
    {
        [MessageHandler(CharacterLoadingCompleteMessage.ProtocolId)]
        private void CharacterLoadingCompleteMessageHandler(DofusClient Client, CharacterLoadingCompleteMessage Message)
        {
            //
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
    }
}
