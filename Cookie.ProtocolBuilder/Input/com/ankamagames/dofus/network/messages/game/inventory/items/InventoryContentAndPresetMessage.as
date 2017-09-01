package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItem;
   import com.ankamagames.dofus.network.types.game.inventory.preset.IdolsPreset;
   import com.ankamagames.dofus.network.types.game.inventory.preset.Preset;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class InventoryContentAndPresetMessage extends InventoryContentMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6162;
       
      
      private var _isInitialized:Boolean = false;
      
      public var presets:Vector.<Preset>;
      
      public var idolsPresets:Vector.<IdolsPreset>;
      
      private var _presetstree:FuncTree;
      
      private var _idolsPresetstree:FuncTree;
      
      public function InventoryContentAndPresetMessage()
      {
         this.presets = new Vector.<Preset>();
         this.idolsPresets = new Vector.<IdolsPreset>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6162;
      }
      
      public function initInventoryContentAndPresetMessage(param1:Vector.<ObjectItem> = null, param2:Number = 0, param3:Vector.<Preset> = null, param4:Vector.<IdolsPreset> = null) : InventoryContentAndPresetMessage
      {
         super.initInventoryContentMessage(param1,param2);
         this.presets = param3;
         this.idolsPresets = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.presets = new Vector.<Preset>();
         this.idolsPresets = new Vector.<IdolsPreset>();
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_InventoryContentAndPresetMessage(param1);
      }
      
      public function serializeAs_InventoryContentAndPresetMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_InventoryContentMessage(param1);
         param1.writeShort(this.presets.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.presets.length)
         {
            (this.presets[_loc2_] as Preset).serializeAs_Preset(param1);
            _loc2_++;
         }
         param1.writeShort(this.idolsPresets.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.idolsPresets.length)
         {
            (this.idolsPresets[_loc3_] as IdolsPreset).serializeAs_IdolsPreset(param1);
            _loc3_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InventoryContentAndPresetMessage(param1);
      }
      
      public function deserializeAs_InventoryContentAndPresetMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:Preset = null;
         var _loc7_:IdolsPreset = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = new Preset();
            _loc6_.deserialize(param1);
            this.presets.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = new IdolsPreset();
            _loc7_.deserialize(param1);
            this.idolsPresets.push(_loc7_);
            _loc5_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InventoryContentAndPresetMessage(param1);
      }
      
      public function deserializeAsyncAs_InventoryContentAndPresetMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._presetstree = param1.addChild(this._presetstreeFunc);
         this._idolsPresetstree = param1.addChild(this._idolsPresetstreeFunc);
      }
      
      private function _presetstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._presetstree.addChild(this._presetsFunc);
            _loc3_++;
         }
      }
      
      private function _presetsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Preset = new Preset();
         _loc2_.deserialize(param1);
         this.presets.push(_loc2_);
      }
      
      private function _idolsPresetstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._idolsPresetstree.addChild(this._idolsPresetsFunc);
            _loc3_++;
         }
      }
      
      private function _idolsPresetsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:IdolsPreset = new IdolsPreset();
         _loc2_.deserialize(param1);
         this.idolsPresets.push(_loc2_);
      }
   }
}
