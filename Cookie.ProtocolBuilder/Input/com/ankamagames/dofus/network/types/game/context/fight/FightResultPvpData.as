package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightResultPvpData extends FightResultAdditionalData implements INetworkType
   {
      
      public static const protocolId:uint = 190;
       
      
      public var grade:uint = 0;
      
      public var minHonorForGrade:uint = 0;
      
      public var maxHonorForGrade:uint = 0;
      
      public var honor:uint = 0;
      
      public var honorDelta:int = 0;
      
      public function FightResultPvpData()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 190;
      }
      
      public function initFightResultPvpData(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:int = 0) : FightResultPvpData
      {
         this.grade = param1;
         this.minHonorForGrade = param2;
         this.maxHonorForGrade = param3;
         this.honor = param4;
         this.honorDelta = param5;
         return this;
      }
      
      override public function reset() : void
      {
         this.grade = 0;
         this.minHonorForGrade = 0;
         this.maxHonorForGrade = 0;
         this.honor = 0;
         this.honorDelta = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightResultPvpData(param1);
      }
      
      public function serializeAs_FightResultPvpData(param1:ICustomDataOutput) : void
      {
         super.serializeAs_FightResultAdditionalData(param1);
         if(this.grade < 0 || this.grade > 255)
         {
            throw new Error("Forbidden value (" + this.grade + ") on element grade.");
         }
         param1.writeByte(this.grade);
         if(this.minHonorForGrade < 0 || this.minHonorForGrade > 20000)
         {
            throw new Error("Forbidden value (" + this.minHonorForGrade + ") on element minHonorForGrade.");
         }
         param1.writeVarShort(this.minHonorForGrade);
         if(this.maxHonorForGrade < 0 || this.maxHonorForGrade > 20000)
         {
            throw new Error("Forbidden value (" + this.maxHonorForGrade + ") on element maxHonorForGrade.");
         }
         param1.writeVarShort(this.maxHonorForGrade);
         if(this.honor < 0 || this.honor > 20000)
         {
            throw new Error("Forbidden value (" + this.honor + ") on element honor.");
         }
         param1.writeVarShort(this.honor);
         param1.writeVarShort(this.honorDelta);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightResultPvpData(param1);
      }
      
      public function deserializeAs_FightResultPvpData(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._gradeFunc(param1);
         this._minHonorForGradeFunc(param1);
         this._maxHonorForGradeFunc(param1);
         this._honorFunc(param1);
         this._honorDeltaFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightResultPvpData(param1);
      }
      
      public function deserializeAsyncAs_FightResultPvpData(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._gradeFunc);
         param1.addChild(this._minHonorForGradeFunc);
         param1.addChild(this._maxHonorForGradeFunc);
         param1.addChild(this._honorFunc);
         param1.addChild(this._honorDeltaFunc);
      }
      
      private function _gradeFunc(param1:ICustomDataInput) : void
      {
         this.grade = param1.readUnsignedByte();
         if(this.grade < 0 || this.grade > 255)
         {
            throw new Error("Forbidden value (" + this.grade + ") on element of FightResultPvpData.grade.");
         }
      }
      
      private function _minHonorForGradeFunc(param1:ICustomDataInput) : void
      {
         this.minHonorForGrade = param1.readVarUhShort();
         if(this.minHonorForGrade < 0 || this.minHonorForGrade > 20000)
         {
            throw new Error("Forbidden value (" + this.minHonorForGrade + ") on element of FightResultPvpData.minHonorForGrade.");
         }
      }
      
      private function _maxHonorForGradeFunc(param1:ICustomDataInput) : void
      {
         this.maxHonorForGrade = param1.readVarUhShort();
         if(this.maxHonorForGrade < 0 || this.maxHonorForGrade > 20000)
         {
            throw new Error("Forbidden value (" + this.maxHonorForGrade + ") on element of FightResultPvpData.maxHonorForGrade.");
         }
      }
      
      private function _honorFunc(param1:ICustomDataInput) : void
      {
         this.honor = param1.readVarUhShort();
         if(this.honor < 0 || this.honor > 20000)
         {
            throw new Error("Forbidden value (" + this.honor + ") on element of FightResultPvpData.honor.");
         }
      }
      
      private function _honorDeltaFunc(param1:ICustomDataInput) : void
      {
         this.honorDelta = param1.readVarShort();
      }
   }
}
