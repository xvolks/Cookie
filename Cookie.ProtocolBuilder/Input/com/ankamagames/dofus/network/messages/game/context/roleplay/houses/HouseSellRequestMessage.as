package com.ankamagames.dofus.network.messages.game.context.roleplay.houses
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class HouseSellRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5697;
       
      
      private var _isInitialized:Boolean = false;
      
      public var instanceId:uint = 0;
      
      public var amount:Number = 0;
      
      public var forSale:Boolean = false;
      
      public function HouseSellRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5697;
      }
      
      public function initHouseSellRequestMessage(param1:uint = 0, param2:Number = 0, param3:Boolean = false) : HouseSellRequestMessage
      {
         this.instanceId = param1;
         this.amount = param2;
         this.forSale = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.instanceId = 0;
         this.amount = 0;
         this.forSale = false;
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
         this.serializeAs_HouseSellRequestMessage(param1);
      }
      
      public function serializeAs_HouseSellRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element instanceId.");
         }
         param1.writeInt(this.instanceId);
         if(this.amount < 0 || this.amount > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.amount + ") on element amount.");
         }
         param1.writeVarLong(this.amount);
         param1.writeBoolean(this.forSale);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseSellRequestMessage(param1);
      }
      
      public function deserializeAs_HouseSellRequestMessage(param1:ICustomDataInput) : void
      {
         this._instanceIdFunc(param1);
         this._amountFunc(param1);
         this._forSaleFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseSellRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_HouseSellRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._instanceIdFunc);
         param1.addChild(this._amountFunc);
         param1.addChild(this._forSaleFunc);
      }
      
      private function _instanceIdFunc(param1:ICustomDataInput) : void
      {
         this.instanceId = param1.readInt();
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element of HouseSellRequestMessage.instanceId.");
         }
      }
      
      private function _amountFunc(param1:ICustomDataInput) : void
      {
         this.amount = param1.readVarUhLong();
         if(this.amount < 0 || this.amount > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.amount + ") on element of HouseSellRequestMessage.amount.");
         }
      }
      
      private function _forSaleFunc(param1:ICustomDataInput) : void
      {
         this.forSale = param1.readBoolean();
      }
   }
}
