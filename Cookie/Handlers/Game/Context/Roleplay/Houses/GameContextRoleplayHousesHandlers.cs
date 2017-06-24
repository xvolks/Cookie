using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses;

namespace Cookie.Handlers.Game.Context.Roleplay.Houses
{
    public class GameContextRoleplayHousesHandlers
    {
        [MessageHandler(AccountHouseMessage.ProtocolId)]
        private void AccountHouseMessageHandler(DofusClient client, AccountHouseMessage message)
        {
            //
        }

        [MessageHandler(HousePropertiesMessage.ProtocolId)]
        private void HousePropertiesMessageHandlers(DofusClient client, HousePropertiesMessage message)
        {
            //
        }
    }
}