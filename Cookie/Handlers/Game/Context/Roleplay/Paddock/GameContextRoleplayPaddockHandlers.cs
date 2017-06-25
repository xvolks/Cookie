using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Paddock;
using Cookie.Core;

namespace Cookie.Handlers.Game.Context.Roleplay.Paddock
{
    public class GameContextRoleplayPaddockHandlers
    {
        [MessageHandler(PaddockPropertiesMessage.ProtocolId)]
        private void PaddockPropertiesMessageHandler(DofusClient client, PaddockPropertiesMessage message)
        {
            //
        }

        [MessageHandler(GameDataPlayFarmObjectAnimationMessage.ProtocolId)]
        private void GameDataPlayFarmObjectAnimationMessageHandler(DofusClient client,
            GameDataPlayFarmObjectAnimationMessage message)
        {
            //
        }
    }
}