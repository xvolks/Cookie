using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Game.Almanach
{
    public class GameAlmanachHandlers
    {
        [MessageHandler(AlmanachCalendarDateMessage.ProtocolId)]
        private void AlmanachCalendarDateMessageHandler(DofusClient Client, AlmanachCalendarDateMessage Message)
        {
            //
        }
    }
}
