using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Inventory.Items;
using Cookie.Utils.Extensions;
using System.Linq;
using Cookie.Datacenter;
using Cookie.Gamedata.D2o;
using Cookie.Gamedata.I18n;
using Cookie.Gamedata;

namespace Cookie.Handlers.Game.Inventory.Items
{
    public class GameInventoryItemsHandlers
    {
        [MessageHandler(InventoryContentAndPresetMessage.ProtocolId)]
        private void InventoryContentAndPresetMessageHandler(DofusClient client, InventoryContentAndPresetMessage message)
        {
            client.Account.Character.Stats.Kamas = message.Kamas;
            client.Account.Character.Inventory = message.Objects;
        }

        [MessageHandler(InventoryContentMessage.ProtocolId)]
        private void InventoryContentMessageHandler(DofusClient client, InventoryContentMessage message)
        {
            client.Account.Character.Stats.Kamas = message.Kamas;
            client.Account.Character.Inventory = message.Objects;
        }

        [MessageHandler(InventoryWeightMessage.ProtocolId)]
        private void InventoryWeightMessageHandler(DofusClient client, InventoryWeightMessage message)
        {
            client.Account.Character.Weight = message.Weight;
            client.Account.Character.MaxWeight = message.WeightMax;
        }
        
        [MessageHandler(SetUpdateMessage.ProtocolId)]
        private void SetUpdateMessageHandler(DofusClient client, SetUpdateMessage message)
        {
            //
        }

        [MessageHandler(ObjectModifiedMessage.ProtocolId)]
        private void ObjectModifiedMessageHandler(DofusClient client, ObjectModifiedMessage message)
        {
            client.Account.Character.Inventory.ForEach(Object =>
            {
                if (Object.ObjectUID != message.Object.ObjectUID) return;
                Object = message.Object;
                return;
            });
        }

        [MessageHandler(ObjectAddedMessage.ProtocolId)]
        private void ObjectAddedMessageHandler(DofusClient client, ObjectAddedMessage message)
        {
            client.Account.Character.Inventory.Add(message.Object);
        }

        [MessageHandler(ObjectsAddedMessage.ProtocolId)]
        private void ObjectsAddedMessageHandler(DofusClient client, ObjectsAddedMessage message)
        {
            client.Account.Character.Inventory.AddRange(message.Object);
        }

        [MessageHandler(ObjectDeletedMessage.ProtocolId)]
        private void ObjectDeletedMessageHandler(DofusClient client, ObjectDeletedMessage message)
        {
            client.Account.Character.Inventory.Remove(client.Account.Character.Inventory.First(o => o.ObjectUID == message.ObjectUID));
        }

        [MessageHandler(ObjectsDeletedMessage.ProtocolId)]
        private void ObjectsDeletedMessageHandler(DofusClient client, ObjectsDeletedMessage message)
        {
            message.ObjectUID.ForEach((o) =>
            {
                client.Account.Character.Inventory.Remove(client.Account.Character.Inventory.First(item => item.ObjectUID == o));
            });
        }

        [MessageHandler(ObjectQuantityMessage.ProtocolId)]
        private void ObjectQuantityMessageHandler(DofusClient client, ObjectQuantityMessage message)
        {
            //
        }

        [MessageHandler(ObtainedItemMessage.ProtocolId)]
        private void ObtainedItemMessageHandler(DofusClient client, ObtainedItemMessage message)
        {
            client.Logger.Log(
                $"Tu as reçu : {I18nDataManager.Instance.ReadText(ObjectDataManager.Instance.Get<Item>(message.GenericId).NameId)} x {message.BaseQuantity}");
        }
        [MessageHandler(GoldAddedMessage.ProtocolId)]
        private void GoldAddedMessageHandler(DofusClient client, GoldAddedMessage message)
        {
            client.Logger.Log(
                 $"Tu as reçu : {message.Gold}");
        }
        [MessageHandler(ExchangeObjectRemovedMessage.ProtocolId)]
        private void ExchangeObjectRemovedMessageHandler(DofusClient client, ExchangeObjectRemovedMessage message)
        {
            if(message.Remote)
                client.Logger.Log($"L'échangeur a retiré un item de l'échange", LogMessageType.Info);
            else
                client.Logger.Log($"Vous avez retiré un item de l'échange", LogMessageType.Info);
        }
        [MessageHandler(ExchangeKamaModifiedMessage.ProtocolId)]
        private void ExchangeKamaModifiedMessageHandler(DofusClient client, ExchangeKamaModifiedMessage message)
        {
            if(message.Remote)
                client.Logger.Log($"L'échangeur a ajouté {message.Quantity} kamas à l'échange", LogMessageType.Info);
            else
                client.Logger.Log($"Vous avez ajouté {message.Quantity} kamas à l'échange", LogMessageType.Info);
        }
        [MessageHandler(ExchangeObjectModifiedMessage.ProtocolId)]
        private void ExchangeObjectModifiedMessageHandler(DofusClient client, ExchangeObjectModifiedMessage message)
        {
            if (message.Remote)
                client.Logger.Log($"L'échangeur a modifié le nombre de {D2OParsing.GetItemName(message.Object.ObjectGID)} en x{message.Object.Quantity}", LogMessageType.Info);
            else
                client.Logger.Log($"Vous avez modifié le nombre de {D2OParsing.GetItemName(message.Object.ObjectGID)} en x{message.Object.Quantity}", LogMessageType.Info);
        }
    }
}
