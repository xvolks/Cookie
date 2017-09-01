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
   public class ExchangeStartOkNpcTradeMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5785;
       
      
      private var _isInitialized:Boolean = false;
      
      public var npcId:Number = 0;
      
      public function ExchangeStartOkNpcTradeMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5785;
      }
      
      public function initExchangeStartOkNpcTradeMessage(param1:Number = 0) : ExchangeStartOkNpcTradeMessage
      {
         this.npcId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.npcId = 0;
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
         this.serializeAs_ExchangeStartOkNpcTradeMessage(param1);
      }
      
      public function serializeAs_ExchangeStartOkNpcTradeMessage(param1:ICustomDataOutput) : void
      {
         if(this.npcId < -9007199254740990 || this.npcId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.npcId + ") on element npcId.");
         }
         param1.writeDouble(this.npcId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeStartOkNpcTradeMessage(param1);
      }
      
      public function deserializeAs_ExchangeStartOkNpcTradeMessage(param1:ICustomDataInput) : void
      {
         this._npcIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeStartOkNpcTradeMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeStartOkNpcTradeMessage(param1:FuncTree) : void
      {
         param1.addChild(this._npcIdFunc);
      }
      
      private function _npcIdFunc(param1:ICustomDataInput) : void
      {
         this.npcId = param1.readDouble();
         if(this.npcId < -9007199254740990 || this.npcId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.npcId + ") on element of ExchangeStartOkNpcTradeMessage.npcId.");
         }
      }
   }
}
