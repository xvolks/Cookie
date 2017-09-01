package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItemGenericQuantityPrice;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeOfflineSoldItemsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6613;
       
      
      private var _isInitialized:Boolean = false;
      
      public var bidHouseItems:Vector.<ObjectItemGenericQuantityPrice>;
      
      public var merchantItems:Vector.<ObjectItemGenericQuantityPrice>;
      
      private var _bidHouseItemstree:FuncTree;
      
      private var _merchantItemstree:FuncTree;
      
      public function ExchangeOfflineSoldItemsMessage()
      {
         this.bidHouseItems = new Vector.<ObjectItemGenericQuantityPrice>();
         this.merchantItems = new Vector.<ObjectItemGenericQuantityPrice>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6613;
      }
      
      public function initExchangeOfflineSoldItemsMessage(param1:Vector.<ObjectItemGenericQuantityPrice> = null, param2:Vector.<ObjectItemGenericQuantityPrice> = null) : ExchangeOfflineSoldItemsMessage
      {
         this.bidHouseItems = param1;
         this.merchantItems = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.bidHouseItems = new Vector.<ObjectItemGenericQuantityPrice>();
         this.merchantItems = new Vector.<ObjectItemGenericQuantityPrice>();
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
         this.serializeAs_ExchangeOfflineSoldItemsMessage(param1);
      }
      
      public function serializeAs_ExchangeOfflineSoldItemsMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.bidHouseItems.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.bidHouseItems.length)
         {
            (this.bidHouseItems[_loc2_] as ObjectItemGenericQuantityPrice).serializeAs_ObjectItemGenericQuantityPrice(param1);
            _loc2_++;
         }
         param1.writeShort(this.merchantItems.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.merchantItems.length)
         {
            (this.merchantItems[_loc3_] as ObjectItemGenericQuantityPrice).serializeAs_ObjectItemGenericQuantityPrice(param1);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeOfflineSoldItemsMessage(param1);
      }
      
      public function deserializeAs_ExchangeOfflineSoldItemsMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:ObjectItemGenericQuantityPrice = null;
         var _loc7_:ObjectItemGenericQuantityPrice = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = new ObjectItemGenericQuantityPrice();
            _loc6_.deserialize(param1);
            this.bidHouseItems.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = new ObjectItemGenericQuantityPrice();
            _loc7_.deserialize(param1);
            this.merchantItems.push(_loc7_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeOfflineSoldItemsMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeOfflineSoldItemsMessage(param1:FuncTree) : void
      {
         this._bidHouseItemstree = param1.addChild(this._bidHouseItemstreeFunc);
         this._merchantItemstree = param1.addChild(this._merchantItemstreeFunc);
      }
      
      private function _bidHouseItemstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._bidHouseItemstree.addChild(this._bidHouseItemsFunc);
            _loc3_++;
         }
      }
      
      private function _bidHouseItemsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItemGenericQuantityPrice = new ObjectItemGenericQuantityPrice();
         _loc2_.deserialize(param1);
         this.bidHouseItems.push(_loc2_);
      }
      
      private function _merchantItemstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._merchantItemstree.addChild(this._merchantItemsFunc);
            _loc3_++;
         }
      }
      
      private function _merchantItemsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItemGenericQuantityPrice = new ObjectItemGenericQuantityPrice();
         _loc2_.deserialize(param1);
         this.merchantItems.push(_loc2_);
      }
   }
}
