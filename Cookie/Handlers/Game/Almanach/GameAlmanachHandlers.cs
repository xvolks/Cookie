using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Almanach;
using Cookie.Core;

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