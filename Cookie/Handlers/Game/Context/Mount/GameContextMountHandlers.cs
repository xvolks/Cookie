using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Mount;

namespace Cookie.Handlers.Game.Context.Mount
{
    public class GameContextMountHandlers
    {
        [MessageHandler(MountSetMessage.ProtocolId)]
        private void MountSetMessageHandler(DofusClient Client, MountSetMessage Message)
        {
            //
        }

        [MessageHandler(MountXpRatioMessage.ProtocolId)]
        private void MountXpRatioMessageHandler(DofusClient Client, MountXpRatioMessage Message)
        {
            //
        }

        [MessageHandler(MountRidingMessage.ProtocolId)]
        private void MountRidingMessageHandler(DofusClient Client, MountRidingMessage Message)
        {
            //
        }
    }
}
