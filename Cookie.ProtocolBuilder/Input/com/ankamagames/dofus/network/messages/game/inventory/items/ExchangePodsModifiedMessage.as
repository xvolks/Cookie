package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.dofus.network.messages.game.inventory.exchanges.ExchangeObjectMessage;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangePodsModifiedMessage extends ExchangeObjectMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6670;
       
      
      private var _isInitialized:Boolean = false;
      
      public var currentWeight:uint = 0;
      
      public var maxWeight:uint = 0;
      
      public function ExchangePodsModifiedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6670;
      }
      
      public function initExchangePodsModifiedMessage(param1:Boolean = false, param2:uint = 0, param3:uint = 0) : ExchangePodsModifiedMessage
      {
         super.initExchangeObjectMessage(param1);
         this.currentWeight = param2;
         this.maxWeight = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.currentWeight = 0;
         this.maxWeight = 0;
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
         this.serializeAs_ExchangePodsModifiedMessage(param1);
      }
      
      public function serializeAs_ExchangePodsModifiedMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ExchangeObjectMessage(param1);
         if(this.currentWeight < 0)
         {
            throw new Error("Forbidden value (" + this.currentWeight + ") on element currentWeight.");
         }
         param1.writeVarInt(this.currentWeight);
         if(this.maxWeight < 0)
         {
            throw new Error("Forbidden value (" + this.maxWeight + ") on element maxWeight.");
         }
         param1.writeVarInt(this.maxWeight);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangePodsModifiedMessage(param1);
      }
      
      public function deserializeAs_ExchangePodsModifiedMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._currentWeightFunc(param1);
         this._maxWeightFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangePodsModifiedMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangePodsModifiedMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._currentWeightFunc);
         param1.addChild(this._maxWeightFunc);
      }
      
      private function _currentWeightFunc(param1:ICustomDataInput) : void
      {
         this.currentWeight = param1.readVarUhInt();
         if(this.currentWeight < 0)
         {
            throw new Error("Forbidden value (" + this.currentWeight + ") on element of ExchangePodsModifiedMessage.currentWeight.");
         }
      }
      
      private function _maxWeightFunc(param1:ICustomDataInput) : void
      {
         this.maxWeight = param1.readVarUhInt();
         if(this.maxWeight < 0)
         {
            throw new Error("Forbidden value (" + this.maxWeight + ") on element of ExchangePodsModifiedMessage.maxWeight.");
         }
      }
   }
}
