using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Context.Display;
using Cookie.Core;

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