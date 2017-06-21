using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Character.Status;

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
