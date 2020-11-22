﻿using System;
using System.Collections.Generic;
using System.Linq;
using Cookie.API.Core;
using Cookie.API.Game.Inventory;
using Cookie.API.Gamedata;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Messages;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using MoonSharp.Interpreter;
using Item = Cookie.API.Datacenter.Item;

namespace Cookie.Game.Inventory
{
    [MoonSharpUserData]
    public class Inventory : IInventory
    {
        IAccount Account;
        public Dictionary<CharacterInventoryPositionEnum,ObjectItem> Equipment { get; set; }
        public Inventory(IAccount account)
        {
            Account = account;
            Objects = new List<ObjectItem>();
            Equipment = new Dictionary<CharacterInventoryPositionEnum, ObjectItem>();
            #region Exchange

            account.Network.RegisterPacket<ExchangeRequestedTradeMessage>(HandleExchangeRequestedTradeMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeLeaveMessage>(HandleExchangeLeaveMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeErrorMessage>(HandleExchangeErrorMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeStartedWithPodsMessage>(HandleExchangeStartedWithPodsMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeObjectAddedMessage>(HandleExchangeObjectAddedMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeIsReadyMessage>(HandleExchangeIsReadyMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangePodsModifiedMessage>(HandleExchangePodsModifiedMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeObjectRemovedMessage>(HandleExchangeObjectRemovedMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeKamaModifiedMessage>(HandleExchangeKamaModifiedMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ExchangeObjectModifiedMessage>(HandleExchangeObjectModifiedMessage,
                MessagePriority.VeryHigh);

            #endregion

            #region Inventory

            account.Network.RegisterPacket<KamasUpdateMessage>(HandleKamasUpdateMessage, MessagePriority.VeryHigh);
            //account.Network.RegisterPacket<InventoryContentAndPresetMessage>(HandleInventoryContentAndPresetMessage,
            //    MessagePriority.VeryHigh);
            account.Network.RegisterPacket<InventoryContentMessage>(HandleInventoryContentMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<InventoryWeightMessage>(HandleInventoryWeightMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ObjectModifiedMessage>(HandleObjectModifiedMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ObjectAddedMessage>(HandleObjectAddedMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ObjectsAddedMessage>(HandleObjectsAddedMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ObjectDeletedMessage>(HandleObjectDeletedMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ObjectsDeletedMessage>(HandleObjectsDeletedMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ObtainedItemMessage>(HandleObtainedItemMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ObtainedItemWithBonusMessage>(HandleObtainedItemWithBonusMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<GoldAddedMessage>(HandleGoldAddedMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ObjectMovementMessage>(HandleObjectMovementMessage, MessagePriority.VeryHigh);
            #endregion

            #region Spells

            account.Network.RegisterPacket<SpellListMessage>(HandleSpellListMessage, MessagePriority.VeryHigh);

            #endregion
        }

        public Inventory(IAccount account, bool Handlers = false)
        {
            Account = account;
            Objects = new List<ObjectItem>();
            Equipment = new Dictionary<CharacterInventoryPositionEnum, ObjectItem>();
        }
        public List<ObjectItem> Objects { get; set; }

        #region Spells

        private void HandleSpellListMessage(IAccount account, SpellListMessage message)
        {
            account.Character.Spells = message.Spells;
        }

        #endregion

        #region Exchange

        private void HandleExchangeRequestedTradeMessage(IAccount account, ExchangeRequestedTradeMessage message)
        {
            Logger.Default.Log($"Le joueur id: {message.Source} vous demande en échange.", LogMessageType.Info);
            account.Network.SendToServer(new ExchangeAcceptMessage());
        }

        private void HandleExchangeLeaveMessage(IAccount account, ExchangeLeaveMessage message)
        {
            account.Character.Status = CharacterStatus.None;
            if (!message.Success)
                Logger.Default.Log("Echange annulé.", LogMessageType.Info);
        }

        private void HandleExchangeErrorMessage(IAccount account, ExchangeErrorMessage message)
        {
            Logger.Default.Log("Une erreur est survenue lors de l'échange.");
        }

        private void HandleExchangeStartedWithPodsMessage(IAccount account, ExchangeStartedWithPodsMessage message)
        {
            Logger.Default.Log("Vous avez accepté l'échange.", LogMessageType.Info);
            account.Character.Status = CharacterStatus.Exchanging;
            if (message.FirstCharacterId == account.Character.Id)
            {
                account.Character.Weight = message.FirstCharacterCurrentWeight;
                account.Character.MaxWeight = message.FirstCharacterMaxWeight;
                Logger.Default.Log(
                    $"Vous avez {message.FirstCharacterCurrentWeight} / {message.FirstCharacterMaxWeight} pods",
                    LogMessageType.Info);
                Logger.Default.Log(
                    $"L'échangeur a {message.SecondCharacterCurrentWeight} / {message.SecondCharacterMaxWeight} pods",
                    LogMessageType.Info);
            }
            else if (message.SecondCharacterId == account.Character.Id)
            {
                Logger.Default.Log(
                    $"Vous avez {message.SecondCharacterCurrentWeight} / {message.SecondCharacterMaxWeight} pods",
                    LogMessageType.Info);
                Logger.Default.Log(
                    $"L'échangeur a {message.FirstCharacterCurrentWeight} / {message.FirstCharacterMaxWeight} pods",
                    LogMessageType.Info);
                account.Character.Weight = message.SecondCharacterCurrentWeight;
                account.Character.MaxWeight = message.SecondCharacterMaxWeight;
            }
        }

        private void HandleExchangeObjectAddedMessage(IAccount account, ExchangeObjectAddedMessage message)
        {
            Logger.Default.Log(
                message.Remote
                    ? $"L'échangeur a ajouté {D2OParsing.GetItemName(message.Object.ObjectGID)} x{message.Object.Quantity} à l'échange"
                    : $"Vous avez ajouté {D2OParsing.GetItemName(message.Object.ObjectGID)} x{message.Object.Quantity} à l'échange",
                LogMessageType.Info);
        }

        private void HandleExchangeIsReadyMessage(IAccount account, ExchangeIsReadyMessage message)
        {
            if (message.Ready)
                Logger.Default.Log("Le joueur a accepté son échange", LogMessageType.Info);
        }

        private void HandleExchangePodsModifiedMessage(IAccount account, ExchangePodsModifiedMessage message)
        {
            account.Character.MaxWeight = message.MaxWeight;
            account.Character.Weight = message.CurrentWeight;
        }

        private void HandleExchangeObjectRemovedMessage(IAccount account, ExchangeObjectRemovedMessage message)
        {
            Logger.Default.Log(
                message.Remote
                    ? $"L'échangeur a retiré un item de l'échange"
                    : $"Vous avez retiré un item de l'échange", LogMessageType.Info);
        }

        private void HandleExchangeKamaModifiedMessage(IAccount account, ExchangeKamaModifiedMessage message)
        {
            Logger.Default.Log(
                message.Remote
                    ? $"L'échangeur a ajouté {message.Quantity} kamas à l'échange"
                    : $"Vous avez ajouté {message.Quantity} kamas à l'échange", LogMessageType.Info);
        }

        private void HandleExchangeObjectModifiedMessage(IAccount account, ExchangeObjectModifiedMessage message)
        {
            Logger.Default.Log(
                message.Remote
                    ? $"L'échangeur a modifié le nombre de {D2OParsing.GetItemName(message.Object.ObjectGID)} en x{message.Object.Quantity}"
                    : $"Vous avez modifié le nombre de {D2OParsing.GetItemName(message.Object.ObjectGID)} en x{message.Object.Quantity}",
                LogMessageType.Info);
        }

        #endregion

        #region Inventory
        private void HandleObtainedItemWithBonusMessage(IAccount account, ObtainedItemWithBonusMessage message)
        {
            Logger.Default.Log($"Tu as reçu : {FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Item>(message.GenericId).NameId)} x {message.BaseQuantity} Bonus[{message.BonusQuantity}]");
            foreach (var item in account.Character.Inventory.Objects)
            {
                if (item.ObjectGID == message.GenericId)
                {
                    item.Quantity += message.BaseQuantity + message.BonusQuantity;
                    Logger.Default.Log($"There are {item.Quantity} of {FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Item>(message.GenericId).NameId)}");
                }
            }
        }
        private void HandleObjectMovementMessage(IAccount account, ObjectMovementMessage message)
        {
            for(int i = 0; i < Objects.Count; i++)
                if(message.ObjectUID == Objects[i].ObjectUID)
                {
                    Objects[i].Position = message.Position;
                    if (Enum.IsDefined(typeof(CharacterInventoryPositionEnum), (int)message.Position))
                        UpdateEquipment();
                }
        }
        private void HandleKamasUpdateMessage(IAccount account, KamasUpdateMessage message)
        {
            account.Character.Stats.Kamas = message.KamasTotal;
        }

        //private void HandleInventoryContentAndPresetMessage(IAccount account, InventoryContentAndPresetMessage message)
        //{
        //    HandleInventoryContentMessage(account, message);
        //}

        private void HandleInventoryContentMessage(IAccount account, InventoryContentMessage message)
        {
            account.Character.Stats.Kamas = message.Kamas;
            account.Character.Inventory.Objects = message.Objects;
            UpdateEquipment();
        }

        private void HandleInventoryWeightMessage(IAccount account, InventoryWeightMessage message)
        {
            account.Character.Weight = message.Weight;
            account.Character.MaxWeight = message.WeightMax;
        }

        private void HandleObjectModifiedMessage(IAccount account, ObjectModifiedMessage message)
        {
            for(int i = 0; i < Objects.Count; i++)
                if (Objects[i].ObjectUID == message.Object.ObjectUID)
                {
                    Objects[i] = message.Object;
                    if (Enum.IsDefined(typeof(CharacterInventoryPositionEnum), (int)message.Object.Position))
                        UpdateEquipment();
                }
        }

        private void HandleObjectAddedMessage(IAccount account, ObjectAddedMessage message)
        {
            account.Character.Inventory.Objects.Add(message.Object);
            if (Enum.IsDefined(typeof(CharacterInventoryPositionEnum), (int)message.Object.Position))
                UpdateEquipment();
        }

        private void HandleObjectsAddedMessage(IAccount account, ObjectsAddedMessage message)
        {
            account.Character.Inventory.Objects.AddRange(message.Object);
            foreach(var Object in message.Object){
                if (Enum.IsDefined(typeof(CharacterInventoryPositionEnum), (int)Object.Position))
                {
                    UpdateEquipment();
                    break;
                }
            }
        }

        private void HandleObjectDeletedMessage(IAccount account, ObjectDeletedMessage message)
        {
            var objToRemove = account.Character.Inventory.Objects.First(o => o.ObjectUID == message.ObjectUID);
            account.Character.Inventory.Objects.Remove(objToRemove);
            if (Enum.IsDefined(typeof(CharacterInventoryPositionEnum), (int)objToRemove.Position))
                UpdateEquipment();
        }

        private void HandleObjectsDeletedMessage(IAccount account, ObjectsDeletedMessage message)
        {
            foreach(var ObjectUID in message.ObjectUID)
            {
                var objToRemove = account.Character.Inventory.Objects.FirstOrDefault(item => item.ObjectUID == ObjectUID);
                account.Character.Inventory.Objects.Remove(objToRemove);
                if (Enum.IsDefined(typeof(CharacterInventoryPositionEnum), (int)objToRemove.Position))
                    UpdateEquipment();
            }
        }

        private void HandleObtainedItemMessage(IAccount account, ObtainedItemMessage message)
        {
            Logger.Default.Log(
                $"Tu as reçu :{FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Item>(message.GenericId).NameId)} x {message.BaseQuantity}");
        }

        private void HandleGoldAddedMessage(IAccount account, GoldAddedMessage message)
        {
            Logger.Default.Log(
                $"Tu as reçu : {message.Gold}");
        }
        #endregion
        
        #region Private Methods
        private void UpdateEquipment()
        {
            Equipment.Clear();
            for(int i = 0; i < Objects.Count; i++)
            {
                if (Enum.IsDefined(typeof(CharacterInventoryPositionEnum), (int)Objects[i].Position))
                    if (!Equipment.ContainsKey((CharacterInventoryPositionEnum)Objects[i].Position))
                        Equipment.Add((CharacterInventoryPositionEnum)Objects[i].Position, Objects[i]);
            }
        }
        #endregion
        
        #region Public Methods
        public bool HasItem(int itemId)
        {
            if (Account.Character.Inventory.Objects.FindIndex(x => x.ObjectGID == itemId && x.Quantity > 0) == -1)
                return false;
            return true;
        }
        public bool UseItem(int itemId)
        {
            var item = GetItem(itemId);
            if (item == null)
                return false;
            Account.Network.SendToServer(new ObjectUseMessage(item.ObjectUID));
            Account.Character.Inventory.Objects.Find(x => x.ObjectGID == itemId).Quantity -= 1;
            return true;
        }
        public uint ItemCount(int itemId)
        {
            var item = GetItem(itemId);
            return item == null ? 0 : item.Quantity;
        }
        private ObjectItem GetItem(int itemId) 
        {
            return Account.Character.Inventory.Objects.Find(x => x.ObjectGID == itemId && x.Quantity > 0);
        }
        #endregion
    }
}