

using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Dungeon;

namespace Cookie.Handlers.Game.Context.Dungeon
{
    public class GameContextDungeonHandlers
    {
        [MessageHandler(DungeonEnteredMessage.ProtocolId)]
        private void DungeonEnteredMessageHandler(DofusClient Client, DungeonEnteredMessage Message)
        {
            //
        }
        [MessageHandler(DungeonKeyRingMessage.ProtocolId)]
        private void DungeonKeyRingMessageHandler(DofusClient Client, DungeonKeyRingMessage Message)
        {
            //
        }
        [MessageHandler(DungeonKeyRingUpdateMessage.ProtocolId)]
        private void DungeonKeyRingUpdateMessageHandler(DofusClient Client, DungeonKeyRingUpdateMessage Message)
        {
            //
        }
        [MessageHandler(DungeonLeftMessage.ProtocolId)]
        private void DungeonLeftMessageHandler(DofusClient Client, DungeonLeftMessage Message)
        {
            //
        }
    }
}
