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
   public class ExchangeBidHouseBuyResultMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6272;
       
      
      private var _isInitialized:Boolean = false;
      
      public var uid:uint = 0;
      
      public var bought:Boolean = false;
      
      public function ExchangeBidHouseBuyResultMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6272;
      }
      
      public function initExchangeBidHouseBuyResultMessage(param1:uint = 0, param2:Boolean = false) : ExchangeBidHouseBuyResultMessage
      {
         this.uid = param1;
         this.bought = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.uid = 0;
         this.bought = false;
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
         this.serializeAs_ExchangeBidHouseBuyResultMessage(param1);
      }
      
      public function serializeAs_ExchangeBidHouseBuyResultMessage(param1:ICustomDataOutput) : void
      {
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element uid.");
         }
         param1.writeVarInt(this.uid);
         param1.writeBoolean(this.bought);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeBidHouseBuyResultMessage(param1);
      }
      
      public function deserializeAs_ExchangeBidHouseBuyResultMessage(param1:ICustomDataInput) : void
      {
         this._uidFunc(param1);
         this._boughtFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeBidHouseBuyResultMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeBidHouseBuyResultMessage(param1:FuncTree) : void
      {
         param1.addChild(this._uidFunc);
         param1.addChild(this._boughtFunc);
      }
      
      private function _uidFunc(param1:ICustomDataInput) : void
      {
         this.uid = param1.readVarUhInt();
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element of ExchangeBidHouseBuyResultMessage.uid.");
         }
      }
      
      private function _boughtFunc(param1:ICustomDataInput) : void
      {
         this.bought = param1.readBoolean();
      }
   }
}
