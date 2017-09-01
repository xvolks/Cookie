package com.ankamagames.dofus.network.messages.game.inventory.preset
{
   import com.ankamagames.dofus.network.types.game.inventory.preset.PresetItem;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class InventoryPresetItemUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6168;
       
      
      private var _isInitialized:Boolean = false;
      
      public var presetId:uint = 0;
      
      public var presetItem:PresetItem;
      
      private var _presetItemtree:FuncTree;
      
      public function InventoryPresetItemUpdateMessage()
      {
         this.presetItem = new PresetItem();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6168;
      }
      
      public function initInventoryPresetItemUpdateMessage(param1:uint = 0, param2:PresetItem = null) : InventoryPresetItemUpdateMessage
      {
         this.presetId = param1;
         this.presetItem = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.presetId = 0;
         this.presetItem = new PresetItem();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_InventoryPresetItemUpdateMessage(param1);
      }
      
      public function serializeAs_InventoryPresetItemUpdateMessage(param1:ICustomDataOutput) : void
      {
         if(this.presetId < 0)
         {
            throw new Error("Forbidden value (" + this.presetId + ") on element presetId.");
         }
         param1.writeByte(this.presetId);
         this.presetItem.serializeAs_PresetItem(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InventoryPresetItemUpdateMessage(param1);
      }
      
      public function deserializeAs_InventoryPresetItemUpdateMessage(param1:ICustomDataInput) : void
      {
         this._presetIdFunc(param1);
         this.presetItem = new PresetItem();
         this.presetItem.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InventoryPresetItemUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_InventoryPresetItemUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._presetIdFunc);
         this._presetItemtree = param1.addChild(this._presetItemtreeFunc);
      }
      
      private function _presetIdFunc(param1:ICustomDataInput) : void
      {
         this.presetId = param1.readByte();
         if(this.presetId < 0)
         {
            throw new Error("Forbidden value (" + this.presetId + ") on element of InventoryPresetItemUpdateMessage.presetId.");
         }
      }
      
      private function _presetItemtreeFunc(param1:ICustomDataInput) : void
      {
         this.presetItem = new PresetItem();
         this.presetItem.deserializeAsync(this._presetItemtree);
      }
   }
}
