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
   public class ExchangeStartOkRecycleTradeMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6600;
       
      
      private var _isInitialized:Boolean = false;
      
      public var percentToPrism:uint = 0;
      
      public var percentToPlayer:uint = 0;
      
      public function ExchangeStartOkRecycleTradeMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6600;
      }
      
      public function initExchangeStartOkRecycleTradeMessage(param1:uint = 0, param2:uint = 0) : ExchangeStartOkRecycleTradeMessage
      {
         this.percentToPrism = param1;
         this.percentToPlayer = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.percentToPrism = 0;
         this.percentToPlayer = 0;
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
         this.serializeAs_ExchangeStartOkRecycleTradeMessage(param1);
      }
      
      public function serializeAs_ExchangeStartOkRecycleTradeMessage(param1:ICustomDataOutput) : void
      {
         if(this.percentToPrism < 0)
         {
            throw new Error("Forbidden value (" + this.percentToPrism + ") on element percentToPrism.");
         }
         param1.writeShort(this.percentToPrism);
         if(this.percentToPlayer < 0)
         {
            throw new Error("Forbidden value (" + this.percentToPlayer + ") on element percentToPlayer.");
         }
         param1.writeShort(this.percentToPlayer);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeStartOkRecycleTradeMessage(param1);
      }
      
      public function deserializeAs_ExchangeStartOkRecycleTradeMessage(param1:ICustomDataInput) : void
      {
         this._percentToPrismFunc(param1);
         this._percentToPlayerFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeStartOkRecycleTradeMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeStartOkRecycleTradeMessage(param1:FuncTree) : void
      {
         param1.addChild(this._percentToPrismFunc);
         param1.addChild(this._percentToPlayerFunc);
      }
      
      private function _percentToPrismFunc(param1:ICustomDataInput) : void
      {
         this.percentToPrism = param1.readShort();
         if(this.percentToPrism < 0)
         {
            throw new Error("Forbidden value (" + this.percentToPrism + ") on element of ExchangeStartOkRecycleTradeMessage.percentToPrism.");
         }
      }
      
      private function _percentToPlayerFunc(param1:ICustomDataInput) : void
      {
         this.percentToPlayer = param1.readShort();
         if(this.percentToPlayer < 0)
         {
            throw new Error("Forbidden value (" + this.percentToPlayer + ") on element of ExchangeStartOkRecycleTradeMessage.percentToPlayer.");
         }
      }
   }
}
