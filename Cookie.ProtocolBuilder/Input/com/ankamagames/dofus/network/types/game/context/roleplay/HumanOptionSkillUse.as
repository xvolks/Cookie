package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class HumanOptionSkillUse extends HumanOption implements INetworkType
   {
      
      public static const protocolId:uint = 495;
       
      
      public var elementId:uint = 0;
      
      public var skillId:uint = 0;
      
      public var skillEndTime:Number = 0;
      
      public function HumanOptionSkillUse()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 495;
      }
      
      public function initHumanOptionSkillUse(param1:uint = 0, param2:uint = 0, param3:Number = 0) : HumanOptionSkillUse
      {
         this.elementId = param1;
         this.skillId = param2;
         this.skillEndTime = param3;
         return this;
      }
      
      override public function reset() : void
      {
         this.elementId = 0;
         this.skillId = 0;
         this.skillEndTime = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HumanOptionSkillUse(param1);
      }
      
      public function serializeAs_HumanOptionSkillUse(param1:ICustomDataOutput) : void
      {
         super.serializeAs_HumanOption(param1);
         if(this.elementId < 0)
         {
            throw new Error("Forbidden value (" + this.elementId + ") on element elementId.");
         }
         param1.writeVarInt(this.elementId);
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element skillId.");
         }
         param1.writeVarShort(this.skillId);
         if(this.skillEndTime < -9007199254740990 || this.skillEndTime > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.skillEndTime + ") on element skillEndTime.");
         }
         param1.writeDouble(this.skillEndTime);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HumanOptionSkillUse(param1);
      }
      
      public function deserializeAs_HumanOptionSkillUse(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._elementIdFunc(param1);
         this._skillIdFunc(param1);
         this._skillEndTimeFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HumanOptionSkillUse(param1);
      }
      
      public function deserializeAsyncAs_HumanOptionSkillUse(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._elementIdFunc);
         param1.addChild(this._skillIdFunc);
         param1.addChild(this._skillEndTimeFunc);
      }
      
      private function _elementIdFunc(param1:ICustomDataInput) : void
      {
         this.elementId = param1.readVarUhInt();
         if(this.elementId < 0)
         {
            throw new Error("Forbidden value (" + this.elementId + ") on element of HumanOptionSkillUse.elementId.");
         }
      }
      
      private function _skillIdFunc(param1:ICustomDataInput) : void
      {
         this.skillId = param1.readVarUhShort();
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element of HumanOptionSkillUse.skillId.");
         }
      }
      
      private function _skillEndTimeFunc(param1:ICustomDataInput) : void
      {
         this.skillEndTime = param1.readDouble();
         if(this.skillEndTime < -9007199254740990 || this.skillEndTime > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.skillEndTime + ") on element of HumanOptionSkillUse.skillEndTime.");
         }
      }
   }
}
