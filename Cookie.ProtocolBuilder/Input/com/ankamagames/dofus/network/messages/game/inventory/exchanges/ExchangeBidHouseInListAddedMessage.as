package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.data.items.effects.ObjectEffect;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeBidHouseInListAddedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5949;
       
      
      private var _isInitialized:Boolean = false;
      
      public var itemUID:int = 0;
      
      public var objGenericId:int = 0;
      
      public var effects:Vector.<ObjectEffect>;
      
      public var prices:Vector.<Number>;
      
      private var _effectstree:FuncTree;
      
      private var _pricestree:FuncTree;
      
      public function ExchangeBidHouseInListAddedMessage()
      {
         this.effects = new Vector.<ObjectEffect>();
         this.prices = new Vector.<Number>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5949;
      }
      
      public function initExchangeBidHouseInListAddedMessage(param1:int = 0, param2:int = 0, param3:Vector.<ObjectEffect> = null, param4:Vector.<Number> = null) : ExchangeBidHouseInListAddedMessage
      {
         this.itemUID = param1;
         this.objGenericId = param2;
         this.effects = param3;
         this.prices = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.itemUID = 0;
         this.objGenericId = 0;
         this.effects = new Vector.<ObjectEffect>();
         this.prices = new Vector.<Number>();
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
         this.serializeAs_ExchangeBidHouseInListAddedMessage(param1);
      }
      
      public function serializeAs_ExchangeBidHouseInListAddedMessage(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.itemUID);
         param1.writeInt(this.objGenericId);
         param1.writeShort(this.effects.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.effects.length)
         {
            param1.writeShort((this.effects[_loc2_] as ObjectEffect).getTypeId());
            (this.effects[_loc2_] as ObjectEffect).serialize(param1);
            _loc2_++;
         }
         param1.writeShort(this.prices.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.prices.length)
         {
            if(this.prices[_loc3_] < 0 || this.prices[_loc3_] > 9007199254740990)
            {
               throw new Error("Forbidden value (" + this.prices[_loc3_] + ") on element 4 (starting at 1) of prices.");
            }
            param1.writeVarLong(this.prices[_loc3_]);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeBidHouseInListAddedMessage(param1);
      }
      
      public function deserializeAs_ExchangeBidHouseInListAddedMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:ObjectEffect = null;
         var _loc8_:Number = NaN;
         this._itemUIDFunc(param1);
         this._objGenericIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readUnsignedShort();
            _loc7_ = ProtocolTypeManager.getInstance(ObjectEffect,_loc6_);
            _loc7_.deserialize(param1);
            this.effects.push(_loc7_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc8_ = param1.readVarUhLong();
            if(_loc8_ < 0 || _loc8_ > 9007199254740990)
            {
               throw new Error("Forbidden value (" + _loc8_ + ") on elements of prices.");
            }
            this.prices.push(_loc8_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeBidHouseInListAddedMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeBidHouseInListAddedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._itemUIDFunc);
         param1.addChild(this._objGenericIdFunc);
         this._effectstree = param1.addChild(this._effectstreeFunc);
         this._pricestree = param1.addChild(this._pricestreeFunc);
      }
      
      private function _itemUIDFunc(param1:ICustomDataInput) : void
      {
         this.itemUID = param1.readInt();
      }
      
      private function _objGenericIdFunc(param1:ICustomDataInput) : void
      {
         this.objGenericId = param1.readInt();
      }
      
      private function _effectstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._effectstree.addChild(this._effectsFunc);
            _loc3_++;
         }
      }
      
      private function _effectsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:ObjectEffect = ProtocolTypeManager.getInstance(ObjectEffect,_loc2_);
         _loc3_.deserialize(param1);
         this.effects.push(_loc3_);
      }
      
      private function _pricestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._pricestree.addChild(this._pricesFunc);
            _loc3_++;
         }
      }
      
      private function _pricesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Number = param1.readVarUhLong();
         if(_loc2_ < 0 || _loc2_ > 9007199254740990)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of prices.");
         }
         this.prices.push(_loc2_);
      }
   }
}
