package com.ankamagames.dofus.network.messages.game.inventory.preset
{
   import com.ankamagames.dofus.network.messages.game.inventory.AbstractPresetSaveMessage;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class InventoryPresetSaveCustomMessage extends AbstractPresetSaveMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6329;
       
      
      private var _isInitialized:Boolean = false;
      
      public var itemsPositions:Vector.<uint>;
      
      public var itemsUids:Vector.<uint>;
      
      private var _itemsPositionstree:FuncTree;
      
      private var _itemsUidstree:FuncTree;
      
      public function InventoryPresetSaveCustomMessage()
      {
         this.itemsPositions = new Vector.<uint>();
         this.itemsUids = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6329;
      }
      
      public function initInventoryPresetSaveCustomMessage(param1:uint = 0, param2:uint = 0, param3:Vector.<uint> = null, param4:Vector.<uint> = null) : InventoryPresetSaveCustomMessage
      {
         super.initAbstractPresetSaveMessage(param1,param2);
         this.itemsPositions = param3;
         this.itemsUids = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.itemsPositions = new Vector.<uint>();
         this.itemsUids = new Vector.<uint>();
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
         this.serializeAs_InventoryPresetSaveCustomMessage(param1);
      }
      
      public function serializeAs_InventoryPresetSaveCustomMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPresetSaveMessage(param1);
         param1.writeShort(this.itemsPositions.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.itemsPositions.length)
         {
            param1.writeByte(this.itemsPositions[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.itemsUids.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.itemsUids.length)
         {
            if(this.itemsUids[_loc3_] < 0)
            {
               throw new Error("Forbidden value (" + this.itemsUids[_loc3_] + ") on element 2 (starting at 1) of itemsUids.");
            }
            param1.writeVarInt(this.itemsUids[_loc3_]);
            _loc3_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InventoryPresetSaveCustomMessage(param1);
      }
      
      public function deserializeAs_InventoryPresetSaveCustomMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:uint = 0;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readUnsignedByte();
            if(_loc6_ < 0 || _loc6_ > 255)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of itemsPositions.");
            }
            this.itemsPositions.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readVarUhInt();
            if(_loc7_ < 0)
            {
               throw new Error("Forbidden value (" + _loc7_ + ") on elements of itemsUids.");
            }
            this.itemsUids.push(_loc7_);
            _loc5_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InventoryPresetSaveCustomMessage(param1);
      }
      
      public function deserializeAsyncAs_InventoryPresetSaveCustomMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._itemsPositionstree = param1.addChild(this._itemsPositionstreeFunc);
         this._itemsUidstree = param1.addChild(this._itemsUidstreeFunc);
      }
      
      private function _itemsPositionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._itemsPositionstree.addChild(this._itemsPositionsFunc);
            _loc3_++;
         }
      }
      
      private function _itemsPositionsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedByte();
         if(_loc2_ < 0 || _loc2_ > 255)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of itemsPositions.");
         }
         this.itemsPositions.push(_loc2_);
      }
      
      private function _itemsUidstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._itemsUidstree.addChild(this._itemsUidsFunc);
            _loc3_++;
         }
      }
      
      private function _itemsUidsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhInt();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of itemsUids.");
         }
         this.itemsUids.push(_loc2_);
      }
   }
}
