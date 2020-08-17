package com.ankamagames.dofus.network.types.game.interactive.skill
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class SkillActionDescription implements INetworkType
   {
      
      public static const protocolId:uint = 102;
       
      
      public var skillId:uint = 0;
      
      public function SkillActionDescription()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 102;
      }
      
      public function initSkillActionDescription(param1:uint = 0) : SkillActionDescription
      {
         this.skillId = param1;
         return this;
      }
      
      public function reset() : void
      {
         this.skillId = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_SkillActionDescription(param1);
      }
      
      public function serializeAs_SkillActionDescription(param1:ICustomDataOutput) : void
      {
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element skillId.");
         }
         param1.writeVarShort(this.skillId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SkillActionDescription(param1);
      }
      
      public function deserializeAs_SkillActionDescription(param1:ICustomDataInput) : void
      {
         this._skillIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SkillActionDescription(param1);
      }
      
      public function deserializeAsyncAs_SkillActionDescription(param1:FuncTree) : void
      {
         param1.addChild(this._skillIdFunc);
      }
      
      private function _skillIdFunc(param1:ICustomDataInput) : void
      {
         this.skillId = param1.readVarUhShort();
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element of SkillActionDescription.skillId.");
         }
      }
   }
}
