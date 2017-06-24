using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Almanach;

namespace Cookie.Handlers.Game.Almanach
{
    public class GameAlmanachHandlers
    {
        [MessageHandler(AlmanachCalendarDateMessage.ProtocolId)]
        private void AlmanachCalendarDateMessageHandler(DofusClient client, AlmanachCalendarDateMessage message)
        {
            //
        }
    }
}