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
   public class ExchangeBidPriceMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5755;
       
      
      private var _isInitialized:Boolean = false;
      
      public var genericId:uint = 0;
      
      public var averagePrice:Number = 0;
      
      public function ExchangeBidPriceMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5755;
      }
      
      public function initExchangeBidPriceMessage(param1:uint = 0, param2:Number = 0) : ExchangeBidPriceMessage
      {
         this.genericId = param1;
         this.averagePrice = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.genericId = 0;
         this.averagePrice = 0;
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
         this.serializeAs_ExchangeBidPriceMessage(param1);
      }
      
      public function serializeAs_ExchangeBidPriceMessage(param1:ICustomDataOutput) : void
      {
         if(this.genericId < 0)
         {
            throw new Error("Forbidden value (" + this.genericId + ") on element genericId.");
         }
         param1.writeVarShort(this.genericId);
         if(this.averagePrice < -9007199254740990 || this.averagePrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.averagePrice + ") on element averagePrice.");
         }
         param1.writeVarLong(this.averagePrice);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeBidPriceMessage(param1);
      }
      
      public function deserializeAs_ExchangeBidPriceMessage(param1:ICustomDataInput) : void
      {
         this._genericIdFunc(param1);
         this._averagePriceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeBidPriceMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeBidPriceMessage(param1:FuncTree) : void
      {
         param1.addChild(this._genericIdFunc);
         param1.addChild(this._averagePriceFunc);
      }
      
      private function _genericIdFunc(param1:ICustomDataInput) : void
      {
         this.genericId = param1.readVarUhShort();
         if(this.genericId < 0)
         {
            throw new Error("Forbidden value (" + this.genericId + ") on element of ExchangeBidPriceMessage.genericId.");
         }
      }
      
      private function _averagePriceFunc(param1:ICustomDataInput) : void
      {
         this.averagePrice = param1.readVarLong();
         if(this.averagePrice < -9007199254740990 || this.averagePrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.averagePrice + ") on element of ExchangeBidPriceMessage.averagePrice.");
         }
      }
   }
}
