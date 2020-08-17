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
   public class ExchangeReadyMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5511;
       
      
      private var _isInitialized:Boolean = false;
      
      public var ready:Boolean = false;
      
      public var step:uint = 0;
      
      public function ExchangeReadyMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5511;
      }
      
      public function initExchangeReadyMessage(param1:Boolean = false, param2:uint = 0) : ExchangeReadyMessage
      {
         this.ready = param1;
         this.step = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.ready = false;
         this.step = 0;
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
         this.serializeAs_ExchangeReadyMessage(param1);
      }
      
      public function serializeAs_ExchangeReadyMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.ready);
         if(this.step < 0)
         {
            throw new Error("Forbidden value (" + this.step + ") on element step.");
         }
         param1.writeVarShort(this.step);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeReadyMessage(param1);
      }
      
      public function deserializeAs_ExchangeReadyMessage(param1:ICustomDataInput) : void
      {
         this._readyFunc(param1);
         this._stepFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeReadyMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeReadyMessage(param1:FuncTree) : void
      {
         param1.addChild(this._readyFunc);
         param1.addChild(this._stepFunc);
      }
      
      private function _readyFunc(param1:ICustomDataInput) : void
      {
         this.ready = param1.readBoolean();
      }
      
      private function _stepFunc(param1:ICustomDataInput) : void
      {
         this.step = param1.readVarUhShort();
         if(this.step < 0)
         {
            throw new Error("Forbidden value (" + this.step + ") on element of ExchangeReadyMessage.step.");
         }
      }
   }
}
