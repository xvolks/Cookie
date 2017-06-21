using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Mount;

namespace Cookie.Handlers.Game.Context.Mount
{
    public class GameContextMountHandlers
    {
        [MessageHandler(MountSetMessage.ProtocolId)]
        private void MountSetMessageHandler(DofusClient client, MountSetMessage message)
        {
            //
        }

        [MessageHandler(MountXpRatioMessage.ProtocolId)]
        private void MountXpRatioMessageHandler(DofusClient client, MountXpRatioMessage message)
        {
            //
        }

        [MessageHandler(MountRidingMessage.ProtocolId)]
        private void MountRidingMessageHandler(DofusClient client, MountRidingMessage message)
        {
            //
        }

        [MessageHandler(MountDataMessage.ProtocolId)]
        private void MountDataMessageHandler(DofusClient client, MountDataMessage message)
        {
            //
        }

        [MessageHandler(GameDataPaddockObjectAddMessage.ProtocolId)]
        private void GameDataPaddockObjectAddMessageHandler(DofusClient client, GameDataPaddockObjectAddMessage message)
        {
            //
        }

        [MessageHandler(GameDataPaddockObjectRemoveMessage.ProtocolId)]
        private void GameDataPaddockObjectRemoveMessageHandler(DofusClient client,
            GameDataPaddockObjectRemoveMessage message)
        {
            //
        }

        [MessageHandler(GameDataPaddockObjectListAddMessage.ProtocolId)]
        private void GameDataPaddockObjectListAddMessageHandler(DofusClient client,
            GameDataPaddockObjectListAddMessage message)
        {
            //
        }

        [MessageHandler(MountDataErrorMessage.ProtocolId)]
        private void MountDataErrorMessageHandler(DofusClient client, MountDataErrorMessage message)
        {
            //
        }
    }
}