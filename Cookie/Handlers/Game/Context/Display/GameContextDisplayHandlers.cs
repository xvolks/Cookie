using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Display;

namespace Cookie.Handlers.Game.Context.Display
{
    public class GameContextDisplayHandlers
    {
        [MessageHandler(DisplayNumericalValuePaddockMessage.ProtocolId)]
        private void DisplayNumericalValuePaddockMessageHandler(DofusClient client, DisplayNumericalValuePaddockMessage message)
        {
            //
        }
      
    }
}
