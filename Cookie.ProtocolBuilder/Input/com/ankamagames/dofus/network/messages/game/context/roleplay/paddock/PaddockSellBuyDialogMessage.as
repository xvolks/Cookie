package com.ankamagames.dofus.network.messages.game.context.roleplay.paddock
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PaddockSellBuyDialogMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6018;
       
      
      private var _isInitialized:Boolean = false;
      
      public var bsell:Boolean = false;
      
      public var ownerId:uint = 0;
      
      public var price:Number = 0;
      
      public function PaddockSellBuyDialogMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6018;
      }
      
      public function initPaddockSellBuyDialogMessage(param1:Boolean = false, param2:uint = 0, param3:Number = 0) : PaddockSellBuyDialogMessage
      {
         this.bsell = param1;
         this.ownerId = param2;
         this.price = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.bsell = false;
         this.ownerId = 0;
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
         this.serializeAs_PaddockSellBuyDialogMessage(param1);
      }
      
      public function serializeAs_PaddockSellBuyDialogMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.bsell);
         if(this.ownerId < 0)
         {
            throw new Error("Forbidden value (" + this.ownerId + ") on element ownerId.");
         }
         param1.writeVarInt(this.ownerId);
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element price.");
         }
         param1.writeVarLong(this.price);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockSellBuyDialogMessage(param1);
      }
      
      public function deserializeAs_PaddockSellBuyDialogMessage(param1:ICustomDataInput) : void
      {
         this._bsellFunc(param1);
         this._ownerIdFunc(param1);
         this._priceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockSellBuyDialogMessage(param1);
      }
      
      public function deserializeAsyncAs_PaddockSellBuyDialogMessage(param1:FuncTree) : void
      {
         param1.addChild(this._bsellFunc);
         param1.addChild(this._ownerIdFunc);
         param1.addChild(this._priceFunc);
      }
      
      private function _bsellFunc(param1:ICustomDataInput) : void
      {
         this.bsell = param1.readBoolean();
      }
      
      private function _ownerIdFunc(param1:ICustomDataInput) : void
      {
         this.ownerId = param1.readVarUhInt();
         if(this.ownerId < 0)
         {
            throw new Error("Forbidden value (" + this.ownerId + ") on element of PaddockSellBuyDialogMessage.ownerId.");
         }
      }
      
      private function _priceFunc(param1:ICustomDataInput) : void
      {
         this.price = param1.readVarUhLong();
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element of PaddockSellBuyDialogMessage.price.");
         }
      }
   }
}
