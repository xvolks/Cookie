using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Game.Pvp
{
    public class GamePvpHandlers
    {
        [MessageHandler(AlignmentRankUpdateMessage.ProtocolId)]
        private void AlignmentRankUpdateMessageHandler(DofusClient Client, AlignmentRankUpdateMessage Message)
        {
            //
        }

        [MessageHandler(UpdateMapPlayersAgressableStatusMessage.ProtocolId)]
        private void UpdateMapPlayersAgressableStatusMessageHandler(DofusClient Client, UpdateMapPlayersAgressableStatusMessage Message)
        {
            //
        }
    }
}
