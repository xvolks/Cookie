package com.ankamagames.dofus.network.messages.game.context.roleplay.houses
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
   public class HouseBuyResultMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5735;
       
      
      private var _isInitialized:Boolean = false;
      
      public var houseId:uint = 0;
      
      public var instanceId:uint = 0;
      
      public var secondHand:Boolean = false;
      
      public var bought:Boolean = false;
      
      public var realPrice:Number = 0;
      
      public function HouseBuyResultMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5735;
      }
      
      public function initHouseBuyResultMessage(param1:uint = 0, param2:uint = 0, param3:Boolean = false, param4:Boolean = false, param5:Number = 0) : HouseBuyResultMessage
      {
         this.houseId = param1;
         this.instanceId = param2;
         this.secondHand = param3;
         this.bought = param4;
         this.realPrice = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.houseId = 0;
         this.instanceId = 0;
         this.secondHand = false;
         this.bought = false;
         this.realPrice = 0;
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
         this.serializeAs_HouseBuyResultMessage(param1);
      }
      
      public function serializeAs_HouseBuyResultMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.secondHand);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.bought);
         param1.writeByte(_loc2_);
         if(this.houseId < 0)
         {
            throw new Error("Forbidden value (" + this.houseId + ") on element houseId.");
         }
         param1.writeVarInt(this.houseId);
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element instanceId.");
         }
         param1.writeInt(this.instanceId);
         if(this.realPrice < 0 || this.realPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.realPrice + ") on element realPrice.");
         }
         param1.writeVarLong(this.realPrice);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseBuyResultMessage(param1);
      }
      
      public function deserializeAs_HouseBuyResultMessage(param1:ICustomDataInput) : void
      {
         this.deserializeByteBoxes(param1);
         this._houseIdFunc(param1);
         this._instanceIdFunc(param1);
         this._realPriceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseBuyResultMessage(param1);
      }
      
      public function deserializeAsyncAs_HouseBuyResultMessage(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._houseIdFunc);
         param1.addChild(this._instanceIdFunc);
         param1.addChild(this._realPriceFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.secondHand = BooleanByteWrapper.getFlag(_loc2_,0);
         this.bought = BooleanByteWrapper.getFlag(_loc2_,1);
      }
      
      private function _houseIdFunc(param1:ICustomDataInput) : void
      {
         this.houseId = param1.readVarUhInt();
         if(this.houseId < 0)
         {
            throw new Error("Forbidden value (" + this.houseId + ") on element of HouseBuyResultMessage.houseId.");
         }
      }
      
      private function _instanceIdFunc(param1:ICustomDataInput) : void
      {
         this.instanceId = param1.readInt();
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element of HouseBuyResultMessage.instanceId.");
         }
      }
      
      private function _realPriceFunc(param1:ICustomDataInput) : void
      {
         this.realPrice = param1.readVarUhLong();
         if(this.realPrice < 0 || this.realPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.realPrice + ") on element of HouseBuyResultMessage.realPrice.");
         }
      }
   }
}
