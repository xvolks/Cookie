using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Almanach;

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
