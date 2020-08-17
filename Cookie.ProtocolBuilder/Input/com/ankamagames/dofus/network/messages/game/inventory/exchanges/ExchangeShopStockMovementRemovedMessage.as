package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeShopStockMovementRemovedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5907;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objectId:uint = 0;
      
      public function ExchangeShopStockMovementRemovedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5907;
      }
      
      public function initExchangeShopStockMovementRemovedMessage(param1:uint = 0) : ExchangeShopStockMovementRemovedMessage
      {
         this.objectId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.objectId = 0;
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
         this.serializeAs_ExchangeShopStockMovementRemovedMessage(param1);
      }
      
      public function serializeAs_ExchangeShopStockMovementRemovedMessage(param1:ICustomDataOutput) : void
      {
         if(this.objectId < 0)
         {
            throw new Error("Forbidden value (" + this.objectId + ") on element objectId.");
         }
         param1.writeVarInt(this.objectId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeShopStockMovementRemovedMessage(param1);
      }
      
      public function deserializeAs_ExchangeShopStockMovementRemovedMessage(param1:ICustomDataInput) : void
      {
         this._objectIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeShopStockMovementRemovedMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeShopStockMovementRemovedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._objectIdFunc);
      }
      
      private function _objectIdFunc(param1:ICustomDataInput) : void
      {
         this.objectId = param1.readVarUhInt();
         if(this.objectId < 0)
         {
            throw new Error("Forbidden value (" + this.objectId + ") on element of ExchangeShopStockMovementRemovedMessage.objectId.");
         }
      }
   }
}
