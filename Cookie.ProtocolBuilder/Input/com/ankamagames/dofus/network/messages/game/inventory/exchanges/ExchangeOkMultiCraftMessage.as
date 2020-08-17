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
   public class ExchangeOkMultiCraftMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5768;
       
      
      private var _isInitialized:Boolean = false;
      
      public var initiatorId:Number = 0;
      
      public var otherId:Number = 0;
      
      public var role:int = 0;
      
      public function ExchangeOkMultiCraftMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5768;
      }
      
      public function initExchangeOkMultiCraftMessage(param1:Number = 0, param2:Number = 0, param3:int = 0) : ExchangeOkMultiCraftMessage
      {
         this.initiatorId = param1;
         this.otherId = param2;
         this.role = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.initiatorId = 0;
         this.otherId = 0;
         this.role = 0;
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
         this.serializeAs_ExchangeOkMultiCraftMessage(param1);
      }
      
      public function serializeAs_ExchangeOkMultiCraftMessage(param1:ICustomDataOutput) : void
      {
         if(this.initiatorId < 0 || this.initiatorId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.initiatorId + ") on element initiatorId.");
         }
         param1.writeVarLong(this.initiatorId);
         if(this.otherId < 0 || this.otherId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.otherId + ") on element otherId.");
         }
         param1.writeVarLong(this.otherId);
         param1.writeByte(this.role);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeOkMultiCraftMessage(param1);
      }
      
      public function deserializeAs_ExchangeOkMultiCraftMessage(param1:ICustomDataInput) : void
      {
         this._initiatorIdFunc(param1);
         this._otherIdFunc(param1);
         this._roleFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeOkMultiCraftMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeOkMultiCraftMessage(param1:FuncTree) : void
      {
         param1.addChild(this._initiatorIdFunc);
         param1.addChild(this._otherIdFunc);
         param1.addChild(this._roleFunc);
      }
      
      private function _initiatorIdFunc(param1:ICustomDataInput) : void
      {
         this.initiatorId = param1.readVarUhLong();
         if(this.initiatorId < 0 || this.initiatorId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.initiatorId + ") on element of ExchangeOkMultiCraftMessage.initiatorId.");
         }
      }
      
      private function _otherIdFunc(param1:ICustomDataInput) : void
      {
         this.otherId = param1.readVarUhLong();
         if(this.otherId < 0 || this.otherId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.otherId + ") on element of ExchangeOkMultiCraftMessage.otherId.");
         }
      }
      
      private function _roleFunc(param1:ICustomDataInput) : void
      {
         this.role = param1.readByte();
      }
   }
}
