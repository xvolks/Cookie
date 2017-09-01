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
   public class ExchangeBuyMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5774;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objectToBuyId:uint = 0;
      
      public var quantity:uint = 0;
      
      public function ExchangeBuyMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5774;
      }
      
      public function initExchangeBuyMessage(param1:uint = 0, param2:uint = 0) : ExchangeBuyMessage
      {
         this.objectToBuyId = param1;
         this.quantity = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.objectToBuyId = 0;
         this.quantity = 0;
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
         this.serializeAs_ExchangeBuyMessage(param1);
      }
      
      public function serializeAs_ExchangeBuyMessage(param1:ICustomDataOutput) : void
      {
         if(this.objectToBuyId < 0)
         {
            throw new Error("Forbidden value (" + this.objectToBuyId + ") on element objectToBuyId.");
         }
         param1.writeVarInt(this.objectToBuyId);
         if(this.quantity < 0)
         {
            throw new Error("Forbidden value (" + this.quantity + ") on element quantity.");
         }
         param1.writeVarInt(this.quantity);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeBuyMessage(param1);
      }
      
      public function deserializeAs_ExchangeBuyMessage(param1:ICustomDataInput) : void
      {
         this._objectToBuyIdFunc(param1);
         this._quantityFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeBuyMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeBuyMessage(param1:FuncTree) : void
      {
         param1.addChild(this._objectToBuyIdFunc);
         param1.addChild(this._quantityFunc);
      }
      
      private function _objectToBuyIdFunc(param1:ICustomDataInput) : void
      {
         this.objectToBuyId = param1.readVarUhInt();
         if(this.objectToBuyId < 0)
         {
            throw new Error("Forbidden value (" + this.objectToBuyId + ") on element of ExchangeBuyMessage.objectToBuyId.");
         }
      }
      
      private function _quantityFunc(param1:ICustomDataInput) : void
      {
         this.quantity = param1.readVarUhInt();
         if(this.quantity < 0)
         {
            throw new Error("Forbidden value (" + this.quantity + ") on element of ExchangeBuyMessage.quantity.");
         }
      }
   }
}
