using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Inventory.Spells;
using Cookie.Core;

namespace Cookie.Handlers.Game.Inventory.Spells
{
    public class GameInventorySpellsHandlers
    {
        [MessageHandler(SpellListMessage.ProtocolId)]
        private void SpellListMessageHandler(DofusClient client, SpellListMessage message)
        {
            client.Account.Character.Spells = message.Spells;
        }
    }
}