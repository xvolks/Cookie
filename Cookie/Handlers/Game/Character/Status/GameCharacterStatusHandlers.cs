using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Character.Status;
using Cookie.Core;

namespace Cookie.Handlers.Game.Character.Status
{
    public class GameCharacterStatusHandlers
    {
        [MessageHandler(PlayerStatusUpdateErrorMessage.ProtocolId)]
        private void PlayerStatusUpdateErrorMessageHandler(DofusClient client, PlayerStatusUpdateErrorMessage message)
        {
            //  
        }

        [MessageHandler(PlayerStatusUpdateMessage.ProtocolId)]
        private void PlayerStatusUpdateMessageHandler(DofusClient client, PlayerStatusUpdateMessage message)
        {
            //  
        }
    }
}