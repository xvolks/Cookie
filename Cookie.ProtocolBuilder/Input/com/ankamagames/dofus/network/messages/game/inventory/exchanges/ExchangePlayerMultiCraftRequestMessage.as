package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangePlayerMultiCraftRequestMessage extends ExchangeRequestMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5784;
       
      
      private var _isInitialized:Boolean = false;
      
      public var target:Number = 0;
      
      public var skillId:uint = 0;
      
      public function ExchangePlayerMultiCraftRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5784;
      }
      
      public function initExchangePlayerMultiCraftRequestMessage(param1:int = 0, param2:Number = 0, param3:uint = 0) : ExchangePlayerMultiCraftRequestMessage
      {
         super.initExchangeRequestMessage(param1);
         this.target = param2;
         this.skillId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.target = 0;
         this.skillId = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         if(HASH_FUNCTION != null)
         {
            HASH_FUNCTION(_loc2_);
         }
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
         this.serializeAs_ExchangePlayerMultiCraftRequestMessage(param1);
      }
      
      public function serializeAs_ExchangePlayerMultiCraftRequestMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ExchangeRequestMessage(param1);
         if(this.target < 0 || this.target > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.target + ") on element target.");
         }
         param1.writeVarLong(this.target);
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element skillId.");
         }
         param1.writeVarInt(this.skillId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangePlayerMultiCraftRequestMessage(param1);
      }
      
      public function deserializeAs_ExchangePlayerMultiCraftRequestMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._targetFunc(param1);
         this._skillIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangePlayerMultiCraftRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangePlayerMultiCraftRequestMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._targetFunc);
         param1.addChild(this._skillIdFunc);
      }
      
      private function _targetFunc(param1:ICustomDataInput) : void
      {
         this.target = param1.readVarUhLong();
         if(this.target < 0 || this.target > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.target + ") on element of ExchangePlayerMultiCraftRequestMessage.target.");
         }
      }
      
      private function _skillIdFunc(param1:ICustomDataInput) : void
      {
         this.skillId = param1.readVarUhInt();
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element of ExchangePlayerMultiCraftRequestMessage.skillId.");
         }
      }
   }
}
