using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay.Paddock;

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