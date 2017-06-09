using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag;

namespace Cookie.Handlers.Game.Context.Roleplay.Havenbag
{
    public class GameContextRoleplayHavenbagHandlers
    {
        [MessageHandler(RoomAvailableUpdateMessage.ProtocolId)]
        private void RoomAvailableUpdateMessageHandler(DofusClient Client, RoomAvailableUpdateMessage Message)
        {
            //
        }

        [MessageHandler(HavenBagPackListMessage.ProtocolId)]
        private void HavenBagPackListMessageHandler(DofusClient Client, HavenBagPackListMessage Message)
        {
            //
        }
    }
}
