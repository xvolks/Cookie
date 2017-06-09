using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Inventory.Items;
using Cookie.Utils.Extensions;
using System.Linq;

namespace Cookie.Handlers.Game.Inventory.Items
{
    public class GameInventoryItemsHandlers
    {
        [MessageHandler(InventoryContentAndPresetMessage.ProtocolId)]
        private void InventoryContentAndPresetMessageHandler(DofusClient Client, InventoryContentAndPresetMessage Message)
        {
            Client.Account.Character.Stats.Kamas = Message.Kamas;
            Client.Account.Character.Inventory = Message.Objects;
        }

        [MessageHandler(InventoryContentMessage.ProtocolId)]
        private void InventoryContentMessageHandler(DofusClient Client, InventoryContentMessage Message)
        {
            Client.Account.Character.Stats.Kamas = Message.Kamas;
            Client.Account.Character.Inventory = Message.Objects;
        }

        [MessageHandler(InventoryWeightMessage.ProtocolId)]
        private void InventoryWeightMessageHandler(DofusClient Client, InventoryWeightMessage Message)
        {
            Client.Account.Character.Weight = Message.Weight;
            Client.Account.Character.MaxWeight = Message.WeightMax;
        }
        
        [MessageHandler(SetUpdateMessage.ProtocolId)]
        private void SetUpdateMessageHandler(DofusClient Client, SetUpdateMessage Message)
        {
            //
        }

        [MessageHandler(ObjectModifiedMessage.ProtocolId)]
        private void ObjectModifiedMessageHandler(DofusClient Client, ObjectModifiedMessage Message)
        {
            Client.Account.Character.Inventory.ForEach(Object =>
            {
                if (Object.ObjectUID == Message.Object.ObjectUID)
                {
                    Object = Message.Object;
                    return;
                }
            });
        }

        [MessageHandler(ObjectAddedMessage.ProtocolId)]
        private void ObjectAddedMessageHandler(DofusClient Client, ObjectAddedMessage Message)
        {
            Client.Account.Character.Inventory.Add(Message.Object);
        }

        [MessageHandler(ObjectsAddedMessage.ProtocolId)]
        private void ObjectsAddedMessageHandler(DofusClient Client, ObjectsAddedMessage Message)
        {
            Client.Account.Character.Inventory.AddRange(Message.Object);
        }

        [MessageHandler(ObjectDeletedMessage.ProtocolId)]
        private void ObjectDeletedMessageHandler(DofusClient Client, ObjectDeletedMessage Message)
        {
            Client.Account.Character.Inventory.Remove(Client.Account.Character.Inventory.Where(o => o.ObjectUID == Message.ObjectUID).First());
        }

        [MessageHandler(ObjectsDeletedMessage.ProtocolId)]
        private void ObjectsDeletedMessageHandler(DofusClient Client, ObjectsDeletedMessage Message)
        {
            Message.ObjectUID.ForEach((o) =>
            {
                Client.Account.Character.Inventory.Remove(Client.Account.Character.Inventory.Where(item => item.ObjectUID == o).First());
            });
        }

        [MessageHandler(ObjectQuantityMessage.ProtocolId)]
        private void ObjectQuantityMessageHandler(DofusClient Client, ObjectQuantityMessage Message)
        {
            //
        }
    }
}
