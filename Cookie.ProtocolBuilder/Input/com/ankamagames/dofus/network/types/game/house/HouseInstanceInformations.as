package com.ankamagames.dofus.network.types.game.house
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class HouseInstanceInformations implements INetworkType
   {
      
      public static const protocolId:uint = 511;
       
      
      public var instanceId:uint = 0;
      
      public var secondHand:Boolean = false;
      
      public var isLocked:Boolean = false;
      
      public var ownerName:String = "";
      
      public var price:Number = 0;
      
      public var isSaleLocked:Boolean = false;
      
      public function HouseInstanceInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 511;
      }
      
      public function initHouseInstanceInformations(param1:uint = 0, param2:Boolean = false, param3:Boolean = false, param4:String = "", param5:Number = 0, param6:Boolean = false) : HouseInstanceInformations
      {
         this.instanceId = param1;
         this.secondHand = param2;
         this.isLocked = param3;
         this.ownerName = param4;
         this.price = param5;
         this.isSaleLocked = param6;
         return this;
      }
      
      public function reset() : void
      {
         this.instanceId = 0;
         this.secondHand = false;
         this.isLocked = false;
         this.ownerName = "";
         this.price = 0;
         this.isSaleLocked = false;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HouseInstanceInformations(param1);
      }
      
      public function serializeAs_HouseInstanceInformations(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.secondHand);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.isLocked);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,2,this.isSaleLocked);
         param1.writeByte(_loc2_);
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element instanceId.");
         }
         param1.writeInt(this.instanceId);
         param1.writeUTF(this.ownerName);
         if(this.price < -9007199254740990 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element price.");
         }
         param1.writeVarLong(this.price);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseInstanceInformations(param1);
      }
      
      public function deserializeAs_HouseInstanceInformations(param1:ICustomDataInput) : void
      {
         this.deserializeByteBoxes(param1);
         this._instanceIdFunc(param1);
         this._ownerNameFunc(param1);
         this._priceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseInstanceInformations(param1);
      }
      
      public function deserializeAsyncAs_HouseInstanceInformations(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._instanceIdFunc);
         param1.addChild(this._ownerNameFunc);
         param1.addChild(this._priceFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.secondHand = BooleanByteWrapper.getFlag(_loc2_,0);
         this.isLocked = BooleanByteWrapper.getFlag(_loc2_,1);
         this.isSaleLocked = BooleanByteWrapper.getFlag(_loc2_,2);
      }
      
      private function _instanceIdFunc(param1:ICustomDataInput) : void
      {
         this.instanceId = param1.readInt();
         if(this.instanceId < 0)
         {
            throw new Error("Forbidden value (" + this.instanceId + ") on element of HouseInstanceInformations.instanceId.");
         }
      }
      
      private function _ownerNameFunc(param1:ICustomDataInput) : void
      {
         this.ownerName = param1.readUTF();
      }
      
      private function _priceFunc(param1:ICustomDataInput) : void
      {
         this.price = param1.readVarLong();
         if(this.price < -9007199254740990 || this.price > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.price + ") on element of HouseInstanceInformations.price.");
         }
      }
   }
}
