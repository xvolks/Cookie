using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Game.Context.Roleplay.Houses
{
    public class GameContextRoleplayHousesHandlers
    {
        [MessageHandler(AccountHouseMessage.ProtocolId)]
        private void AccountHouseMessageHandler(DofusClient Client, AccountHouseMessage Message)
        {
            //
        }

        [MessageHandler(HousePropertiesMessage.ProtocolId)]
        private void HousePropertiesMessageHandlers(DofusClient Client, HousePropertiesMessage Message)
        {
            //
        }
    }
}
