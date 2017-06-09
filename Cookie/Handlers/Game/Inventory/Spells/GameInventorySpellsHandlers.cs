using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Inventory.Spells;

namespace Cookie.Handlers.Game.Inventory.Spells
{
    public class GameInventorySpellsHandlers
    {
        [MessageHandler(SpellListMessage.ProtocolId)]
        private void SpellListMessageHandler(DofusClient Client, SpellListMessage Message)
        {
            Client.Account.Character.Spells = Message.Spells;
        }
    }
}
