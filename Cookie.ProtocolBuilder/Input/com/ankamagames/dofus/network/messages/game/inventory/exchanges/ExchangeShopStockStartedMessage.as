package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.types.game.data.items.ObjectItemToSell;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeShopStockStartedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5910;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objectsInfos:Vector.<ObjectItemToSell>;
      
      private var _objectsInfostree:FuncTree;
      
      public function ExchangeShopStockStartedMessage()
      {
         this.objectsInfos = new Vector.<ObjectItemToSell>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5910;
      }
      
      public function initExchangeShopStockStartedMessage(param1:Vector.<ObjectItemToSell> = null) : ExchangeShopStockStartedMessage
      {
         this.objectsInfos = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.objectsInfos = new Vector.<ObjectItemToSell>();
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
         this.serializeAs_ExchangeShopStockStartedMessage(param1);
      }
      
      public function serializeAs_ExchangeShopStockStartedMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.objectsInfos.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.objectsInfos.length)
         {
            (this.objectsInfos[_loc2_] as ObjectItemToSell).serializeAs_ObjectItemToSell(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeShopStockStartedMessage(param1);
      }
      
      public function deserializeAs_ExchangeShopStockStartedMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:ObjectItemToSell = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ObjectItemToSell();
            _loc4_.deserialize(param1);
            this.objectsInfos.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeShopStockStartedMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeShopStockStartedMessage(param1:FuncTree) : void
      {
         this._objectsInfostree = param1.addChild(this._objectsInfostreeFunc);
      }
      
      private function _objectsInfostreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._objectsInfostree.addChild(this._objectsInfosFunc);
            _loc3_++;
         }
      }
      
      private function _objectsInfosFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ObjectItemToSell = new ObjectItemToSell();
         _loc2_.deserialize(param1);
         this.objectsInfos.push(_loc2_);
      }
   }
}
