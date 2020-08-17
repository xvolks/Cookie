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
   public class ExchangeCraftPaymentModifiedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6578;
       
      
      private var _isInitialized:Boolean = false;
      
      public var goldSum:Number = 0;
      
      public function ExchangeCraftPaymentModifiedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6578;
      }
      
      public function initExchangeCraftPaymentModifiedMessage(param1:Number = 0) : ExchangeCraftPaymentModifiedMessage
      {
         this.goldSum = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.goldSum = 0;
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
         this.serializeAs_ExchangeCraftPaymentModifiedMessage(param1);
      }
      
      public function serializeAs_ExchangeCraftPaymentModifiedMessage(param1:ICustomDataOutput) : void
      {
         if(this.goldSum < 0 || this.goldSum > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.goldSum + ") on element goldSum.");
         }
         param1.writeVarLong(this.goldSum);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeCraftPaymentModifiedMessage(param1);
      }
      
      public function deserializeAs_ExchangeCraftPaymentModifiedMessage(param1:ICustomDataInput) : void
      {
         this._goldSumFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeCraftPaymentModifiedMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeCraftPaymentModifiedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._goldSumFunc);
      }
      
      private function _goldSumFunc(param1:ICustomDataInput) : void
      {
         this.goldSum = param1.readVarUhLong();
         if(this.goldSum < 0 || this.goldSum > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.goldSum + ") on element of ExchangeCraftPaymentModifiedMessage.goldSum.");
         }
      }
   }
}
