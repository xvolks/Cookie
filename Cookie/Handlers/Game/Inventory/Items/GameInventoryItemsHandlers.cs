using System.Linq;
using Cookie.API.Datacenter;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Inventory.Items;
using Cookie.Core;
using Cookie.API.Gamedata;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.API.Gamedata.D2i;

namespace Cookie.Handlers.Game.Inventory.Items
{
    public class GameInventoryItemsHandlers
    {
        [MessageHandler(ExchangeMultiCraftCrafterCanUseHisRessourcesMessage.ProtocolId)]
        private void ExchangeMultiCraftCrafterCanUseHisRessourcesMessageHandler(DofusClient client,
            ExchangeMultiCraftCrafterCanUseHisRessourcesMessage message)
        {
            //
        }

        [MessageHandler(ExchangeObjectModifiedInBagMessage.ProtocolId)]
        private void ExchangeObjectModifiedInBagMessageHandler(DofusClient client,
            ExchangeObjectModifiedInBagMessage message)
        {
            //
        }

        [MessageHandler(ExchangeObjectPutInBagMessage.ProtocolId)]
        private void ExchangeObjectPutInBagMessageHandler(DofusClient client, ExchangeObjectPutInBagMessage message)
        {
            //
        }

        [MessageHandler(ExchangeObjectRemovedFromBagMessage.ProtocolId)]
        private void ExchangeObjectRemovedFromBagMessageHandler(DofusClient client,
            ExchangeObjectRemovedFromBagMessage message)
        {
            //
        }

        [MessageHandler(ExchangeObjectsModifiedMessage.ProtocolId)]
        private void ExchangeObjectsModifiedMessageHandler(DofusClient client, ExchangeObjectsModifiedMessage message)
        {
            //
        }

        [MessageHandler(ExchangeObjectsRemovedMessage.ProtocolId)]
        private void ExchangeObjectsRemovedMessageHandler(DofusClient client, ExchangeObjectsRemovedMessage message)
        {
            //
        }

        [MessageHandler(ExchangePodsModifiedMessage.ProtocolId)]
        private void ExchangePodsModifiedMessageHandler(DofusClient client, ExchangePodsModifiedMessage message)
        {
            client.Account.Character.MaxWeight = message.MaxWeight;
            client.Account.Character.Weight = message.CurrentWeight;
        }

        [MessageHandler(LivingObjectMessageMessage.ProtocolId)]
        private void LivingObjectMessageMessageHandler(DofusClient client, LivingObjectMessageMessage message)
        {
            //
        }

        [MessageHandler(MimicryObjectAssociatedMessage.ProtocolId)]
        private void MimicryObjectAssociatedMessageHandler(DofusClient client, MimicryObjectAssociatedMessage message)
        {
            //
        }

        [MessageHandler(MimicryObjectErrorMessage.ProtocolId)]
        private void MimicryObjectErrorMessageHandler(DofusClient client, MimicryObjectErrorMessage message)
        {
            //
        }

        [MessageHandler(MimicryObjectPreviewMessage.ProtocolId)]
        private void MimicryObjectPreviewMessageHandler(DofusClient client, MimicryObjectPreviewMessage message)
        {
            //
        }

        [MessageHandler(ObjectErrorMessage.ProtocolId)]
        private void ObjectErrorMessageHandler(DofusClient client, ObjectErrorMessage message)
        {
            //
        }

        [MessageHandler(ObjectJobAddedMessage.ProtocolId)]
        private void ObjectJobAddedMessageHandler(DofusClient client, ObjectJobAddedMessage message)
        {
            //
        }

        [MessageHandler(ObjectMovementMessage.ProtocolId)]
        private void ObjectMovementMessageHandler(DofusClient client, ObjectMovementMessage message)
        {
            //
        }

        [MessageHandler(ObjectsQuantityMessage.ProtocolId)]
        private void ObjectsQuantityMessageHandler(DofusClient client, ObjectsQuantityMessage message)
        {
            //
        }

