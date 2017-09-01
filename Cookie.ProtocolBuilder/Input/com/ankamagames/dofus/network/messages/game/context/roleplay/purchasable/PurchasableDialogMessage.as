package com.ankamagames.dofus.network.messages.game.context.roleplay.purchasable
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PurchasableDialogMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5739;
       
      
      private var _isInitialized:Boolean = false;
      
      public var buyOrSell:Boolean = false;
      
      public var purchasableId:uint = 0;
      
      public var purchasableInstanceId:uint = 0;
      
      public var secondHand:Boolean = false;
      
      public var price:Number = 0;
      
      public function PurchasableDialogMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5739;
      }
      
      public function initPurchasableDialogMessage(param1:Boolean = false, param2:uint = 0, param3:uint = 0, param4:Boolean = false, param5:Number = 0) : PurchasableDialogMessage
      {
         this.buyOrSell = param1;
         this.purchasableId = param2;
         this.purchasableInstanceId = param3;
         this.secondHand = param4;
         this.price = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.buyOrSell = false;
         this.purchasableId = 0;
         this.purchasableInstanceId = 0;
         this.secondHand = false;
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
         this.serializeAs_PurchasableDialogMessage(param1);
      }
      
      public function serializeAs_PurchasableDialogMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.buyOrSell);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.secondHand);
         param1.writeByte(_loc2_);
         if(this.purchasableId < 0)
         {
            throw new Error("Forbidden value (" + this.purchasableId + ") on element purchasableId.");
         }
         param1.writeVarInt(this.purchasableId);
         if(this.purchasableInstanceId < 0)
         {
            throw new Error("Forbidden value (" + this.purchasableInstanceId + ") on element purchasableInstanceId.");
         }
         param1.writeInt(this.purchasableInstanceId);
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element price.");
         }
         param1.writeVarLong(this.price);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PurchasableDialogMessage(param1);
      }
      
      public function deserializeAs_PurchasableDialogMessage(param1:ICustomDataInput) : void
      {
         this.deserializeByteBoxes(param1);
         this._purchasableIdFunc(param1);
         this._purchasableInstanceIdFunc(param1);
         this._priceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PurchasableDialogMessage(param1);
      }
      
      public function deserializeAsyncAs_PurchasableDialogMessage(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._purchasableIdFunc);
         param1.addChild(this._purchasableInstanceIdFunc);
         param1.addChild(this._priceFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.buyOrSell = BooleanByteWrapper.getFlag(_loc2_,0);
         this.secondHand = BooleanByteWrapper.getFlag(_loc2_,1);
      }
      
      private function _purchasableIdFunc(param1:ICustomDataInput) : void
      {
         this.purchasableId = param1.readVarUhInt();
         if(this.purchasableId < 0)
         {
            throw new Error("Forbidden value (" + this.purchasableId + ") on element of PurchasableDialogMessage.purchasableId.");
         }
      }
      
      private function _purchasableInstanceIdFunc(param1:ICustomDataInput) : void
      {
         this.purchasableInstanceId = param1.readInt();
         if(this.purchasableInstanceId < 0)
         {
            throw new Error("Forbidden value (" + this.purchasableInstanceId + ") on element of PurchasableDialogMessage.purchasableInstanceId.");
         }
      }
      
      private function _priceFunc(param1:ICustomDataInput) : void
      {
         this.price = param1.readVarUhLong();
         if(this.price < 0 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element of PurchasableDialogMessage.price.");
         }
      }
   }
}
