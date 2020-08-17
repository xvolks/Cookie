package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItemGenericQuantity;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeBidHouseUnsoldItemsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6612;
       
      
      private var _isInitialized:Boolean = false;
      
      public var items:Vector.<ObjectItemGenericQuantity>;
      
      private var _itemstree:FuncTree;
      
      public function ExchangeBidHouseUnsoldItemsMessage()
      {
         this.items = new Vector.<ObjectItemGenericQuantity>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6612;
      }
      
      public function initExchangeBidHouseUnsoldItemsMessage(param1:Vector.<ObjectItemGenericQuantity> = null) : ExchangeBidHouseUnsoldItemsMessage
      {
         this.items = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.items = new Vector.<ObjectItemGenericQuantity>();
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
         this.serializeAs_ExchangeBidHouseUnsoldItemsMessage(param1);
      }
      
      public function serializeAs_ExchangeBidHouseUnsoldItemsMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.items.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.items.length)
         {
            (this.items[_loc2_] as ObjectItemGenericQuantity).serializeAs_ObjectItemGenericQuantity(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeBidHouseUnsoldItemsMessage(param1);
      }
      
      public function deserializeAs_ExchangeBidHouseUnsoldItemsMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:ObjectItemGenericQuantity = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ObjectItemGenericQuantity();
            _loc4_.deserialize(param1);
            this.items.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeBidHouseUnsoldItemsMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeBidHouseUnsoldItemsMessage(param1:FuncTree) : void
      {
         this._itemstree = param1.addChild(this._itemstreeFunc);
      }
      
      private function _itemstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._itemstree.addChild(this._itemsFunc);
            _loc3_++;
         }
      }
      
      private function _itemsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItemGenericQuantity = new ObjectItemGenericQuantity();
         _loc2_.deserialize(param1);
         this.items.push(_loc2_);
      }
   }
}
