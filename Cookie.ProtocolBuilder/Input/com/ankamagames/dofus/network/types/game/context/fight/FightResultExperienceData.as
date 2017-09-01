package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightResultExperienceData extends FightResultAdditionalData implements INetworkType
   {
      
      public static const protocolId:uint = 192;
       
      
      public var experience:Number = 0;
      
      public var showExperience:Boolean = false;
      
      public var experienceLevelFloor:Number = 0;
      
      public var showExperienceLevelFloor:Boolean = false;
      
      public var experienceNextLevelFloor:Number = 0;
      
      public var showExperienceNextLevelFloor:Boolean = false;
      
      public var experienceFightDelta:Number = 0;
      
      public var showExperienceFightDelta:Boolean = false;
      
      public var experienceForGuild:Number = 0;
      
      public var showExperienceForGuild:Boolean = false;
      
      public var experienceForMount:Number = 0;
      
      public var showExperienceForMount:Boolean = false;
      
      public var isIncarnationExperience:Boolean = false;
      
      public var rerollExperienceMul:uint = 0;
      
      public function FightResultExperienceData()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 192;
      }
      
      public function initFightResultExperienceData(param1:Number = 0, param2:Boolean = false, param3:Number = 0, param4:Boolean = false, param5:Number = 0, param6:Boolean = false, param7:Number = 0, param8:Boolean = false, param9:Number = 0, param10:Boolean = false, param11:Number = 0, param12:Boolean = false, param13:Boolean = false, param14:uint = 0) : FightResultExperienceData
      {
         this.experience = param1;
         this.showExperience = param2;
         this.experienceLevelFloor = param3;
         this.showExperienceLevelFloor = param4;
         this.experienceNextLevelFloor = param5;
         this.showExperienceNextLevelFloor = param6;
         this.experienceFightDelta = param7;
         this.showExperienceFightDelta = param8;
         this.experienceForGuild = param9;
         this.showExperienceForGuild = param10;
         this.experienceForMount = param11;
         this.showExperienceForMount = param12;
         this.isIncarnationExperience = param13;
         this.rerollExperienceMul = param14;
         return this;
      }
      
      override public function reset() : void
      {
         this.experience = 0;
         this.showExperience = false;
         this.experienceLevelFloor = 0;
         this.showExperienceLevelFloor = false;
         this.experienceNextLevelFloor = 0;
         this.showExperienceNextLevelFloor = false;
         this.experienceFightDelta = 0;
         this.showExperienceFightDelta = false;
         this.experienceForGuild = 0;
         this.showExperienceForGuild = false;
         this.experienceForMount = 0;
         this.showExperienceForMount = false;
         this.isIncarnationExperience = false;
         this.rerollExperienceMul = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightResultExperienceData(param1);
      }
      
      public function serializeAs_FightResultExperienceData(param1:ICustomDataOutput) : void
      {
         super.serializeAs_FightResultAdditionalData(param1);
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.showExperience);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.showExperienceLevelFloor);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,2,this.showExperienceNextLevelFloor);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,3,this.showExperienceFightDelta);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,4,this.showExperienceForGuild);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,5,this.showExperienceForMount);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,6,this.isIncarnationExperience);
         param1.writeByte(_loc2_);
         if(this.experience < 0 || this.experience > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experience + ") on element experience.");
         }
         param1.writeVarLong(this.experience);
         if(this.experienceLevelFloor < 0 || this.experienceLevelFloor > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experienceLevelFloor + ") on element experienceLevelFloor.");
         }
         param1.writeVarLong(this.experienceLevelFloor);
         if(this.experienceNextLevelFloor < 0 || this.experienceNextLevelFloor > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experienceNextLevelFloor + ") on element experienceNextLevelFloor.");
         }
         param1.writeVarLong(this.experienceNextLevelFloor);
         if(this.experienceFightDelta < 0 || this.experienceFightDelta > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experienceFightDelta + ") on element experienceFightDelta.");
         }
         param1.writeVarLong(this.experienceFightDelta);
         if(this.experienceForGuild < 0 || this.experienceForGuild > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experienceForGuild + ") on element experienceForGuild.");
         }
         param1.writeVarLong(this.experienceForGuild);
         if(this.experienceForMount < 0 || this.experienceForMount > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experienceForMount + ") on element experienceForMount.");
         }
         param1.writeVarLong(this.experienceForMount);
         if(this.rerollExperienceMul < 0)
         {
            throw new Error("Forbidden value (" + this.rerollExperienceMul + ") on element rerollExperienceMul.");
         }
         param1.writeByte(this.rerollExperienceMul);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightResultExperienceData(param1);
      }
      
      public function deserializeAs_FightResultExperienceData(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.deserializeByteBoxes(param1);
         this._experienceFunc(param1);
         this._experienceLevelFloorFunc(param1);
         this._experienceNextLevelFloorFunc(param1);
         this._experienceFightDeltaFunc(param1);
         this._experienceForGuildFunc(param1);
         this._experienceForMountFunc(param1);
         this._rerollExperienceMulFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightResultExperienceData(param1);
      }
      
      public function deserializeAsyncAs_FightResultExperienceData(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._experienceFunc);
         param1.addChild(this._experienceLevelFloorFunc);
         param1.addChild(this._experienceNextLevelFloorFunc);
         param1.addChild(this._experienceFightDeltaFunc);
         param1.addChild(this._experienceForGuildFunc);
         param1.addChild(this._experienceForMountFunc);
         param1.addChild(this._rerollExperienceMulFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.showExperience = BooleanByteWrapper.getFlag(_loc2_,0);
         this.showExperienceLevelFloor = BooleanByteWrapper.getFlag(_loc2_,1);
         this.showExperienceNextLevelFloor = BooleanByteWrapper.getFlag(_loc2_,2);
         this.showExperienceFightDelta = BooleanByteWrapper.getFlag(_loc2_,3);
         this.showExperienceForGuild = BooleanByteWrapper.getFlag(_loc2_,4);
         this.showExperienceForMount = BooleanByteWrapper.getFlag(_loc2_,5);
         this.isIncarnationExperience = BooleanByteWrapper.getFlag(_loc2_,6);
      }
      
      private function _experienceFunc(param1:ICustomDataInput) : void
      {
         this.experience = param1.readVarUhLong();
         if(this.experience < 0 || this.experience > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experience + ") on element of FightResultExperienceData.experience.");
         }
      }
      
      private function _experienceLevelFloorFunc(param1:ICustomDataInput) : void
      {
         this.experienceLevelFloor = param1.readVarUhLong();
         if(this.experienceLevelFloor < 0 || this.experienceLevelFloor > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experienceLevelFloor + ") on element of FightResultExperienceData.experienceLevelFloor.");
         }
      }
      
      private function _experienceNextLevelFloorFunc(param1:ICustomDataInput) : void
      {
         this.experienceNextLevelFloor = param1.readVarUhLong();
         if(this.experienceNextLevelFloor < 0 || this.experienceNextLevelFloor > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experienceNextLevelFloor + ") on element of FightResultExperienceData.experienceNextLevelFloor.");
         }
      }
      
      private function _experienceFightDeltaFunc(param1:ICustomDataInput) : void
      {
         this.experienceFightDelta = param1.readVarUhLong();
         if(this.experienceFightDelta < 0 || this.experienceFightDelta > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experienceFightDelta + ") on element of FightResultExperienceData.experienceFightDelta.");
         }
      }
      
      private function _experienceForGuildFunc(param1:ICustomDataInput) : void
      {
         this.experienceForGuild = param1.readVarUhLong();
         if(this.experienceForGuild < 0 || this.experienceForGuild > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experienceForGuild + ") on element of FightResultExperienceData.experienceForGuild.");
         }
      }
      
      private function _experienceForMountFunc(param1:ICustomDataInput) : void
      {
         this.experienceForMount = param1.readVarUhLong();
         if(this.experienceForMount < 0 || this.experienceForMount > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.experienceForMount + ") on element of FightResultExperienceData.experienceForMount.");
         }
      }
      
      private function _rerollExperienceMulFunc(param1:ICustomDataInput) : void
      {
         this.rerollExperienceMul = param1.readByte();
         if(this.rerollExperienceMul < 0)
         {
            throw new Error("Forbidden value (" + this.rerollExperienceMul + ") on element of FightResultExperienceData.rerollExperienceMul.");
         }
      }
   }
}