        [MessageHandler(ObjectUseMessage.ProtocolId)]
        private void ObjectUseMessageHandler(DofusClient client, ObjectUseMessage message)
        {
            //
        }

        [MessageHandler(ObtainedItemWithBonusMessage.ProtocolId)]
        private void ObtainedItemWithBonusMessageHandler(DofusClient client, ObtainedItemWithBonusMessage message)
        {
            //
        }

        [MessageHandler(SymbioticObjectAssociatedMessage.ProtocolId)]
        private void SymbioticObjectAssociatedMessageHandler(DofusClient client,
            SymbioticObjectAssociatedMessage message)
        {
            //
        }

        [MessageHandler(SymbioticObjectErrorMessage.ProtocolId)]
        private void SymbioticObjectErrorMessageHandler(DofusClient client, SymbioticObjectErrorMessage message)
        {
            //
        }

        [MessageHandler(WrapperObjectAssociatedMessage.ProtocolId)]
        private void WrapperObjectAssociatedMessageHandler(DofusClient client, WrapperObjectAssociatedMessage message)
        {
            //
        }

        [MessageHandler(WrapperObjectErrorMessage.ProtocolId)]
        private void WrapperObjectErrorMessageHandler(DofusClient client, WrapperObjectErrorMessage message)
        {
            //
        }

        [MessageHandler(InventoryContentAndPresetMessage.ProtocolId)]
        private void InventoryContentAndPresetMessageHandler(DofusClient client,
            InventoryContentAndPresetMessage message)
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
            client.Account.Character.Inventory.Remove(
                client.Account.Character.Inventory.First(o => o.ObjectUID == message.ObjectUID));
        }

        [MessageHandler(ObjectsDeletedMessage.ProtocolId)]
        private void ObjectsDeletedMessageHandler(DofusClient client, ObjectsDeletedMessage message)
        {
            message.ObjectUID.ForEach(o =>
            {
                client.Account.Character.Inventory.Remove(
                    client.Account.Character.Inventory.First(item => item.ObjectUID == o));
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
            Logger.Default.Log(
                $"Tu as reçu : {FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Item>(message.GenericId).NameId)} x {message.BaseQuantity}");
        }

        [MessageHandler(GoldAddedMessage.ProtocolId)]
        private void GoldAddedMessageHandler(DofusClient client, GoldAddedMessage message)
        {
            Logger.Default.Log(
                $"Tu as reçu : {message.Gold}");
        }

        [MessageHandler(ExchangeObjectRemovedMessage.ProtocolId)]
        private void ExchangeObjectRemovedMessageHandler(DofusClient client, ExchangeObjectRemovedMessage message)
        {
            if (message.Remote)
                Logger.Default.Log($"L'échangeur a retiré un item de l'échange", LogMessageType.Info);
            else
                Logger.Default.Log($"Vous avez retiré un item de l'échange", LogMessageType.Info);
        }

        [MessageHandler(ExchangeKamaModifiedMessage.ProtocolId)]
        private void ExchangeKamaModifiedMessageHandler(DofusClient client, ExchangeKamaModifiedMessage message)
        {
            if (message.Remote)
                Logger.Default.Log($"L'échangeur a ajouté {message.Quantity} kamas à l'échange", LogMessageType.Info);
            else
                Logger.Default.Log($"Vous avez ajouté {message.Quantity} kamas à l'échange", LogMessageType.Info);
        }

        [MessageHandler(ExchangeObjectModifiedMessage.ProtocolId)]
        private void ExchangeObjectModifiedMessageHandler(DofusClient client, ExchangeObjectModifiedMessage message)
        {
            if (message.Remote)
                Logger.Default.Log(
                    $"L'échangeur a modifié le nombre de {D2OParsing.GetItemName(message.Object.ObjectGID)} en x{message.Object.Quantity}",
                    LogMessageType.Info);
            else
                Logger.Default.Log(
                    $"Vous avez modifié le nombre de {D2OParsing.GetItemName(message.Object.ObjectGID)} en x{message.Object.Quantity}",
                    LogMessageType.Info);
        }
    }
}