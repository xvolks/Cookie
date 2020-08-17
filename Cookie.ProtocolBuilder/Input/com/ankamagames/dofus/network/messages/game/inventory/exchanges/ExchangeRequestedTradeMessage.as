package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeRequestedTradeMessage extends ExchangeRequestedMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5523;
       
      
      private var _isInitialized:Boolean = false;
      
      public var source:Number = 0;
      
      public var target:Number = 0;
      
      public function ExchangeRequestedTradeMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5523;
      }
      
      public function initExchangeRequestedTradeMessage(param1:int = 0, param2:Number = 0, param3:Number = 0) : ExchangeRequestedTradeMessage
      {
         super.initExchangeRequestedMessage(param1);
         this.source = param2;
         this.target = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.source = 0;
         this.target = 0;
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
         this.serializeAs_ExchangeRequestedTradeMessage(param1);
      }
      
      public function serializeAs_ExchangeRequestedTradeMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ExchangeRequestedMessage(param1);
         if(this.source < 0 || this.source > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.source + ") on element source.");
         }
         param1.writeVarLong(this.source);
         if(this.target < 0 || this.target > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.target + ") on element target.");
         }
         param1.writeVarLong(this.target);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeRequestedTradeMessage(param1);
      }
      
      public function deserializeAs_ExchangeRequestedTradeMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._sourceFunc(param1);
         this._targetFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeRequestedTradeMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeRequestedTradeMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._sourceFunc);
         param1.addChild(this._targetFunc);
      }
      
      private function _sourceFunc(param1:ICustomDataInput) : void
      {
         this.source = param1.readVarUhLong();
         if(this.source < 0 || this.source > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.source + ") on element of ExchangeRequestedTradeMessage.source.");
         }
      }
      
      private function _targetFunc(param1:ICustomDataInput) : void
      {
         this.target = param1.readVarUhLong();
         if(this.target < 0 || this.target > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.target + ") on element of ExchangeRequestedTradeMessage.target.");
         }
      }
   }
}
