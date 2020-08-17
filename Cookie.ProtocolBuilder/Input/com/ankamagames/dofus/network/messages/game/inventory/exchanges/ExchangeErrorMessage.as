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
   public class ExchangeErrorMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5513;
       
      
      private var _isInitialized:Boolean = false;
      
      public var errorType:int = 0;
      
      public function ExchangeErrorMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5513;
      }
      
      public function initExchangeErrorMessage(param1:int = 0) : ExchangeErrorMessage
      {
         this.errorType = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.errorType = 0;
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
         this.serializeAs_ExchangeErrorMessage(param1);
      }
      
      public function serializeAs_ExchangeErrorMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.errorType);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeErrorMessage(param1);
      }
      
      public function deserializeAs_ExchangeErrorMessage(param1:ICustomDataInput) : void
      {
         this._errorTypeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeErrorMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeErrorMessage(param1:FuncTree) : void
      {
         param1.addChild(this._errorTypeFunc);
      }
      
      private function _errorTypeFunc(param1:ICustomDataInput) : void
      {
         this.errorType = param1.readByte();
      }
   }
}
