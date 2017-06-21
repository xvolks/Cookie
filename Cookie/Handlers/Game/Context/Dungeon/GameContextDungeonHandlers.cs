using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Dungeon;

namespace Cookie.Handlers.Game.Context.Dungeon
{
    public class GameContextDungeonHandlers
    {
        [MessageHandler(DungeonEnteredMessage.ProtocolId)]
        private void DungeonEnteredMessageHandler(DofusClient client, DungeonEnteredMessage message)
        {
            //
        }

        [MessageHandler(DungeonKeyRingMessage.ProtocolId)]
        private void DungeonKeyRingMessageHandler(DofusClient client, DungeonKeyRingMessage message)
        {
            //
        }

        [MessageHandler(DungeonKeyRingUpdateMessage.ProtocolId)]
        private void DungeonKeyRingUpdateMessageHandler(DofusClient client, DungeonKeyRingUpdateMessage message)
        {
            //
        }

        [MessageHandler(DungeonLeftMessage.ProtocolId)]
        private void DungeonLeftMessageHandler(DofusClient client, DungeonLeftMessage message)
        {
            //
        }
    }
}