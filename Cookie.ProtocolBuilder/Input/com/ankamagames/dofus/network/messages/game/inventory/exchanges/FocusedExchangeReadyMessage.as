package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class FocusedExchangeReadyMessage extends ExchangeReadyMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6701;
       
      
      private var _isInitialized:Boolean = false;
      
      public var focusActionId:uint = 0;
      
      public function FocusedExchangeReadyMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6701;
      }
      
      public function initFocusedExchangeReadyMessage(param1:Boolean = false, param2:uint = 0, param3:uint = 0) : FocusedExchangeReadyMessage
      {
         super.initExchangeReadyMessage(param1,param2);
         this.focusActionId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.focusActionId = 0;
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
         this.serializeAs_FocusedExchangeReadyMessage(param1);
      }
      
      public function serializeAs_FocusedExchangeReadyMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ExchangeReadyMessage(param1);
         if(this.focusActionId < 0)
         {
            throw new Error("Forbidden value (" + this.focusActionId + ") on element focusActionId.");
         }
         param1.writeVarInt(this.focusActionId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FocusedExchangeReadyMessage(param1);
      }
      
      public function deserializeAs_FocusedExchangeReadyMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._focusActionIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FocusedExchangeReadyMessage(param1);
      }
      
      public function deserializeAsyncAs_FocusedExchangeReadyMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._focusActionIdFunc);
      }
      
      private function _focusActionIdFunc(param1:ICustomDataInput) : void
      {
         this.focusActionId = param1.readVarUhInt();
         if(this.focusActionId < 0)
         {
            throw new Error("Forbidden value (" + this.focusActionId + ") on element of FocusedExchangeReadyMessage.focusActionId.");
         }
      }
   }
}
