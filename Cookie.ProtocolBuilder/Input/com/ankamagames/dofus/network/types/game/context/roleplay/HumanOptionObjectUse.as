package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class HumanOptionObjectUse extends HumanOption implements INetworkType
   {
      
      public static const protocolId:uint = 449;
       
      
      public var delayTypeId:uint = 0;
      
      public var delayEndTime:Number = 0;
      
      public var objectGID:uint = 0;
      
      public function HumanOptionObjectUse()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 449;
      }
      
      public function initHumanOptionObjectUse(param1:uint = 0, param2:Number = 0, param3:uint = 0) : HumanOptionObjectUse
      {
         this.delayTypeId = param1;
         this.delayEndTime = param2;
         this.objectGID = param3;
         return this;
      }
      
      override public function reset() : void
      {
         this.delayTypeId = 0;
         this.delayEndTime = 0;
         this.objectGID = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HumanOptionObjectUse(param1);
      }
      
      public function serializeAs_HumanOptionObjectUse(param1:ICustomDataOutput) : void
      {
         super.serializeAs_HumanOption(param1);
         param1.writeByte(this.delayTypeId);
         if(this.delayEndTime < 0 || this.delayEndTime > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.delayEndTime + ") on element delayEndTime.");
         }
         param1.writeDouble(this.delayEndTime);
         if(this.objectGID < 0)
         {
            throw new Error("Forbidden value (" + this.objectGID + ") on element objectGID.");
         }
         param1.writeVarShort(this.objectGID);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HumanOptionObjectUse(param1);
      }
      
      public function deserializeAs_HumanOptionObjectUse(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._delayTypeIdFunc(param1);
         this._delayEndTimeFunc(param1);
         this._objectGIDFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HumanOptionObjectUse(param1);
      }
      
      public function deserializeAsyncAs_HumanOptionObjectUse(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._delayTypeIdFunc);
         param1.addChild(this._delayEndTimeFunc);
         param1.addChild(this._objectGIDFunc);
      }
      
      private function _delayTypeIdFunc(param1:ICustomDataInput) : void
      {
         this.delayTypeId = param1.readByte();
         if(this.delayTypeId < 0)
         {
            throw new Error("Forbidden value (" + this.delayTypeId + ") on element of HumanOptionObjectUse.delayTypeId.");
         }
      }
      
      private function _delayEndTimeFunc(param1:ICustomDataInput) : void
      {
         this.delayEndTime = param1.readDouble();
         if(this.delayEndTime < 0 || this.delayEndTime > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.delayEndTime + ") on element of HumanOptionObjectUse.delayEndTime.");
         }
      }
      
      private function _objectGIDFunc(param1:ICustomDataInput) : void
      {
         this.objectGID = param1.readVarUhShort();
         if(this.objectGID < 0)
         {
            throw new Error("Forbidden value (" + this.objectGID + ") on element of HumanOptionObjectUse.objectGID.");
         }
      }
   }
}
