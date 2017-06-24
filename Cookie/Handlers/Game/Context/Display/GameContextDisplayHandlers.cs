using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Context.Display;

namespace Cookie.Handlers.Game.Context.Display
{
    public class GameContextDisplayHandlers
    {
        [MessageHandler(DisplayNumericalValuePaddockMessage.ProtocolId)]
        private void DisplayNumericalValuePaddockMessageHandler(DofusClient client,
            DisplayNumericalValuePaddockMessage message)
        {
            //
        }
    }
}