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
   public class ExchangeShopStockMovementUpdatedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5909;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objectInfo:ObjectItemToSell;
      
      private var _objectInfotree:FuncTree;
      
      public function ExchangeShopStockMovementUpdatedMessage()
      {
         this.objectInfo = new ObjectItemToSell();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5909;
      }
      
      public function initExchangeShopStockMovementUpdatedMessage(param1:ObjectItemToSell = null) : ExchangeShopStockMovementUpdatedMessage
      {
         this.objectInfo = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.objectInfo = new ObjectItemToSell();
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
         this.serializeAs_ExchangeShopStockMovementUpdatedMessage(param1);
      }
      
      public function serializeAs_ExchangeShopStockMovementUpdatedMessage(param1:ICustomDataOutput) : void
      {
         this.objectInfo.serializeAs_ObjectItemToSell(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeShopStockMovementUpdatedMessage(param1);
      }
      
      public function deserializeAs_ExchangeShopStockMovementUpdatedMessage(param1:ICustomDataInput) : void
      {
         this.objectInfo = new ObjectItemToSell();
         this.objectInfo.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeShopStockMovementUpdatedMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeShopStockMovementUpdatedMessage(param1:FuncTree) : void
      {
         this._objectInfotree = param1.addChild(this._objectInfotreeFunc);
      }
      
      private function _objectInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.objectInfo = new ObjectItemToSell();
         this.objectInfo.deserializeAsync(this._objectInfotree);
      }
   }
}
