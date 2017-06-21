using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Pvp;

namespace Cookie.Handlers.Game.Pvp
{
    public class GamePvpHandlers
    {
        [MessageHandler(AlignmentRankUpdateMessage.ProtocolId)]
        private void AlignmentRankUpdateMessageHandler(DofusClient client, AlignmentRankUpdateMessage message)
        {
            //
        }

        [MessageHandler(UpdateMapPlayersAgressableStatusMessage.ProtocolId)]
        private void UpdateMapPlayersAgressableStatusMessageHandler(DofusClient client, UpdateMapPlayersAgressableStatusMessage message)
        {
            //
        }
    }
}
