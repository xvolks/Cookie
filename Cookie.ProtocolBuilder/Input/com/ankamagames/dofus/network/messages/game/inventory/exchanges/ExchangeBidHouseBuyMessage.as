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
   public class ExchangeBidHouseBuyMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5804;
       
      
      private var _isInitialized:Boolean = false;
      
      public var uid:uint = 0;
      
      public var qty:uint = 0;
      
      public var price:Number = 0;
      
      public function ExchangeBidHouseBuyMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5804;
      }
      
      public function initExchangeBidHouseBuyMessage(param1:uint = 0, param2:uint = 0, param3:Number = 0) : ExchangeBidHouseBuyMessage
      {
         this.uid = param1;
         this.qty = param2;
         this.price = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.uid = 0;
         this.qty = 0;
         this.price = 0;
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
         this.serializeAs_ExchangeBidHouseBuyMessage(param1);
      }
      
      public function serializeAs_ExchangeBidHouseBuyMessage(param1:ICustomDataOutput) : void
      {
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element uid.");
         }
         param1.writeVarInt(this.uid);
         if(this.qty < 0)
         {
            throw new Error("Forbidden value (" + this.qty + ") on element qty.");
         }
         param1.writeVarInt(this.qty);
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element price.");
         }
         param1.writeVarLong(this.price);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeBidHouseBuyMessage(param1);
      }
      
      public function deserializeAs_ExchangeBidHouseBuyMessage(param1:ICustomDataInput) : void
      {
         this._uidFunc(param1);
         this._qtyFunc(param1);
         this._priceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeBidHouseBuyMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeBidHouseBuyMessage(param1:FuncTree) : void
      {
         param1.addChild(this._uidFunc);
         param1.addChild(this._qtyFunc);
         param1.addChild(this._priceFunc);
      }
      
      private function _uidFunc(param1:ICustomDataInput) : void
      {
         this.uid = param1.readVarUhInt();
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element of ExchangeBidHouseBuyMessage.uid.");
         }
      }
      
      private function _qtyFunc(param1:ICustomDataInput) : void
      {
         this.qty = param1.readVarUhInt();
         if(this.qty < 0)
         {
            throw new Error("Forbidden value (" + this.qty + ") on element of ExchangeBidHouseBuyMessage.qty.");
         }
      }
      
      private function _priceFunc(param1:ICustomDataInput) : void
      {
         this.price = param1.readVarUhLong();
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element of ExchangeBidHouseBuyMessage.price.");
         }
      }
   }
}
